using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using DavidProject;
using System.IO;
using DavidCommon;
using System.Threading;

namespace DavidAdvancedClient
{
    public class RemoteClient : IDisposable
    {
        #region 私有变量

        private const int BufferSize = 8096;
        private IPAddress serverIP = new IPAddress(new byte[] { 127, 0, 0, 1 });
        private IPAddress fileIP = new IPAddress(new byte[] { 127, 0, 0, 1 });
        private TcpClient client;
        private IList<TcpClient> clientLs;
        private string Msg = "Hello world, david test!";
        private string Head_Msg = string.Empty;
        private byte[] buffer;
        private NetworkStream streamToServer;

        #endregion

        #region 公共方法

        public RemoteClient()
        {
            try
            {
                Head_Msg = formatHeadStr(Msg);
                client = new TcpClient();
                clientLs = new List<TcpClient>();
                client.Connect(serverIP, 9999);

            }
            catch (Exception ex)
            {
                Console.WriteLine(!client.Connected ? string.Format("{0}，stream流为null", ex.Message) : ex.Message);
                return;
            }
            buffer = new byte[BufferSize];

            Console.WriteLine("Server Connected！ {0}->{1}", client.Client.LocalEndPoint, client.Client.RemoteEndPoint);
            streamToServer = client.GetStream();
        }

        /// <summary>
        /// 手动输入文本-按Q退出输入
        /// </summary>
        public void SendMessageManually()
        {
            ConsoleKey enterKey;
            try
            {
                do
                {
                    Console.WriteLine("请输入测试文本（按Q退出输入）：\n");
                    enterKey = Console.ReadKey(true).Key;
                    string inputMsg = Console.ReadLine();

                    byte[] writeBytes = Encoding.Unicode.GetBytes(formatHeadStr(inputMsg));
                    lock (streamToServer)
                    {
                        streamToServer.Write(writeBytes, 0, writeBytes.Length);
                        Console.WriteLine("Sent message \"{0}\" successfully!", inputMsg);
                    }

                    if (streamToServer != null)
                    {
                        lock (streamToServer)
                        {
                            AsyncCallback callback = new AsyncCallback(ReadComplete);
                            streamToServer.BeginRead(buffer, 0, BufferSize, callback, null);
                        }
                    }

                } while (enterKey != ConsoleKey.Q);
            }
            catch (Exception ex)
            {
                Console.WriteLine(!client.Connected ? string.Format("{0}，stream流为null", ex.Message) : ex.Message);
                return;
            }
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public void SendMessage()
        {
            SendMessage(this.Head_Msg);
        }

        /// <summary>
        /// 发送消息到服务端
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageSingle(string message)
        {
            byte[] temp = Encoding.Unicode.GetBytes(message);
            try
            {
                lock (streamToServer)
                {
                    streamToServer.Write(temp, 0, temp.Length);
                }
                Console.WriteLine("Sent: {0}", temp.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region Send-Part

        public void BeginSendFile(string filePath)
        {
            ParameterizedThreadStart start = new ParameterizedThreadStart(BeginSendFile);
            start.BeginInvoke(filePath, null, null);
        }

        private void BeginSendFile(object obj)
        {
            string path = obj as string;
            SendFile(path);
        }

        public void SendFile(string filePath)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 0);

            listener.Start();

            //获取本地侦听端口
            IPEndPoint endPoint = listener.LocalEndpoint as IPEndPoint;
            int listeningPort = endPoint.Port;

            //获取发送协议的文本
            string filename = Path.GetFileName(filePath);
            FileProtocol filePro = new FileProtocol(filename, listeningPort, FileRequestMode.Send);
            string pro = filePro.ToString();

            SendMessageSingle(pro);

            //中断，等待远程连接
            TcpClient localClient = listener.AcceptTcpClient();
            Console.WriteLine("Starting sending file...");
            NetworkStream ns = localClient.GetStream();

            //创建文件流
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] fileBuffer = new byte[1024];
            int fileReads;
            int totalReads = 0;

            SendStatus status = new SendStatus(filePath);

            try
            {
                do
                {
                    Thread.Sleep(20); //更好的视觉效果暂停10毫秒
                    fileReads = fs.Read(fileBuffer, 0, fileBuffer.Length);
                    ns.Write(fileBuffer, 0, fileReads);
                    totalReads += fileReads;
                    status.PrintStatus(totalReads);

                } while (fileReads > 0);
                Console.WriteLine("Total {0} bytes sent, Done！", totalReads);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server has lost, {0}", ex.Message);
            }
            finally
            {
                ns.Dispose();
                fs.Dispose();
                localClient.Close();
            }
        }

        #endregion

        #region Receive-Part

        public void BeginReceiveFile(string fileName)
        {
            ParameterizedThreadStart start = new ParameterizedThreadStart(BeginReceiveFile);
            start.BeginInvoke(fileName, null, null);
        }

        public void BeginReceiveFile(object obj)
        {
            string fileName = obj as string;
            ReceiveFile(fileName);
        }

        public void ReceiveFile(string fileName)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 0);

