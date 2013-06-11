using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DavidTest;
using System.Reflection;


namespace DavidTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 面试测试

            //User user = new User(1, "David", "1321918171");
            //Type userType = user.GetType();
            //Console.WriteLine("请输入要查看的属性：\n");
            //string input = Console.ReadLine();

            //switch (input)
            //{
            //    case "Id":
            //        int id = Convert.ToInt32(userType.GetProperty(input).GetValue(user, null));
            //        Console.WriteLine("Id:" + id);
            //        break;
            //    case "Name":
            //        string name = Convert.ToString(userType.GetProperty(input).GetValue(user, null));
            //        Console.WriteLine("name:" + name);
            //        break;
            //    case "Cellphone":
            //        string cellphone = Convert.ToString(userType.GetProperty(input).GetValue(user, null));
            //        Console.WriteLine("cellphone:" + cellphone);
            //        break;
            //    default:
            //        break;
            //}                     

            Interviewbase interview = new Interviewbase();
            Console.WriteLine(interview.ToArrString(interview.MergeSortArrays()));
            Console.WriteLine(ExtensionMethod.ToString(interview.MergeSortArrays()));
            Console.WriteLine(interview.ReverseStr("abcdefg"));

            #endregion

            #region 委托测试

            //Delegatebase.CalculateMethod delegatePlus = new Delegatebase.CalculateMethod(Delegatebase.Plus);
            //Delegatebase.CalculateMethod delegateMinus = new Delegatebase.CalculateMethod(Delegatebase.Minus);
            //Delegatebase.CalculateMethod delegateMutiply = new Delegatebase.CalculateMethod(Delegatebase.Mutiply);
            //Delegatebase.CalculateMethod delegateDivide = new Delegatebase.CalculateMethod(Delegatebase.Divide);

            //Console.WriteLine("Plus Result: {0}", delegatePlus(1, 2));
            //Console.WriteLine("Minus Result: {0}", delegateMinus(1, 2));
            //Console.WriteLine("Mutiply Result: {0}", delegateMutiply(1, 2));
            //Console.WriteLine("Divide Result: {0}", delegateDivide(1, 2));

            #endregion

            #region 委托进阶测试

            //Console.WriteLine("Advance Delete Test Begin:\n");

            //Garage garage = new Garage();
            //ServiceDepartment sd = new ServiceDepartment();

            //garage.ProcessCars(new Car.CarMaintenanceDelegate(sd.WashCar));
            //garage.ProcessCars(new Car.CarMaintenanceDelegate(sd.RotateTires));

            ////委托协变
            //Console.WriteLine("Delegate Convariance Begin:\n");
            //Car.ObtainVehicalDelegate obvd = new Car.ObtainVehicalDelegate(DelegateVariance.GetBasicCar);
            //Car c1 = obvd();
            //Console.WriteLine("Obtained a {0}", c1);

            //Car.ObtainVehicalDelegate obvdChild = new Car.ObtainVehicalDelegate(DelegateVariance.GetSportsCar);
            //SportsCar c2 = obvdChild() as SportsCar;
            //Console.WriteLine("Obtained a {0}", c2);

            #endregion     

            Console.ReadLine();
        }
    }
}
