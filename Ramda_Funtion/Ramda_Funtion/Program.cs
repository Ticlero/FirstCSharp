using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Linq.Expressions;

namespace Ramda_Funtion
{
    delegate int Mydelegate(int a, int b);
    delegate void DoSomething();
    delegate string Concatenate(string[] args);
    class Program
    {
        //람다식은 무명함수를 좀 더 편하게 만들기 위한 기능
        static void Main(string[] args)
        {
            //print_01(); //람다식 기본형
            //print_02(); //문형 람다식 기본예            
            //print_03(args);//문형 람다식 예제

            //Func과 Action 대리자 선언을 생략해도 좋은!!
            //print_04();//Func 대리자 예시 - 반환값 유
            //print_05(); //Action 대리자 예시 - 반환값 무

            //식트리
            //print_06(); //식 트리는 데이터 보관용으로 만들어진 문법.

            //식 본문 멤버 - 식으로 이루어져 있는 멤버
            //print_07();

            //활용 예제
            print_08();
            print_09();
        }

        static public void print_01()
        {
            Mydelegate Calc_Plus = (int a, int b) => a + b; //람다시 기본 선언 형식 - ( 매개 변수 ) => 반환 값;
            Mydelegate Calc_Minus = (src, target) => src - target;
            WriteLine($"{3} - {4} = {Calc_Minus(3, 4)}");
        }

        public static void print_02()
        {
            DoSomething DoIt = () =>
            {
                WriteLine("무언가를 해서");
                WriteLine("출력해보자");
                WriteLine("문형 람다식을 이용하여 이렇게!!");
            };

            DoIt();
        }

        static void print_03(string[] args)
        {
            Concatenate concat = (msg) =>
            {
                string result = "";
                foreach (string eles in msg)
                {
                    result += eles;
                }
                return result;
            };

            WriteLine(concat(args));
        }

        static void print_04()
        {
            Func<int> func = () => 10;
            Func<int, int> func2 = (a) => a * 3;
            Func<int, int, int> func3 = (a, b) => a * b;


            Console.WriteLine(func());
            Console.WriteLine("\n" + func2(5));
            Console.WriteLine("\n" + func3(5, 5));


        }

        static void print_05()
        {
            int result = 0;
            Action act = () => Console.WriteLine("나는 Action 람다식 무명함수야!");
            act();

            Action<int> act2 = (x) =>
            {
                result = x * x;
            };
            Console.WriteLine($"{3}에 act2 무명 람다식 함수를 사용하면!! :: {result}");

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine("Action<T1, T2>({0},{1}) : {2}    ", x, y, pi);
            };
            act3(22.0, 7.0);
        }

        static void print_06() //1*2 + (x-y)를 만들기 위한 식트리
        {
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);

            Expression leftExp = Expression.Multiply(const1, const2);

            Expression param1 = Expression.Parameter(typeof(int)); // x
            Expression param2 = Expression.Parameter(typeof(int)); // y

            Expression rightExp = Expression.Subtract(param1, param2); // x-y

            Expression exp = Expression.Add(leftExp,rightExp); //1*2 + (x-y)

            Expression<Func<int, int, int>> expression = Expression<Func<int, int, int>>.Lambda<Func<int,int,int>>(
                exp, new ParameterExpression[] { (ParameterExpression)param1, (ParameterExpression)param2 });

            Func<int, int, int> func = expression.Compile();

            Console.WriteLine($"1*2 + (7-8) = {func(7, 8)}");

            Expression<Func<int, int, int>> exp2 = (a, b) => 1 * 2 + (a - b);
            
            Func<int, int, int> func2 = exp2.Compile();
            Console.WriteLine($"1*2 + (7-8) = {func2(7, 8)}");
        }

        static void print_07()
        {
            FriendList obj = new FriendList();

            obj.Add("Endy");
            obj.Add("ERIN");
            obj.Add("SHJ");
            obj.Add("JSK");
            obj.Add("HWK");
            obj.Add("JWK");

            Console.WriteLine($"obj.Capacity = {obj.Capacity}");
            obj.Capacity = 20;
            Console.WriteLine($"obj.Capacity = {obj.Capacity}");

            Console.WriteLine($"obj[0] = {obj[0]}");
            obj[0] = "TMB";
            obj.PrintAll();
        }

        static void print_08()
        {
            Func<int> func = () => 10;
            Func<int, int> func2 = (a) => a * 2;

            Console.WriteLine(func() + func2(30));
        }

        static void print_09()
        {
            int[] arr = { 11, 22, 33, 44, 55 };
            Action<int> act = (a) =>
            {
                Console.WriteLine(a * a);
            };

            foreach (int eles in arr)
            {
                act(eles);
            }
        }
    }
}
