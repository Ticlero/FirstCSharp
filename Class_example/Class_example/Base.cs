using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    class Base
    {
        protected string name;
        protected int age;
        public Base(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine($"I'm BaseClass's Generator :: name, age :: {this.name}, {this.age}");
        }

        ~Base()
        {
            Console.WriteLine($"Base() Bye Bye~ :: name, age :: {this.name}, {this.age}");
        }

        public void BaseMethod()
        {
            Console.WriteLine("I'm BaseClass :: 1");
        }
    }
}
