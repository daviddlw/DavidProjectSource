using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidTest
{
    /// <summary>
    /// 实现和调用自定义扩展方法
    /// </summary>
    public static class ExtensionMethod
    {
        public static string ToString(List<int> list)
        {
            return string.Join(",", list);
        }
    }
}
