using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;

            Console.WriteLine("Shallow Copy");
            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                MyClass target = source;
                target.MyField2 = 30;

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }
            Console.WriteLine("Deep Copy");

            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                MyClass target = source.DeepCopy();
                target.MyField2 = 30;

                MyClass target2 = source.DeepCopy();
                target2.MyField2 = 40;

                Console.WriteLine($"{source.GetHashCode()} {source.MyField2}");
                Console.WriteLine($"{target.GetHashCode()} {target.MyField2}");
                Console.WriteLine($"{target2.GetHashCode()} {target2.MyField2}");
            }


        }
    }
}
