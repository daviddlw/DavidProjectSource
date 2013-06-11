using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace DavidAdvancedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //服务器启动监听
            IPAddress serverIP = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TcpListener listener = new TcpListener(serverIP, 9999);
            Console.WriteLine("Server is running...");

            listener.Start();
            Console.WriteLine("Starting listening...");

            //while (true)
            //{
            //    TcpClient client = listener.AcceptTcpClient();
            //    ServerClient wrapper = new ServerClient(client);
            //}

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                ServerClient wrapper = new ServerClient(client, true);
                wrapper.OnBeginRead();
            }
        }
    }
}
