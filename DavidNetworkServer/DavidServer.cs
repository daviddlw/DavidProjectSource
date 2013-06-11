using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace DavidProject
{
    class DavidServer
    {
        private const int BufferSize = 8096;
        static void Main(string[] args)
        {
            Console.WriteLine("Server is running...");
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TcpListener listener = new TcpListener(ip, 9999);

            listener.Start();
            Console.WriteLine("Starting listening...");

            #region 单个请求
            //中断方法一直到接收到一个tcpclient请求才执行到下一步

            //TcpClient remoteClient = listener.AcceptTcpClient();
            //Console.WriteLine("Client Connected！ {0}->{1}", remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);

            ////对于小文件可以这样写，对于一些特殊的大文件，我们需要分段读取如缓存中，否则当读取的文件长度大于缓存长度，字符串会出现被截断的现象
            //NetworkStream clientStream = remoteClient.GetStream();
            //byte[] buffer = new byte[BufferSize];
            //int bytesRead = clientStream.Read(buffer, 0, BufferSize);
            //Console.WriteLine("Read Data, {0} type...", bytesRead);

            ////改写方法如下
            ////byte[] buffer = new byte[BufferSize];
            ////int bytesRead;
            ////NetworkStream clientStream = remoteClient.GetStream();
            ////MemoryStream memoryStream = new MemoryStream();
            ////do
            ////{
            ////    bytesRead = clientStream.Read(buffer, 0, BufferSize);
            ////    memoryStream.Write(buffer, 0, bytesRead);
            ////} while (bytesRead > 0);

            ////buffer = memoryStream.GetBuffer();

            ////获取请求的字符串
            //string msg = Encoding.Unicode.GetString(buffer);
            //Console.WriteLine("Received: {0}", msg);

            //msg = msg.ToUpper();
            //byte[] newBuffer = new byte[BufferSize];
            //newBuffer = Encoding.Unicode.GetBytes(msg);
            //clientStream.Write(newBuffer, 0, newBuffer.Length);
            //Console.WriteLine("Sent upper string: {0}", msg);

            #endregion

            #region 多个请求
            /*•如果不使用do/while循环，服务端只有一个listener.AcceptTcpClient()方法和一个TcpClient.GetStream().Read()方法，则服务端只能处理到同一客户端的一条请求。
            •如果使用一个do/while循环，并将listener.AcceptTcpClient()方法和TcpClient.GetStream().Read()方法都放在这个循环以内，那么服务端将可以处理多个客户端的一条请求。
            •如果使用一个do/while循环，并将listener.AcceptTcpClient()方法放在循环之外，将TcpClient.GetStream().Read()方法放在循环以内，那么服务端可以处理一个客户端的多条请求。
            •如果使用两个do/while循环，对它们进行分别嵌套，那么结果是什么呢？结果并不是可以处理多个客户端的多条请求。因为里层的do/while循环总是在为一个客户端服务，
             * 因为它会中断在TcpClient.GetStream().Read()方法的位置，而无法执行完毕。
             * 即使可以通过某种方式让里层循环退出，比如客户端往服务端发去“exit”字符串时，服务端也只能挨个对客户端提供服务。如果服务端想执行多个客户端的多个请求，
             * 那么服务端就需要采用多线程。主线程，也就是执行外层do/while循环的线程，在收到一个TcpClient之后，必须将里层的do/while循环交给新线程去执行，
             * 然后主线程快速地重新回到listener.AcceptTcpClient()的位置，以响应其它的客户端。
            */
            try
            {
                //RequestHandler.Test();

                TcpClient remoteClient = listener.AcceptTcpClient();

                Console.WriteLine("Client Connected！ {0}->{1}", remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);
                NetworkStream clientStream = remoteClient.GetStream();

                do
                {
                    //对于小文件可以这样写，对于一些特殊的大文件，我们需要分段读取如缓存中，否则当读取的文件长度大于缓存长度，字符串会出现被截断的现象                
                    byte[] buffer = new byte[BufferSize];
                    int bytesRead;
                    lock (clientStream)
                    {
                        bytesRead = clientStream.Read(buffer, 0, BufferSize);
                    }
                    if (bytesRead == 0) throw new Exception("读取0个字节。");

                    Console.WriteLine("Read Data, {0} type...", bytesRead);

                    //获取请求的字符串
                    string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                    //处理请求过来的字符串因为有可能产生Helloworld!Helloworld!的情况，加入自定义的报文协议区别正确数据
                    string[] list = new RequestHandler().GetActualString(msg);

                    //不给定读取的长度默认读取流里面所有的长度
                    //string testMsg = Encoding.Unicode.GetString(buffer);
                    foreach (var item in list)
                    {
                        Console.WriteLine("Received: {0}", item);
                    }

                    //服务端接收到客户端发来的文本将其转化为大写重新返回给客户端
                    foreach (var item in list)
                    {
                        string upperMsg = item.ToUpper();
                        buffer = Encoding.Unicode.GetBytes(upperMsg);
                        lock (clientStream)
                        {
                            clientStream.Write(buffer, 0, buffer.Length);
                        }
                        Console.WriteLine("Sent upper string: {0}", upperMsg);
                    }
                } while (true);

                clientStream.Dispose();
                remoteClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            #endregion

            NetworkHelper.ConsoleQuit();
        }
    }
}
