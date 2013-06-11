using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using DavidCommon;
using DavidProject;
using System.Threading;
using System.IO;

namespace DavidAdvancedClient
{
    public class ServerClient
    {
        #region 私有变量

        private const int BufferSize = 8096;
        private TcpClient serverClient;
        private IList<TcpClient> serverClientLs;
        private string Msg = "Hello world, david test!";
        private string Head_Msg = string.Empty;
        private byte[] buffer;
        private NetworkStream streamToClient;
        private ProtocolHandler protocolHandler;

        #endregion

        #region 构造方法

        /// <summary>
        /// 传输文本测试用
        /// </summary>
        /// <param name="serverClient"></param>
        public ServerClient(TcpClient serverClient)
        {
            this.serverClient = serverClient;
            serverClientLs = new List<TcpClient>();
            string.Format("[length={0}]{1}", Msg.Length, Msg);

            //显示当前连接到服务器上的客户端地址IP与端口
            Console.WriteLine("Client Connected！ {0}->{1}", serverClient.Client.LocalEndPoint, serverClient.Client.RemoteEndPoint);
            streamToClient = serverClient.GetStream();
            buffer = new byte[BufferSize];
            BeginRead();
        }

        /// <summary>
        /// 传输文件测试用
        /// </summary>
        /// <param name="serverClient"></param>
        public ServerClient(TcpClient serverClient, bool mode)
        {
            this.serverClient = serverClient;
            serverClientLs = new List<TcpClient>();

            //显示当前连接到服务器上的客户端地址IP与端口
            Console.WriteLine("Client Connected！ {0}->{1}", serverClient.Client.LocalEndPoint, serverClient.Client.RemoteEndPoint);
            streamToClient = serverClient.GetStream();
            buffer = new byte[BufferSize];

            protocolHandler = new ProtocolHandler();
        }

        //开始异步读取
        public void BeginRead()
        {
            //构造函数中设置一个异步委托
            AsyncCallback callBack = new AsyncCallback(ReadComplete);
            //开始一个异步调用
            streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
        }

        /// <summary>
        /// 开始异步
        /// </summary>
        public void OnBeginRead()
        {
            AsyncCallback callBack = new AsyncCallback(OnReadComplete);
            streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
        }

