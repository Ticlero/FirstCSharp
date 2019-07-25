using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using static System.Activator; //리플렉션을 이용하여 동적으로 인스턴스를 만들귀 휘한 클래스

namespace ReflectionANDAttribute
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //print_01();  //
            //print_02(); //리플렉션과 타입형의 메소드를 이용하여 객체(인스턴스) 내부 알아보기
            //print_03();
            //print_04();
            //print_05();
            //print_06();
            print_07();
        }

        static void print_01()
        {
            int a = 0;
            Type type = a.GetType();

            PrintInterfaces(type);
            PrintField(type);
            PrintMethods(type);
            PrintProperties(type);
            PrintConstructors(type);

        }

        static void print_02()
        {
            Profile p = new Profile();
            Type t = p.GetType();

            PrintInterfaces(t);
            PrintField(t);
            PrintMethods(t);
            PrintProperties(t);
            PrintConstructors(t);
            PrintMemebers(t);
        }

        static void print_03() //리플렉션을 이용하여 특정 형식의 인스턴스를 동적으로 만들고 인스턴스 내의 프로퍼티에 값 생성, 읽기 및 메소드 이용
        {
            Type type = typeof(Profile);
            Object profile = Activator.CreateInstance(type); //리플렉션을 이용하여 'Profile' 인스턴스 생성
            PropertyInfo name = type.GetProperty("Name"); //생성된 Profile 클래스 인스턴스에 프로퍼티 설정
            PropertyInfo job = type.GetProperty("Job");
            PropertyInfo age = type.GetProperty("Age");

            name.SetValue(profile, "장성현", null);
            job.SetValue(profile, "프로그래머", null);
            age.SetValue(profile, 28, null);

            Console.WriteLine($"{name.GetValue(profile)}, {job.GetValue(profile)}, {age.GetValue(profile)}");

            Console.WriteLine();
            MethodInfo printProperties = type.GetMethod("func01");
            printProperties.Invoke(profile, null);


        }

        static void print_04() //리플렉션을 이용하여 새로운 형식의 인스턴스 만들기
        {
            /*
             리플렉션을 이용하여 새로운 형식의 인스턴스 만들기
             5단계
             1. AssemblyBuilder를 이용하여 어셈블리 만들기
             2. ModuleBuilder를 이용하여 1에서서 생성한 어셈블리 안에 모듈 만들어 넣기
             3. TypeBuilder를 이용하여 2에서 생성한 모듈 안에 클래스(형식)을 만들어 넣기
             4. 3에서 생성한 클래스 안에 메소드나 프로퍼티를 만들어 넣기(MethodBuilder or PropertyBuilder 이용)
             5. 4에서 생상한 것이 메소드라면, ILGenerator를 이용해서 메소드 안에 CPU가 실행할 IL 명령 넣기
             
             ***어셈블리를 만들 때는 생성자가 없기 때문에 팩토리 클래스(객체 생성을 담당하는 클래스)를 이용하여 생성 - AppDomain의 DefineDynamicAssembly()***
             
             */

            AssemblyBuilder CalculatorAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("CalcAssembly"), AssemblyBuilderAccess.Run); //어셈블리만들기
            ModuleBuilder newModule = CalculatorAssembly.DefineDynamicModule("Calculator"); //어셈블리 안에 모듈만들기
            TypeBuilder newType = newModule.DefineType("Sum1to100");//모듈안에 클래스 만들기   //반환타입       //매개 변수
            MethodBuilder newMethod = newType.DefineMethod("Calculate", MethodAttributes.Public, typeof(int), new Type[0]); //클래스 안에 메소드 만들기

            ILGenerator generator = newMethod.GetILGenerator(); //메소드 실행하기
            generator.Emit(OpCodes.Ldc_I4, 1);
            for(int i=2; i<100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i);
                generator.Emit(OpCodes.Add);
            }
            generator.Emit(OpCodes.Ret); //계산스택에 있는 값을 반환
            newType.CreateType();

            object sum1to100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1to100.GetType().GetMethod("Calculate");
            Console.WriteLine(Calculate.Invoke(sum1to100, null));
        }

        static void print_05()
        {
            Attribute_Concept Attribute_ex = new Attribute_Concept();
            Attribute_ex.OldMethod();
            Attribute_ex.NewMethod();
        } //애트리뷰트 기본

        static void print_06()
        {
            Attribute_Concept ac = new Attribute_Concept();
            ac.SomeMethod();
        }

        static void print_07()
        {
            Type type = typeof(TestClass);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            Console.WriteLine("My Class change history");

            foreach(Attribute a in attributes)
            {
                History h = a as History;
                if(h!=null)
                {
                    Console.WriteLine("Ver:{0}, Worker:{1}, Change:{2}", h.Version, h.Worker, h.ChangeTime);
                }
            }
        }

        static void PrintInterfaces(Type type)
        {
            Console.WriteLine("----------interfaces--------------");
            Type[] interfacesType = type.GetInterfaces();
            foreach (Type i in interfacesType)
            {
                Console.WriteLine("Name{0}", i.Name);
            }
            Console.WriteLine();
        }

        static void PrintField(Type type)
        {
            Console.WriteLine("--------Field---------");
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                string accessLevel = "protected";
                if (field.IsPublic)
                    accessLevel = "public";
                else
                    accessLevel = "private";

                Console.WriteLine("Access:{0}, Type:{1}, Name:{2}", accessLevel, field.FieldType.Name, field.Name);
            }

            Console.WriteLine();

        }

        static void PrintMethods(Type type)
        {
            Console.WriteLine("-------------Methods------------");
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo m in methods)
            {
                Console.Write("Type: {0}, Name: {1}, Parameter:", m.ReturnType.Name, m.Name);
                ParameterInfo[] args = m.GetParameters();
                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write("{0}", args[i].ParameterType.Name);
                    if (i < args.Length - 1)
                    {
                        Console.Write(",");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        static void PrintProperties(Type type)
        {
            Console.WriteLine("-----------Properties------------");
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo p in properties)
            {
                Console.WriteLine("Type:{0}, Name:{1}", p.PropertyType.Name, p.Name);
            }
            Console.WriteLine();
        }

        static void PrintConstructors(Type type)
        {
            Console.WriteLine("---------------Constructors-------------");

            ConstructorInfo[] constructs = type.GetConstructors();
            foreach (ConstructorInfo c in constructs)
            {
                Console.WriteLine("Name:{0}, Type:{1}, Constructor: {2}", c.ReflectedType.Name, c.ReflectedType.GetType(), c);
            }
        } //클래스 생성자의 대한 정보

        static void PrintMemebers(Type type) //멤버는 클래스 내에 선언되어있는 또는 만들어져있는 모든 필드와 메소드 
        {
            Console.WriteLine("---------------Members----------------");
            MemberInfo[] m = type.GetMembers();
            foreach (MemberInfo eles in m)
            {
                Console.WriteLine("Type:{0}, Name:{1}", eles.GetType(), eles.Name);
            }
        }
    }

    class Profile
    {
        private int age; //필드 or 멤버
        private string name;
        private string job;

        public string Name { get; set; } = "";//프로퍼티
        public string Job { get; set; } = "";
        public int Age { get; set; } = 0;

        public Profile()
        {
            this.age = Age;
            this.name = Name;
            this.job = Job;
        }

        public void func01()
        {
            Console.WriteLine($"이름:{Name}, 직업:{Job}, 나이:{Age}");
        }

        public void func02()
        {

        }

        public void func03()
        {

        }

    }
}
