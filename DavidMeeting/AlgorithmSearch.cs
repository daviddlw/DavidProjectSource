using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DavidMeeting
{
    public class AlgorithmSearch
    {
        #region 构造方法

        public AlgorithmSearch() { }

        #endregion

        #region 公共方法

        /// <summary>
        /// -1表示没找到
        /// </summary>
        /// <param name="index">所找到元素的</param>
        /// <param name="list"></param>
        /// <returns></returns>
        public int RecursionSearch(int searchIndex, string[] list, string searchObj)
        {
            if (list[searchIndex] == searchObj)
                return searchIndex;
            else if (searchIndex + 1 < list.Length)
                return RecursionSearch(searchIndex + 1, list, searchObj);
            else
                return -1;
        }

        /// <summary>
        /// 顺序查找
        /// </summary>
        /// <param name="list">待查找列表</param>
        /// <param name="key">需要查找的关键词</param>
        /// <returns>返回关键词在列表中的索引，找不到返回-1</returns>
        public int SequenceSearch(List<int> list, int key)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == key)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// 二分查找发
        /// </summary>
        /// <param name="list">待查找列表</param>
        /// <param name="key">需要查找的关键词</param>
        /// <returns>返回关键词在列表中的索引，找不到返回-1</returns>
        public int BinarySearch(List<int> list, int key)
        {
            int low = 0, high = list.Count - 1;

            while (low <= high)
            {
                int middle = (low + high) / 2;

                if (key == list[middle])
                    return middle;
                else if (key < list[middle])
                    high = middle - 1;
                else
                    low = middle + 1;
            }

            return -1;
        }

        /// <summary>
        /// 插入Hash函数
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="hashLength"></param>
        /// <param name="data"></param>
        private void InsertHash(int[] hash, int data, int hashLength)
        {
            //除法取余法
            int hasAddress = data % hashLength;

            while (hash[hasAddress] != 0)
            {
                //（如果当前地址已经存在数据则用开放地址法查找下一个）
                hasAddress = (++hasAddress) % hashLength;
            }

            //将数据放入hash字典中
            hash[hasAddress] = data;
        }

        /// <summary>
        /// Hash搜索法
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="hashLength"></param>
        /// <param name="data"></param>
        /// <param name="hashLength"></param>
        /// <returns></returns>
        private int SearchHash(int[] hash, int data, int hashLength)
        {
            int hashAddress = data % hashLength;

            //指定hashAdrress对应值存在但不是关键值，则用开放寻址法解决
            while (hash[hashAddress] != 0 && hash[hashAddress] != data)
            {
                hashAddress = (++hashAddress) % hashLength;
            }

            if (hash[hashAddress] == 0)
                return -1;

            return hashAddress;
        }

        public void HashSearch(int[] hashArray)
        {
            int hashLength = hashArray.Length > 0 ? hashArray[0] : 0;

            //构造hash表
            int[] hash = new int[hashLength];

            //插入HashKey
            for (int i = 0; i < hashArray.Length; i++)
            {
                InsertHash(hash, hashArray[i], hashLength);
            }

            Console.WriteLine("当前数组：\n");
            Console.WriteLine(string.Join(",", hashArray));
            Console.WriteLine("-------------------");
            string inputStr;
            do
            {

                Console.WriteLine("----按Q退出输入----");
                Console.WriteLine("请输入需要查询的数值：\n");
                inputStr = Console.ReadLine().Trim();
                int data = 0;
                Regex regx = new Regex(@"^\d+$");
                if (!string.IsNullOrEmpty(inputStr) && regx.IsMatch(inputStr))
                    data = Convert.ToInt32(inputStr);
                else
                    Console.WriteLine("请输入数值。\n");


                int result = SearchHash(hash, data, hashLength);

                if (result != -1)
                {
                    Console.WriteLine("数字：{0}，索引位置是{1}\n", data, result);
                }
                else
                {
                    Console.WriteLine("该数字在HASH中没有找到\n");
                }
            } while (inputStr.ToLower() != "q");
        }

        #endregion
    }
}
