using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidCommon
{
    public class NetworkHelper
    {
        /// <summary>
        /// 随机生成文件路径（包含文件名）
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GenerateFilePathName(string filename)
        {
            return string.Format("{0}_{1}{2}{3}{4}", filename, DateTime.Now.Year, DateTime.Now.Hour < 10 ? string.Concat("0", DateTime.Now.Hour.ToString()) : DateTime.Now.Hour.ToString(), DateTime.Now.Minute, DateTime.Now.Millisecond);
        }
    }
}
