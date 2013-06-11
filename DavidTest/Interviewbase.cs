using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidTest
{
    public class Interviewbase
    {
        #region 私有变量

        private int[] firstArray = new int[] { 1, 2, 7, 12, 71, 110 };
        private int[] secondArray = new int[] { 3, 5, 11, 13 };


        #endregion

        #region 面试常用题库

        /// <summary>
        /// 合并两个排序数组成为一个新的排序数组
        /// </summary>
        /// <param name="firstSortArr"></param>
        /// <param name="secondSortArr"></param>
        /// <returns></returns>
        public List<int> MergeSortArrays(int[] firstSortArr, int[] secondSortArr)
        {
            List<int> mergeList = new List<int>();
            if (firstSortArr.Length > secondSortArr.Length)
            {
                int fi = 0;
                int si = 0;
                while (si < secondSortArr.Length)
                {
                    if (secondSortArr[si] > firstSortArr[fi])
                    {
                        mergeList.Add(firstSortArr[fi]);
                        fi++;
                    }
                    else
                    {
                        mergeList.Add(secondSortArr[si]);
                        si++;
                    }
                }
                for (int i = fi; i < firstSortArr.Length; i++)
                {
                    mergeList.Add(firstSortArr[i]);
                }
            }

            return mergeList;
        }

        /// <summary>
        /// 默认重载测试数组
        /// </summary>
        /// <returns></returns>
        public List<int> MergeSortArrays()
        {
            return MergeSortArrays(firstArray, secondArray);
        }

        /// <summary>
        /// 重写ToString方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string ToArrString(List<int> list)
        {
            return string.Join(",", list);
        }

        /// <summary>
        /// 将制定字符串反转
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public string ReverseStr(string sourceStr)
        {
            Stack<char> stack = new Stack<char>();
            string result = string.Empty;
            foreach (char item in sourceStr)
            {
                stack.Push(item);
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }

        #endregion

    }

    public class User
    {
        public User() { }

        public User(int id, string name, string cellphone) 
        {
            this.Id = id;
            this.Name = name;
            this.Cellphone = cellphone;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Cellphone { get; set; }
    }
}
