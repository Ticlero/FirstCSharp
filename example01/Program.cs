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
            print_04(); //부동 소수 표현 형식
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
    }

   
}
