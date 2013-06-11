using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace DavidMeeting
{
    public class EnumTest
    {
        #region 枚举测试

        public void GetEnumNameList(Type enumType)
        {
            List<string> resultLs = GetEnumLs(enumType);
            foreach (string item in resultLs)
            {
                Console.WriteLine(item);
            }
        }

        private List<string> GetEnumLs(Type enumType)
        {
            List<string> result = new List<string>();
            FieldInfo[] fieldInfos = enumType.GetFields();
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (fieldInfo.FieldType.IsEnum)
                {
                    object[] objs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    result.Add(((DescriptionAttribute)objs[0]).Description);
                }
            }

            return result;
        }

        #endregion       
    }

    public enum LinearTypeEnum
    {
        [Description("线性表")]
        LinearList = 0,

        [Description("链表")]
        LinkedList
    }
}
