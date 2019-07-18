using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace example01
{
    class Program
    {
        static void Main(string[] args)
        {
            //print_01(); //기본 데이터 형식 - 정수
            //print_02();//0b & 0x 2진수와 16진수 표기법
            //print_03();
            //print_04(); //부동 소수 표현 형식
            //print_05(); //char 표현
            //print_06(); //string 표현
            //print_07(); //bool 형식
            //print_08(); //object 형식
            //print_09(); // 박싱과 언박싱
            //print_10(); //크기가 다른 정수형 타입의 형 변환
            //print_11(); //부동 소수점 float, double의 형 변환
            //print_12(); //부호가 있는 정수와 없는 정수
            //print_13(); //부동 소수점 형식과 정수형식 간의 변환
            //print_14(); //String 과 정수형 표현식 간의 변환
            //print_15(); //상수
        }

        static void print_01()
        {
            sbyte a = -10;
            byte b = 40;

            WriteLine($"a={a}, b = {b}");

            short c = -30000;
            ushort d = 60000;

            WriteLine($"c = {c}, d = {d}");

            int e = -1000_000; // '_' 는 자릿수 구분자
            uint f = 3_0000_0000;

            WriteLine($"e = {e}, f = {f}");

            long g = -5000_0000_0000;
            ulong h = 200_0000_0000_0000_0000;

            WriteLine($"g = {g}, h = {h}");
        }

        static void print_02()
        {
            byte a = 240;
            WriteLine($"a = {a}");

            byte b = 0b1111_0000;
            WriteLine($"b = {b}");

            byte c = 0xF0;
            WriteLine($"c = {c}");

            uint d = 0x1234_abcd;
            WriteLine($"d = {d}");
        }

        static void print_03()
        {
            WriteLine("부호 정수");
            byte c = 1;
            sbyte d = (sbyte)c;
            WriteLine($"c = {c}");
            WriteLine($"d = {d}");

            WriteLine("\n오버 플로우 & 언더 플로우");
            int a = int.MaxValue;
            WriteLine($"a = {a}");

            int b = a + 1;
            WriteLine($"b = {b}");
        }

        static void print_04()
        {
            float a = 3.145_9265_3589_7932_3846_2643_3832_79f;
            double b = 3.145_9265_3589_7932_3846_2643_3832_79;
            decimal c = 3.145_9265_3589_7932_3846_2643_3832_79m;

            WriteLine(a);
            WriteLine(b);
            WriteLine(c);
        }

        static void print_05()
        {
            char a = '안';
            char b = '녕';
            char c = '하';
            char d = '세';
            char e = '요';
            Write(a);
            Write(b);
            Write(c);
            Write(d);
            Write(e);
            WriteLine();
        }

        static void print_06()
        {
            string a = "안녕하세요?";
            string b = "장성현입니다.";

            WriteLine(a);
            WriteLine(b);

        }

        static void print_07()
        {
            bool a = true;
            bool b = false;

            WriteLine(a);
            WriteLine(b);
        }

        static void print_08()
        {
            object a = 123;
            object b = 3.141592653589793238462643383279m;
            object c = true; 
            object d ="안녕하세요";

            WriteLine(a);
            WriteLine(b);
            WriteLine(c);
            WriteLine(d);

        }

        static void print_09()
        {
            int a = 123;
            object b = (object)a; //a에 담긴 값을 박싱하여 힙에 저장
            int c = (int)b; //b에 담긴 값을 언박싱 하여 스택에 저장

            WriteLine(a);
            WriteLine(b);
            WriteLine(c);

            double x = 3.1414213;
            object y = x;
            double z = (double)y;

            WriteLine(x);
            WriteLine(y);
            WriteLine(z);
        }

        static void print_10()
        {
            sbyte a = 127;
            WriteLine($"a = {a}");

            int b = (int)a;
            WriteLine($"b = {b}");

            int x = 128;
            WriteLine($"x = {x}");

            sbyte y = (sbyte)x;
            WriteLine($"y = {y}");
        }

        static void print_11()
        {
            float a = 69.6875f;
            WriteLine("a : {0}", a);

            double b = (double)a;
            WriteLine("b : {0}", b);

            WriteLine("69.6875 == b : {0}", 69.6875 == b);

            float x = 0.1f;
            WriteLine("x : {0}", x);

            double y = (double)x;
            WriteLine("y : {0}", y);

            WriteLine("0.1 == y : {0}", 0.1 == y);
        }

        static void print_12()
        {
            int a = 30;
            WriteLine("a = {0}", a);

            uint b = (uint)a;
            WriteLine("b = {0}", b);

            int x = -30;
            WriteLine("x = {0}", x);

            uint y = (uint)x;
            WriteLine("y = {0} - underflow", y);

        }

        static void print_13()
        {
            float a = 0.9f;
            int b = (int)a;
            WriteLine($"b = {b}");

            float c = 1.1f;
            int d = (int)c;
            WriteLine($"d = {d}");

        }

        static void print_14()
        {
            int a = 123;
            string b = a.ToString();
            WriteLine($"int a.ToString b = {b}");

            float c = 3.14f;
            string d = c.ToString();
            WriteLine($"float c.ToString d = {d}");

            string e = "123456";
            int f = Convert.ToInt32(e);
            int g = int.Parse(e);
            WriteLine($"string e Convert.ToInt32 f = {f}");
            WriteLine($"string e int.Parse g = {g}");

            string h = "1.2345";
            float i = float.Parse(h);
            WriteLine($"string h float.Parse i = {i}");
        }

        static void print_15()
        {
            const int MAX_INT = int.MaxValue;
            const int MIN_INT = int.MinValue;

            Console.WriteLine(MAX_INT);
            Console.WriteLine(MIN_INT);
        }
    }

   
}
