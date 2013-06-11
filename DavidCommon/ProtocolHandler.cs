using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DavidCommon
{
    /// <summary>
    /// 文件接收与发送协议解析类
    /// </summary>
    public class ProtocolHandler
    {
        #region 私有变量

        private string partialProtocol = string.Empty;

        #endregion

        #region 构造方法

        public string[] GetProtocol(string input)
        {
            return GetProtocol(input, null);
        }

        public string[] GetProtocol(string input, List<string> outputLs)
        {
            if (outputLs == null)
                outputLs = new List<string>();

            if (string.IsNullOrEmpty(input))
                return outputLs.ToArray();

            if (!string.IsNullOrEmpty(partialProtocol))
                input = input + partialProtocol;

            string pattern = "(^<protocol>.*?</protocol>)";

            if (Regex.IsMatch(input, pattern))
            {
                string match = Regex.Match(input, pattern).Groups[0].Value;
                outputLs.Add(match);
                partialProtocol = string.Empty;

                //截取多余的协议部分xml递归解析
                if (input.Length >= match.Length)
                    input = input.Substring(match.Length);

                GetProtocol(input, outputLs);
            }
            else
            {
                partialProtocol = input;
            }

            return outputLs.ToArray();
        }

        #endregion
    }
}
