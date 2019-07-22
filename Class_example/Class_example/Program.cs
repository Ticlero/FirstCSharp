using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_example;
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
            //print_05(); //기반클래스와 파생클래스의 형 변환

            //print_06(); 
            /*overriding. 'virtual' 키워드를 통해 오버라이드 메소드 임을 명시. 파생클래스에서는 orride 키워드를 통해 오버라이딩
            또한 'virtual' 앞에 'sealed' 키워드를 넣게 되면 파생클래스에서 오버라이딩 하는 것을 막을 수 있다.*/

            //print_07(); //메소드 숨기기 파생클래스에서 기반 클래스의 메소드를 사용할 경우 new 키워드를 통해 재생성 가능
            //print_08(); //중첩 클래스 클래스 안에 클래스만들기
            //print_09(); //확장 메소드 - 기존 클래스의 기능을 확장
            //print_10(); // 구조체
            print_11();
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

        static void print_06()
        {
            ArmorSuite armorsuite = new ArmorSuite();
            armorsuite.Init();

            Console.WriteLine("\nCreating IronMan....");
            ArmorSuite ironman = new IronMan();
            ironman.Init();

            Console.WriteLine("\nCreating WarMachine.... ");
            ArmorSuite warmachine = new WarMachine();
            warmachine.Init();

        }

        static void print_07()
        {
            ArmorSuite armorsuite = new ArmorSuite();
            IronMan ironman = new IronMan();
            WarMachine warmachine = new WarMachine();

            armorsuite.shoot();
            ironman.shoot();
            warmachine.shoot();
        }

        static void print_08()
        {
            NestedClass config = new NestedClass();
            config.SetConfig("Version", "V 5.0");
            config.SetConfig("Size", "655,324 KB");

            Console.WriteLine(config.GetConfig("Version"));
            Console.WriteLine(config.GetConfig("Size"));

            config.SetConfig("Version", "V 5.0.1");
            Console.WriteLine(config.GetConfig("Version"));
        }

        static void print_09()
        {
            Console.WriteLine($"Squre 3 : {3.Squre()}");
            Console.WriteLine($"3^4 : {3.Power(4)}");
            string hello = "hello";
            Console.WriteLine(hello.Append(", world"));
        }

        static void print_10()
        {
            Point3D p3d1;
            p3d1.X = 10;
            p3d1.Y = 20;
            p3d1.Z = 30;
            Console.WriteLine(p3d1.ToString());

            Point3D p3d2 = new Point3D(100,200,300);
            Point3D p3d3 = p3d1;
            p3d3.Z = 400;

            Console.WriteLine(p3d2.ToString());
            Console.WriteLine(p3d3.ToString());
        }

        static void print_11()
        {
            var tuple = (100, 200); //튜플 - var 식별자 = (a,b,c,d....);
            var tuple2 = ("장성현", 28);
            Console.WriteLine($"tuple::({tuple.Item1}), ({tuple.Item2})");
            Console.WriteLine($"tuple2::({tuple2.Item1}), ({tuple2.Item2})");
            var tuple3 = (name: "바보", age: 28);
            Console.WriteLine($"tuple3::({tuple3.name}), ({tuple3.age})");

            var (n, a) = tuple2;//튜플 분해
            Console.WriteLine($"n:{n}, a:{a}");
            var (name, _) = tuple3; // '_' 는 필요없는 필드 무시
            Console.WriteLine($"name: {name}");

            var tset = (100, 200, 300);
            
        }

        struct Point3D
        {
            public int X, Y, Z;
            public Point3D(int x, int y, int z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            public override string ToString()
            {
                return string.Format($"{X}, {Y}, {Z}");
            }
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
