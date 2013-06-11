using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavidWCF
{
    public class Student
    {
        public Student() { }

        public Student(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Student Id: {0}, Student Name: {1}, Student Age: {2}", Id, Name, Age);
        }
    }
}
