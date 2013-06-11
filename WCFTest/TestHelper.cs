using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFTest
{
    public enum ConsoleTypeEnum
    {
        Add = 1,
        Minus,
        Mutiply,
        Divide,
        Student,
        PDF,
        Custom
    }

    public static class StringHelper
    {
        /// <summary>
        /// 转化为Int
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int ToInteger(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return 0;
            else
            {
                int result = 0;
                int.TryParse(val, out result);
                return result;
            }
        }

        /// <summary>
        /// 转化为
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string[] ToSplitArray(this string val)
        {
            if (string.IsNullOrEmpty(val))
                return new string[] { };
            else
            {
                if (val.Contains("，"))
                    val = val.Replace("，", ",");

                string[] ls = val.Split(',');
                return ls;
            }
        }
    }
}
