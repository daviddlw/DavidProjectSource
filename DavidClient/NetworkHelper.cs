using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidProject
{
    public class NetworkHelper
    {
        public static void ConsoleQuit()
        {
            Console.WriteLine("按Q键退出...");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
        }
    }
}
    