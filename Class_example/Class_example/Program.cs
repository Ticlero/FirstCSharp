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
            //print_01(); //class deep copy
            //print_02(); //this 생성자
            //print_03(); //접근제한자
            //print_04(); //상속 예제
            print_05();
        }

        static void print_01()
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

        static void print_02()
        {
            This_generator tg = new This_generator();
            Console.WriteLine($"This_Generator's a :: {tg.GetA()}");

            This_generator tg2 = new This_generator(0);
            Console.WriteLine($"This_Generator2's a,b ::{tg2.GetA()}, {tg2.GetB()}");

            This_generator tg3 = new This_generator(1, 0);
            Console.WriteLine($"This_Generator3's a,b,c ::{tg3.GetA()}, {tg3.GetB()}, {tg3.GetC()}");
        }

        static void print_03()
        {
            try
            {
                AccessModifier am = new AccessModifier();
                am.SetTemperature(32);
                am.TurnOnWater();

                am.SetTemperature(-2);
                am.TurnOnWater();

                am.SetTemperature(50);
                am.TurnOnWater();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void print_04()
        {
            Derived d = new Derived("jang", 28);
            d.BaseMethod();
        }

        static void print_05()
        {
            Mammal mammal = new Dog();
            Dog dog;

            if (mammal is Dog)
            {
                dog = (Dog)mammal;
                dog.Bark();
            }

            Mammal mammal2 = new Cat();
            Cat cat;
            cat = mammal2 as Cat;
            if (cat != null)
                cat.Meaw();


        }
    }


    class Mammal
    {
        public void Nurse()
        {
            Console.WriteLine("Nurse()");
        }
    }

    class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("Bark()");
        }
    }

    class Cat : Mammal
    {
        public void Meaw()
        {
            Console.WriteLine("Meaw()");
        }
    }
}
