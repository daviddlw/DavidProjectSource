using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidTest
{
    /// <summary>
    /// 汽车类
    /// </summary>
    public class Car
    {
        public delegate void CarMaintenanceDelegate(Car c);
        public delegate Car ObtainVehicalDelegate();

        #region 构造方法

        public Car()
        {
            this.Name = string.Empty;
            this.MaxSpeed = 0;
            this.CurrentSpeed = 0;
            this.IsDirty = false;
            this.ShouldRotate = false;
        }

        public Car(string name, int max, int current, bool washCar, bool rotateTires)
        {
            this.Name = name;
            this.MaxSpeed = max;
            this.CurrentSpeed = current;
            this.IsDirty = washCar;
            this.ShouldRotate = rotateTires;
        }

        #endregion

        public string Name { get; set; }

        public int MaxSpeed { get; set; }

        public int CurrentSpeed { get; set; }

        public bool IsDirty { get; set; }

        public bool ShouldRotate { get; set; }

    }

    /// <summary>
    /// 车库类
    /// </summary>
    public class Garage
    {
        private List<Car> theCars = new List<Car>();

        public Garage()
        {
            this.theCars.Add(new Car("Viper", 100, 0, true, false));
            this.theCars.Add(new Car("Fred", 150, 0, false, false));
            this.theCars.Add(new Car("Viper", 200, 0, false, true));
        }

        public void ProcessCars(Car.CarMaintenanceDelegate proc)
        {
            Console.WriteLine("*****Calling {0}******", proc.Method);

            if (proc.Target != null)
                Console.WriteLine("=> Target: {0}", proc.Target);
            else
                Console.WriteLine("=> Target is a static method}");

            foreach (Car car in theCars)
            {
                Console.WriteLine("\n=> Processing a Car");
                proc(car);
            }
        }
    }

    /// <summary>
    /// 服务部门类
    /// </summary>
    public class ServiceDepartment
    {
        
        public void WashCar(Car car)
        {
            if (car.IsDirty)
                Console.WriteLine("=> Cleaning a car");
            else
                Console.WriteLine("=> This car is already clean");
        }

        public void RotateTires(Car car)
        {
            if (car.ShouldRotate)
                Console.WriteLine("=> Tires have been rotated");
            else
                Console.WriteLine("=> Don't need to rotate");
        }
    }

    /// <summary>
    /// 竞技车类
    /// </summary>
    public class SportsCar : Car
    {
        public SportsCar() { }
    }

    public class DelegateVariance
    {
        public static Car GetBasicCar()
        { return new Car(); }

        public static SportsCar GetSportsCar()
        { return new SportsCar(); }
    }
}
