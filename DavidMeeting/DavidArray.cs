using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace DavidMeeting
{
    public class DavidArray
    {
        public static void TestMixArray()
        {
            int[] number1 = new int[] { 1, 2, 3, 4, 5 };
            int[] number2 = new int[] { 6, 7 };
            int[] number3 = new int[] { 8, 9, 10, 11 };

            int[][] arr = new int[3][] { number1, number2, number3 };
            List<string> ls = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                ls.Clear();
                Console.WriteLine("---------------");
                for (int j = 0; j < arr[i].Length; j++)
                {
                    ls.Add(arr[i][j].ToString());
                }
                Console.WriteLine(string.Join("，", ls));
            }

            Console.WriteLine(arr.Rank);
            Console.WriteLine(arr.GetLength(0));
            Console.WriteLine(arr.GetUpperBound(0));
            Console.ReadLine();
        }

        /// <summary>
        /// 生成随机的数组
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int[] GenerateRandomArray(int min, int max, int length)
        {
            IList<int> randomLs = new List<int>();
            Random rd = new Random();
            int randomNum = 0;

            while (randomLs.Count < 10)
            {
                randomNum = rd.Next(min, max);
                if (!randomLs.Contains(randomNum))
                {
                    randomLs.Add(randomNum);
                }
            }

            return randomLs.ToArray<int>();
        }

        public DataTable GetDataTable()
        {
            DataTable resultTable = new DataTable();
            List<DataColumn> columnLs = new List<DataColumn>()
            {
                new DataColumn(){ ColumnName="CampaignId", DataType=typeof(int)},
                new DataColumn(){ ColumnName="CampaignName", DataType=typeof(string)},
                new DataColumn(){ ColumnName="IsEcommerce", DataType=typeof(bool)},
                new DataColumn(){ ColumnName="Impressions", DataType=typeof(long)},
                new DataColumn(){ ColumnName="Clicks", DataType=typeof(long)}
            };
            resultTable.Columns.AddRange(columnLs.ToArray());
            resultTable.Rows.Add(1, "测试订单1", false, 100, 20);
            resultTable.Rows.Add(2, "测试订单2", false, 311, 12);
            resultTable.Rows.Add(3, "测试订单3", true, 562, 31);
            resultTable.Rows.Add(4, "测试订单4", false, 145, 52);
            resultTable.Rows.Add(5, "测试订单5", true, 613, 62);

            return resultTable;
        }

        public class TestModel
        {
            public int CampaignId { get; set; }

            public string CampaignName { get; set; }

            public bool IsEcommerce { get; set; }

            public long Impressions { get; set; }

            public long Clicks { get; set; }
        }
    }
}
