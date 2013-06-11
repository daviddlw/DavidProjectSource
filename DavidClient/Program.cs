using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace DavidProject
{
    class DavidClient
    {
        private const int BufferSize = 8096;
        static void Main(string[] args)
        {
            IPAddress serverIP = new IPAddress(new byte[] { 127, 0, 0, 1 });
            Console.WriteLine("Client is running...");
            TcpClient client = null;
            List<TcpClient> clientList = new List<TcpClient>();
            string msg = "Hello world, david test!";
            string headMsg = string.Format("[length={0}]{1}", msg.Length, msg);
            #region 建立单个client通讯客户端

            //try
            //{

            //    client = new TcpClient();
            //    client.Connect(serverIP, 9999);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}

            //Console.WriteLine("Server Connected！ {0}->{1}", client.Client.LocalEndPoint, client.Client.RemoteEndPoint);

            //try
            //{
            //    NetworkStream steamToServer = client.GetStream();
            //    Console.WriteLine("Menu: S-Send, E-Exit");
            //    ConsoleKey key;
            //    do
            //    {
            //        key = Console.ReadKey(true).Key;
            //        if (key == ConsoleKey.S)
            //        {
            //            #region 测试循环多次输入的方式
            //            //byte[] buffer;
            //            //for (int i = 0; i <= 2; i++)
            //            //{
            //            //    buffer = Encoding.Unicode.GetBytes(headMsg);
            //            //    lock (steamToServer)
            //            //    {
            //            //        steamToServer.Write(buffer, 0, buffer.Length);
            //            //    }
            //            //    Console.WriteLine("Sent: {0}", headMsg);
            //            //}
            //            #endregion

            //            #region 手动输入测试

            //            //获取输入字符串
            //            Console.WriteLine("Please input the message: ");
            //            msg = Console.ReadLine();

            //            byte[] buffer = Encoding.Unicode.GetBytes(headMsg);
            //            lock (steamToServer)
            //            {
            //                steamToServer.Write(buffer, 0, buffer.Length);
            //            }

            //            Console.WriteLine("Sent: {0}", headMsg);

            //            NetworkStream receivedToClient = client.GetStream();
            //            buffer = new byte[BufferSize];
            //            int bytesRead;
            //            lock (receivedToClient)
            //            {
            //                bytesRead = receivedToClient.Read(buffer, 0, BufferSize);
            //            }
            //            Console.WriteLine("Received {0} Data", bytesRead);

            //            string receivedMsg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
            //            Console.WriteLine("Received: {0}", receivedMsg);
            //            #endregion

            //        }
            //    } while (key != ConsoleKey.E);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return;
            //}

            #endregion

            #region 建立多个client通讯客户端

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(serverIP, 9999);
                    clientList.Add(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            foreach (var item in clientList)
            {
                Console.WriteLine("Server Connected！ {0}->{1}", item.Client.LocalEndPoint, item.Client.RemoteEndPoint);
                NetworkStream steamToServer = item.GetStream();

                byte[] buffer = Encoding.Unicode.GetBytes(headMsg);

                steamToServer.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Sent: {0}", msg);
            }

            #endregion

            NetworkHelper.ConsoleQuit();
        }
    }
}
