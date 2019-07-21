using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    class Derived : Base
    {
        public Derived(string name, int age) : base(name, age)
        {
            Console.WriteLine($"I'm Derived() Class :: name, age :: {this.name}, {this.age}");
        }

        ~Derived()
        {
            Console.WriteLine($"~Derived() Class Bye Bye~~ :: name, age :: {this.name}, {this.age}");
        }
    }
}
