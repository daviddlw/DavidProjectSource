using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace DavidWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    // netsh http add urlacl url=http://+:8732/DavidWCF/DavidTest/ sddl="D:(A;;GX;;;LS)"
    // netsh http delete urlacl url=http://+:8732/DavidWCF/DavidTest/ sddl="D:(A;;GX;;;LS)"
    public class DavidService : IDavidService
    {
        #region 私有变量

        private List<Student> studentLs = new List<Student>();

        #endregion

        #region 构造方法

        public DavidService()
        {
            studentLs.AddRange(new List<Student>() {
                new Student(){ Id=1, Name="David", Age=25 },
                new Student(){ Id=2, Name="Micheal", Age=30 },
                new Student(){ Id=3, Name="Candy", Age=18 },
            });
        }

        #endregion

        #region 公共方法

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Minus(int x, int y)
        {
            return x - y;
        }

        public int Mutiply(int x, int y)
        {
            return x * y;
        }

        public double Divide(int x, int y)
        {
            return y == 0 ? 0 : Math.Round((double)x / y, 4);
        }

        public Student GetStudent(int Id)
        {
            return studentLs.FirstOrDefault(n => n.Id == Id);
        }

        public byte[] GetFile()
        {
            return GetFile(string.Empty);
        }

        public byte[] GetFile(string filename)
        {
            try
            {
                string path = @"J:\DavidTest\测试图片\杭州攻略.pdf";
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                byte[] fileBuffer = new byte[fs.Length];
                //MemoryStream ms = new MemoryStream(fileBuffer);
                //ms.Read(fileBuffer, 0, fileBuffer.Length);
                fs.Read(fileBuffer, 0, fileBuffer.Length);
                //设置当前流的位置为流的开始
                fs.Seek(0, SeekOrigin.Begin);
                fs.Close();
                return fileBuffer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