            listener.Start();

            //获取本地侦听端口
            IPEndPoint endPoint = listener.LocalEndpoint as IPEndPoint;
            int listeningPort = endPoint.Port;

            //获取接受协议文本
            FileProtocol filePro = new FileProtocol(fileName, listeningPort, FileRequestMode.Receive);
            string pro = filePro.ToString();

            SendMessageSingle(pro);

            TcpClient localClient = listener.AcceptTcpClient();
            Console.WriteLine("Starting Receing file...");
            NetworkStream ns = localClient.GetStream();

            //获取文件保存路径
            string filePath = Environment.CurrentDirectory + "/" + new NetworkHelper().GenerateFilePathName(fileName);

            FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
            byte[] fileBuffer = new byte[1024];
            int byteReads;
            int totalReads = 0;

            SendStatus status = new SendStatus(filePath);

            try
            {
                do
                {
                    Thread.Sleep(20);
                    byteReads = ns.Read(fileBuffer, 0, fileBuffer.Length);
                    totalReads += byteReads;
                    Console.WriteLine("Receving {0} bytes...", totalReads);

                } while (byteReads > 0);

                Console.WriteLine("Total {0} bytes received, Done!", totalReads);

                fs.Dispose();
                ns.Dispose();
                localClient.Close();
                listener.Stop();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// 单个客户端发送3条消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            for (int i = 0; i <= 2; i++)
            {
                byte[] temp = Encoding.Unicode.GetBytes(message);
                try
                {
                    lock (streamToServer)
                    {
                        streamToServer.Write(temp, 0, temp.Length);
                        Console.WriteLine("Sent: {0}", message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(!client.Connected ? string.Format("{0}，stream流为null", ex.Message) : ex.Message);
                    break;
                }
            }

            if (streamToServer != null)
            {
                lock (streamToServer)
                {
                    AsyncCallback callback = new AsyncCallback(ReadComplete);
                    streamToServer.BeginRead(buffer, 0, BufferSize, callback, null);
                }
            }
        }

        public void ReadComplete(IAsyncResult asynResult)
        {
            int bytesRead;
            try
            {
                lock (streamToServer)
                {
                    bytesRead = streamToServer.EndRead(asynResult);
                }
                if (bytesRead == 0) throw new Exception("读取到0字节");

                string result = Encoding.Unicode.GetString(buffer, 0, bytesRead);

                string[] msgLs = new RequestHandler().GetActualString(result);

                foreach (string msg in msgLs)
                {
                    Console.WriteLine("Received: {0}", msg);
                }

                Array.Clear(buffer, 0, buffer.Length);

                lock (streamToServer)
                {
                    AsyncCallback callback = new AsyncCallback(ReadComplete);
                    streamToServer.BeginRead(buffer, 0, BufferSize, callback, null);
                }

            }
            catch (Exception ex)
            {
                if (streamToServer != null)
                    streamToServer.Dispose();
                client.Close();
                Console.WriteLine(ex.Message);
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

        public void Dispose()
        {
            if (streamToServer != null)
                streamToServer.Dispose();
            if (client != null)
                client.Close();
        }
    }
}
