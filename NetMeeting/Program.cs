using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetMeeting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rand10 rand10 = Rand10.GetInstance();
            //long total = 9999999;
            ////记录1~10的数产生的次数  
            //int[] numArray = new int[10];
            //for (long i = 0; i < total; i++)
            //{
            //    int randomNumber = rand10.Next();
            //    numArray[randomNumber - 1]++;
            //}
            ////打印产生各数的概率  
            //for (int i = 0; i < numArray.Length; i++)
            //{
            //    Console.WriteLine(string.Format("产生{0}的概率是:{1:0.00000}", i + 1, (Double)numArray[i] / total));
            //}

            int a = 65, b = 113;

            a = a - b;
            b = a + b;
            a = b - a;

            Console.WriteLine(a);
            Console.WriteLine(b);

            Console.ReadLine();
        }
    }
    //1~7的随机数产生类  
    public class Rand7
    {
        private static Rand7 _rand7;
        private readonly Random _random = new Random();
        private Rand7()
        {

        }
        public static Rand7 GetInstance()
        {
            if (_rand7 == null)
            {
                _rand7 = new Rand7();
            }
            return _rand7;
        }
        //获得随机数  
        public int Next()
        {
            return _random.Next(1, 8);
        }
    }

    //1~10的随机数产生类  
    public class Rand10
    {
        private static Rand10 rand10;
        private Rand7 _rand7 = Rand7.GetInstance();
        private Rand10()
        {

        }
        public static Rand10 GetInstance()
        {
            if (rand10 == null)
            {
                rand10 = new Rand10();
            }
            return rand10;
        }
        //获得随机数  
        public int Next()
        {
            int num;
            //均匀产生1、 2 、3、4、5  
            while (true)
            {
                num = _rand7.Next();
                if (num <= 5)
                    break;
            }

            while (true)
            {
                int n = _rand7.Next();
                if (n == 4)
                    continue;
                //n大于4的数字有5、6、7，因为是由Rand7产生的，所以概率均匀  
                if (n > 4)
                    //因为num只可取值1、2、3、4、5并且取值概率均匀，num*2可得2、4、6、8、10也概率均匀  
                    num *= 2;
                //n小于4的数字有1、2、3，因为是由Rand7产生的，所以概率均匀  
                else
                    //因为num只可取值1、2、3、4、5并且取值概率均匀，num*2-1可得1、3、5、7、9也概率均匀  
                    num = num * 2 - 1;
                break;
            }
            return num;
        }
    }
}