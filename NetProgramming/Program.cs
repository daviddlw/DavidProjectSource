using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 基本HTTP请求
            ////在Windows系统中，采用127.0.0.1作为本地环回地址
            //IPAddress localAddress = IPAddress.Loopback;

            ////创建一个可以访问的断点
            //IPEndPoint endpoint = new IPEndPoint(localAddress, 10002);

            ////建立TCP连接
            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ////将Socket绑定到断点上
            //socket.Bind(endpoint);

            //// 设置连接队列的长度, 可以接受最大10个socket客户端连接请求
            //socket.Listen(10);

            //while (true)
            //{
            //    //服务器端等待接收相应
            //    Console.WriteLine("等待一个请求......");
            //    Socket clientSocket = socket.Accept();
            //    Console.WriteLine("客户端请求地址为：{0}", clientSocket.RemoteEndPoint);

            //    byte[] buffer = new byte[2048];
            //    int receiveLength = clientSocket.Receive(buffer, 2048, SocketFlags.None);
            //    string requestString = Encoding.UTF8.GetString(buffer, 0, receiveLength);

            //    //在服务器端输出请求信息
            //    Console.WriteLine(requestString);

            //    //服务器端做出相应请求
            //    /*
            //     1-状态行,2-响应头,3-<一个空行>,4-响应数据 
            //     */
            //    string statusline = "HTTP/1.1 200 OK\r\n";
            //    byte[] responseStatusLineBytes = Encoding.UTF8.GetBytes(statusline);

            //    string responseBody = "<html><head><title>Default Page</title></head><body><p style='font:bold;font-size:24pt'>Welcome To David Space</p></body></html>";
            //    string responseHeader = string.Format("Content-Type: text/html; charset=UTf-8\r\nContent-Length: {0}\r\n", responseBody.Length);

            //    byte[] responseHeaderBytes = Encoding.UTF8.GetBytes(responseHeader);
            //    byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);


            //    // 向客户端发送状态行
            //    clientSocket.Send(responseStatusLineBytes);
            //    // 向客户端发送回应头信息
            //    clientSocket.Send(responseHeaderBytes);
            //    // 发送头部和内容的空行-用来表示服务器头部信息的结束
            //    clientSocket.Send(new byte[] { 13, 10 });

            //    //向客户端发送响应内容
            //    clientSocket.Send(responseBodyBytes);

            //    //断开链接
            //    clientSocket.Close();
            //    Console.ReadKey();
            //    break;
            //}

            ////关闭服务器
            //socket.Close();
            #endregion

            #region Net平台下的HTTP请求

            IPAddress netIpAddress = IPAddress.Loopback;

            IPEndPoint endpoint = new IPEndPoint(netIpAddress, 10003);

            TcpListener listener = new TcpListener(endpoint);

            listener.Start();
            Console.WriteLine("等待一个TCP连接...");

            while (true)
            {
                TcpClient tcpclient = listener.AcceptTcpClient();

                if (tcpclient.Connected)
                    Console.WriteLine("已经建立了链接......");

                NetworkStream ns = tcpclient.GetStream();
                byte[] buffer = new byte[2048];

                int receiveLength = ns.Read(buffer, 0, buffer.Length);
                string requestString = Encoding.UTF8.GetString(buffer, 0, receiveLength);

                Console.WriteLine(requestString);

                string statusline = "HTTP/1.1 200 OK\r\n";
                byte[] responseStatusLineBytes = Encoding.UTF8.GetBytes(statusline);
                ns.Write(responseStatusLineBytes, 0, responseStatusLineBytes.Length);

                string responseBody = "<html><head><title>Default Page</title></head><body><p style='font:bold;font-size:24pt'>Welcome To David Space</p></body></html>";
                byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);
                string responseHeader = string.Format("Content-Type: text/html; charset=UTf-8\r\nContent-Length: {0}\r\n", responseBody.Length);
                byte[] responseHeaderBytes = Encoding.UTF8.GetBytes(responseHeader);

                ns.Write(responseHeaderBytes, 0, responseHeaderBytes.Length);
                ns.Write(new byte[] { 13, 10 }, 0, 2);
                ns.Write(responseBodyBytes, 0, responseBodyBytes.Length);

                ns.Close();
                tcpclient.Close();
                Console.ReadKey();
                break;
            }

            listener.Stop();

            #endregion
        }
    }
}