        public void OnReadComplete(IAsyncResult asyrs)
        {
            int bytesRead = 0;
            try
            {
                lock (streamToClient)
                {
                    bytesRead = streamToClient.EndRead(asyrs);
                    Console.WriteLine("From client->{0}, Read Data, {1} type...", this.serverClient.Client.RemoteEndPoint.ToString(), bytesRead);
                }

                if (bytesRead == 0) throw new Exception("Received 0 data！");

                //接受到客户端发来的请求是，进行发送还是接收操作
                string receivedMsg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                Array.Clear(buffer, 0, buffer.Length);

                //解析XML数组
                string[] protocalArray = protocolHandler.GetProtocol(receivedMsg);
                foreach (string protocal in protocalArray)
                {
                    ParameterizedThreadStart start = new ParameterizedThreadStart(HandleProtocol);
                    start.BeginInvoke(protocal, null, null);
                }

                lock (streamToClient)
                {
                    OnBeginRead();
                }
            }
            catch (Exception ex)
            {
                if (streamToClient != null)
                    streamToClient.Dispose();
                serverClient.Close();
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleProtocol(object obj)
        {
            string protocol = obj as string;
            ProtocolHelper helper = new ProtocolHelper(protocol);
            FileProtocol pro = helper.GetFileProtocol();

            if (pro.Mode == FileRequestMode.Send)
                ReceiveFile(pro);
            else if (pro.Mode == FileRequestMode.Receive)
                SendFile(pro);
        }

        /// <summary>
        /// 接收文件
        /// </summary>
        private void ReceiveFile(FileProtocol protocol)
        {
            TcpClient localClient;
            //与该客户端建立连接
            NetworkStream networkStream = GetStreamToClient(protocol, out localClient);

            //随机生成一个图片保存的文件夹
            string path = Environment.CurrentDirectory + "/" + new NetworkHelper().GenerateFilePathName(protocol.FileName);

            byte[] fileBuffer = new byte[1024];
            FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);

            int bytesRead = 0;
            int totalBytes = 0;
            do
            {
                bytesRead = networkStream.Read(buffer, 0, BufferSize);
                fs.Write(buffer, 0, bytesRead);
                totalBytes += bytesRead;
                Console.WriteLine("Received {0} bytes!", totalBytes);

            } while (bytesRead > 0);

            Console.WriteLine("Total {0} bytes recevied, Done!", totalBytes);

            //关闭临时发送文件流
            networkStream.Dispose();
            //关闭释放文件写入流
            fs.Dispose();
            //关闭临时的客户端连接
            localClient.Close();
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="protocol"></param>
        private void SendFile(FileProtocol protocol)
        {
            TcpClient localClient;
            NetworkStream networkStream = GetStreamToClient(protocol, out localClient);

            byte[] filebuffer = new byte[1024];

            //随机生成一个图片保存的文件夹
            string path = Environment.CurrentDirectory + "/" + new NetworkHelper().GenerateFilePathName(protocol.FileName);
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            int bytesRead;
            int totolBytes = 0;

            try
            {
                do
                {
                    bytesRead = networkStream.Read(filebuffer, 0, filebuffer.Length);
                    fs.Write(buffer, 0, bytesRead);
                    totolBytes += bytesRead;
                    Console.WriteLine("Total {0} bytes sent, Done!", totolBytes);

                } while (bytesRead > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server has lost..., {0}", ex.Message);
            }

            networkStream.Dispose();
            fs.Dispose();
            localClient.Close();
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="localClient"></param>
        /// <returns></returns>
        private NetworkStream GetStreamToClient(FileProtocol pro, out TcpClient localClient)
        {
            // 获取远程客户端的位置
            IPEndPoint endpoint = serverClient.Client.RemoteEndPoint as IPEndPoint;
            IPAddress ip = endpoint.Address;

            //开辟一个文件传输端口用于文件传输
            endpoint = new IPEndPoint(ip, pro.Port);

            //连接到远程客户端
            try
            {
                localClient = new TcpClient();
                localClient.Connect(endpoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("无法连接到客户端：{0}", ex.Message);
                localClient = null;
                return null;
            }

            //与该客户端建立连接
            NetworkStream networkStream = localClient.GetStream();
            return networkStream;
        }

        /// <summary>
        /// 异步调用结束后需要执行的回调函数
        /// </summary>
        /// <param name="asynResult"></param>
        private void ReadComplete(IAsyncResult asynResult)
        {
            int bytesRead = 0;
            try
            {
                lock (streamToClient)
                {
                    bytesRead = streamToClient.EndRead(asynResult);
                    Console.WriteLine("From client->{0}, Read Data, {1} type...", this.serverClient.Client.RemoteEndPoint.ToString(), bytesRead);
                }

                if (bytesRead == 0) throw new Exception("Received 0 data！");

                //注意点1
                string receivedMsg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                Array.Clear(buffer, 0, buffer.Length);

                //处理请求过来的字符串因为有可能产生Helloworld!Helloworld!的情况，加入自定义的报文协议区别正确数据
                string[] msgLs = new RequestHandler().GetActualString(receivedMsg);

                foreach (string msg in msgLs)
                {
                    Console.WriteLine("From client->{0}, Received: {1}", this.serverClient.Client.RemoteEndPoint.ToString(), msg);
                    string backStr = msg.ToUpper();
                    //注意点2，一定要重新new一个buffer用来写入流中
                    byte[] newBuffer = Encoding.Unicode.GetBytes(formatHeadStr(backStr));
                    streamToClient.Write(newBuffer, 0, newBuffer.Length);
                    Console.WriteLine("Sent UpperString: {0}", backStr);
                    streamToClient.Flush();//清除缓冲区上的所有数据
                }

                lock (streamToClient)
                {
                    //自己调用自己行程无限循环不需要在调用do-while，只要客户端一直有数据传送到服务器端则一直会运行这段
                    AsyncCallback callBack = new AsyncCallback(ReadComplete);
                    streamToClient.BeginRead(buffer, 0, BufferSize, callBack, null);
                }
            }
            catch (Exception ex)
            {
                if (streamToClient != null)
                    streamToClient.Dispose();
                serverClient.Close();
                Console.WriteLine(ex.Message);//捕获异常时退出
            }
        }

        /// <summary>
        /// 得到带有头长度的文本
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private string formatHeadStr(string msg)
        {
            return string.Format("[length={0}]{1}", msg.Length, msg);
        }

        #endregion
    }
}
