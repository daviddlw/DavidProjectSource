using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace DavidMeeting
{
    public class BaseA
    {
        public static MyTest a1 = new MyTest("a1");
        public MyTest a2 = new MyTest("a2");
        static BaseA()
        {
            MyTest a3 = new MyTest("a3");
        }
        public BaseA()
        {
            MyTest a4 = new MyTest("a4");
        }
        public virtual void MyFun()
        {
            MyTest a5 = new MyTest("a5");
        }
    }

    public class BaseB : BaseA
    {
        public static MyTest b1 = new MyTest("b1");
        public MyTest b2 = new MyTest("b2");
        static BaseB()
        {
            MyTest b3 = new MyTest("b3");
        }
        public BaseB()
        {
            MyTest b4 = new MyTest("b4");
        }
        public new void MyFun()
        {
            MyTest b5 = new MyTest("b5");
        }
    }

    public class MyTest
    {
        public MyTest(string info)
        {
            Console.WriteLine(info);
        }
    }

    public class DavidTest
    {
        Dictionary<string, HashSet<string>> fileRecords = new Dictionary<string, HashSet<string>>();
        public static void FindXmlNode()
        {
            string path = @"H:\DavidTest\DavidMeeting\test.xml";
            XElement root = XElement.Load(path);
            //var attrs = root.Elements("item").Attributes("id");
            //var aa = root.Elements("item").FirstOrDefault(n => n.Attribute("id").ToString() == "totid");
            //string searchVal = root.Elements("item").FirstOrDefault(n => n.Attribute("id").ToString() == "totid").Value;

            var searchObj = from ele in root.Elements("item").Attributes("id")
                            where ele.Value == "totid"
                            select ele.Parent;

            Console.WriteLine(searchObj.First().Value);
        }

        /// <summary>
        /// 递归查找文件
        /// </summary>
        /// <param name="path"></param>
        public Dictionary<string, HashSet<string>> FindFile(string path)
        {
            if (Directory.Exists(path) && Directory.GetDirectories(path).Length > 0)
            {
                foreach (var directoryPath in Directory.GetDirectories(path))
                {
                    FindFile(directoryPath);
                }
            }
            else
            {
                if (!fileRecords.ContainsKey(path))
                    fileRecords.Add(path, new HashSet<string>());

                if (Directory.Exists(path) && Directory.GetFiles(path).Length > 0)
                {
                    foreach (var filePath in Directory.GetFiles(path))
                    {
                        if (File.Exists(filePath))
                        {
                            fileRecords[path].Add(new FileInfo(filePath).Name);
                        }
                    }
                }
                else
                {
                    //本来就是个文件
                    fileRecords[path].Add(new FileInfo(path).Name);
                }
            }

            return fileRecords;
        }

        /// <summary>
        /// 打开Record
        /// </summary>
        /// <param name="records"></param>
        public void ShowRecords(Dictionary<string, HashSet<string>> records)
        {
            try
            {
                string record_path = @"H:\records.txt";
                FileStream fs;
                if (!File.Exists(record_path))
                    fs = File.Create(record_path);
                else
                {
                    File.Delete(record_path);
                    fs = File.Create(record_path);
                }

                StreamWriter sw = new StreamWriter(fs);

                foreach (KeyValuePair<string, HashSet<string>> item in records)
                {
                    sw.WriteLine("目录名：{0}", item.Key);
                    foreach (string file in item.Value)
                    {
                        sw.WriteLine(file);
                    }
                }

                Console.WriteLine("文件生成成功！");

                fs.Close();
                fs.Dispose();
                GC.Collect();

                Process p = new Process();
                p.StartInfo.FileName = record_path;
                p.Start();
                p.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class DelegateTest
    {
        public delegate void ShowMessage(string msg);

        public delegate void ShowMessageEvent(string msg, EventArgs e);

        public event ShowMessageEvent ShowMessageEventHandler;

        public void ShowLowerMessage(string msg)
        {
            Console.WriteLine(msg.ToLower());
        }

        public void ShowUpperMessage(string msg)
        {
            Console.WriteLine(msg.ToUpper());
        }

        public void ShowLowerHandlerMessage(string msg, EventArgs e)
        {
            if (ShowMessageEventHandler.GetInvocationList().FirstOrDefault(n => n.Method.Name == "ShowLowerHandlerMessage") != null)
            {
                Console.WriteLine(msg.ToLower());
            }
        }

        public void ShowUpperHandlerMessage(string msg, EventArgs e)
        {
            if (ShowMessageEventHandler.GetInvocationList().FirstOrDefault(n => n.Method.Name == "ShowUpperHandlerMessage") != null)
            {
                Console.WriteLine(msg.ToUpper());
            }
        }
    }

    public class TestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsStudent { get; set; }
    }


    public class TestModelListEquality : IEqualityComparer<TestModel>
    {
        public bool Equals(TestModel x, TestModel y)
        {
            return x.Id == y.Id && x.Name == y.Name && x.IsStudent == y.IsStudent;
        }

        public int GetHashCode(TestModel obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.ToString().GetHashCode();
            }
        }
    }
}
