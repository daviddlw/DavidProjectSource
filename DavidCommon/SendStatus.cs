using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DavidCommon
{
    public class SendStatus
    {
        private FileInfo fileInfo;
        private long fileSize;


        public SendStatus(string filePath)
        {
            fileInfo = new FileInfo(filePath);
            fileSize = fileInfo.Length;
        }

        public void PrintStatus(int current)
        {
            string percent = GetPercent(current);
            Console.WriteLine("Sending {0} bytes, {1}", current, percent);
        }

        /// <summary>
        /// 查看传输进度
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public string GetPercent(int current)
        {
            decimal allBytes = Convert.ToDecimal(fileSize);
            decimal completeBytes = Convert.ToDecimal(current);

            decimal percent = allBytes == 0 ? 0 : Math.Round(completeBytes / allBytes, 4);

            return percent.ToString("p");
        }
    }
}
