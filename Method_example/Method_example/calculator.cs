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

        }
    }
}
