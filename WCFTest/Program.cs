using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCFTest.DavidWCFService;
using WCFTest;
using System.IO;

namespace WCFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IDavidService davidService = new DavidServiceClient();
            string[] paramArr;
            string input = string.Empty;
            do
            {
                Console.WriteLine("请输入你的选择。1-加法，2-减法，3-乘法，4-除法，5-Student对象，6-接收PDF，7-自定义，Q-退出");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input.Trim()))
                {
                    switch (input.ToInteger())
                    {
                        case (int)ConsoleTypeEnum.Add:
                            paramArr = GetInputParam();
                            Console.WriteLine("加法结果：" + davidService.Add(paramArr[0].ToInteger(), paramArr[1].ToInteger()));
                            break;
                        case (int)ConsoleTypeEnum.Minus:
                            paramArr = GetInputParam();
                            Console.WriteLine("减法结果：" + davidService.Minus(paramArr[0].ToInteger(), paramArr[1].ToInteger()));
                            break;
                        case (int)ConsoleTypeEnum.Mutiply:
                            paramArr = GetInputParam();
                            Console.WriteLine("乘法结果：" + davidService.Mutiply(paramArr[0].ToInteger(), paramArr[1].ToInteger()));
                            break;
                        case (int)ConsoleTypeEnum.Divide:
                            paramArr = GetInputParam();
                            Console.WriteLine("除法结果：" + davidService.Divide(paramArr[0].ToInteger(), paramArr[1].ToInteger()));
                            break;
                        case (int)ConsoleTypeEnum.Student:
                            {
                                Console.WriteLine("请输入需要返回的Student Id:\n");
                                int id = Console.ReadLine().ToInteger();
                                Student stu = davidService.GetStudent(id);
                                if (stu != null)
                                    Console.WriteLine("学生基本信息：学号-{0}，姓名-{1}，年龄-{2}", stu.Id, stu.Name, stu.Age);
                                else
                                    Console.WriteLine("没有匹配的学生信息");
                            } break;
                        case (int)ConsoleTypeEnum.PDF:
                            {
                                try
                                {
                                    byte[] fileBytes = davidService.GetFile();
                                    string outputPath = @"J:\DavidTest\WCF客户端接受文件夹\" + string.Format("David{0}{1}{2}{3}.pdf", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Second, DateTime.Now.Millisecond);
                                    FileStream fs = new FileStream(outputPath, FileMode.CreateNew, FileAccess.Write);
                                    fs.Write(fileBytes, 0, fileBytes.Length);
                                    fs.Flush();
                                    fs.Close();
                                    Console.WriteLine("文件接收完毕...");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("发生异常：{0}", ex.Message);
                                }

                            }; break;
                        case (int)ConsoleTypeEnum.Custom:
                            {
                                Console.WriteLine(davidService.OneWay("test"));
                                Console.WriteLine("执行到下一步");
                            };break;
                        default:
                            Console.WriteLine("选择有误，请重新选择...");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("不能输入空字符串！请重新输入...");
                }

            } while (input.ToUpper() != ConsoleKey.Q.ToString());
            Console.ReadKey();
        }

        private static string[] GetInputParam()
        {
            string[] arr;
            do
            {
                Console.WriteLine("请输入输入对应的参数x，y以逗号分隔\n");
                string paramInput = Console.ReadLine();
                arr = paramInput.ToSplitArray();
                if (arr.Length != 2)
                    Console.WriteLine("参数个数不正确...");
            } while (arr.Length != 2);
            return arr;
        }
    }
}
