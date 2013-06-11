using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace DavidAdvancedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey key;
            RemoteClient client = new RemoteClient();
            string input = string.Empty;

            //运行3个客户端每个客户端进行发送3条消息
            //for (int i = 0; i < 3; i++)
            //{
            //    Thread.Sleep(1000);
            //    RemoteClient client = new RemoteClient();
            //    //client.SendMessage();
            //    client.SendMessageManually();
            //}

            #region 手动-自动发送测试数据
            //Thread.Sleep(1000);
            //client.SendMessage();
            //client.SendMessageManually();
            #endregion

            #region 测试发送程序

            string path = Environment.CurrentDirectory + "/";
            do
            {
                Console.WriteLine("Send File: S1 - 灌篮高手.jpg, S2 - 仙剑奇侠传.jpg");
                Console.WriteLine("Receive File: R1 - 灌篮高手.jpg, R2 - 仙剑奇侠传.jpg");
                Console.WriteLine("Enter your choice: \n");
                input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "S1": client.BeginSendFile(path + "灌篮高手.jpg");
                        break;
                    case "S2": client.BeginSendFile(path + "仙剑奇侠传.pdf");
                        break;
                    case "R1": client.BeginReceiveFile("灌篮高手.jpg");
                        break;
                    case "R2": client.BeginReceiveFile("仙剑奇侠传.pdf");
                        break;
                }

            } while (input.ToUpper() != ConsoleKey.Q.ToString());

            client.Dispose();

            #endregion
            //string filePath = Environment.CurrentDirectory + "/" + "仙剑奇侠传.jpg";
            //if (File.Exists(filePath))
            //    client.BeginSendFile(filePath);

            do
            {
                Console.WriteLine("按E退出客户端");
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.E);
        }
    }
}
