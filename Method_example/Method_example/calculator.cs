using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Method_example
{
    class Calculator
    {
        static void Main(string[] args)
        {
            //print_04();
            WriteLine(print_05("Hello"));
           
        }

        static void print_01()
        {
            Product p = new Product();
            ref int pr = ref p.GetPrice(); //참조 반환 메소드
            int normal_pr = p.GetPrice();

            p.PrintPrice();
            Console.WriteLine($"Ref Price: {pr}");
            Console.WriteLine($"Normal Price: {normal_pr}");

            pr = 200; //참조반환 값을 받은 참조변수의 값을 바꾸면 Product p의 객체 내부의 값도 변환
            p.PrintPrice();
            Console.WriteLine($"Ref Price: {pr}");
            Console.WriteLine($"Normal Price: {normal_pr}");
        } //참조반환 메소드 예제

        static void print_02()
        {
            Calcul_tool ct = new Calcul_tool();
            WriteLine(ct.Plus(3, 4));
            WriteLine(ct.Minus(5, 2));

            int a = 3, b = 4;
            ct.Swap(a, b); //Call by Vaule
            WriteLine($"a={a} b={b}");
            ct.Swap(ref a, ref b); //Call by reference
            WriteLine($"a={a} b={b}");
        } //메소드 예제

        static void print_03()
        {
            Calcul_tool ct = new Calcul_tool();
            int quotient = 0;
            int remainder = 0;
            int c = 0, d = 0;


            WriteLine("ref를 통한 출력용 매개변수를 이용하여 값 반환");
            ct.Divide(5, 7, ref quotient, ref remainder);
            WriteLine($"ref::5 / 7= {quotient}({remainder})");

            WriteLine("out을 통한 출력용 매개변수를 이용하여 값 반환");
            ct.Divide_2(3, 4, out c, out d);
            WriteLine($"out::3 / 4= {c}({d})");
        }//출력 전용 매개변수 #01

        static void print_04()
        {
            Calcul_tool ct = new Calcul_tool();
            
            WriteLine("SUM: {0}",ct.Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
        }

        static string print_05(string input)
        {
            var arr = input.ToCharArray();

            for(int i=0; i< arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }

            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90)
                    return arr[i];
                else
                    return (char)(arr[i] + 32);
            }

            return new string(arr);
        }
    }
}
