using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Threading;
using System.IO;

namespace DavidTimeSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> fileOne = new string[] { "aa", "bb", "cc", "dd", "ff", "ee", "zz", "xx", "yy", "qq" };
            IList<string> fileTwo = new string[] { "bb", "ff", "uu", "ii", "oo", "mm", "aa", "zz", "rr" };

            WriteToFile("fileOne", fileOne);
            WriteToFile("fileTwo", fileTwo);

            HashSet<string> hsOne = ReadFromFile("fileOne");
            HashSet<string> hsTwo = ReadFromFile("fileTwo");

            DisplayHashSet(hsOne);
            DisplayHashSet(hsTwo);

            HashSet<string> intersectHash = new HashSet<string>(hsOne);
            HashSet<string> unionHash = new HashSet<string>(hsOne);
            HashSet<string> exceptHash = new HashSet<string>(hsOne);

            intersectHash.IntersectWith(hsTwo);
            unionHash.UnionWith(hsTwo);
            exceptHash.ExceptWith(hsTwo);

            Console.WriteLine();

            DisplayHashSet(intersectHash);
            Console.WriteLine("-----------------分割线----------------------");
            DisplayHashSet(unionHash);
            Console.WriteLine("-----------------分割线----------------------");
            DisplayHashSet(exceptHash);
            Console.WriteLine("-----------------分割线----------------------");
            DisplayHashSet(hsOne);
            Console.WriteLine("-----------------分割线----------------------");
            DisplayHashSet(hsTwo);

            Console.ReadLine();
        }

        /// <summary>
        /// 写入Txt文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="list"></param>
        private static void WriteToFile(string fileName, IList<string> list)
        {
            string directoryPath = @"D:\开发\测试";
            string filePath = string.Concat(directoryPath, @"\" + fileName + ".txt");

            try
            {
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                if (File.Exists(filePath))
                    File.Delete(filePath);
                File.Create(filePath).Close();

                FileStream fileWriter = new FileStream(filePath, FileMode.Open, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fileWriter);
                foreach (string item in list)
                {
                    sw.WriteLine(item);
                }
                sw.Flush();
                sw.Close();

                Console.WriteLine("文件保存成功路径：{0}", filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取Txt文件，返回HashSet对象
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static HashSet<string> ReadFromFile(string fileName)
        {
            string filePath = @"D:\开发\测试\" + fileName + ".txt";
            HashSet<string> hs = new HashSet<string>();

            try
            {
                if (File.Exists(filePath))
                {
                    FileStream fileReader = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fileReader);

                    string strLine = sr.ReadLine();
                    while (strLine != null)
                    {
                        string readStr = strLine;
                        hs.Add(readStr);
                        strLine = sr.ReadLine();
                    }
                    sr.Close();

                    Console.WriteLine("文件流读取完毕!");
                }

                return hs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 遍历输出HashSet值
        /// </summary>
        /// <param name="hashSets"></param>
        private static void DisplayHashSet(HashSet<string> hashSets)
        {
            foreach (string item in hashSets)
            {
                Console.Write(item + "|");
            }
            Console.WriteLine();
        }
    }
}
