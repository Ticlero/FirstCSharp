using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_example
{
    class Calcul_tool
    {
        private int a = 0;
        private int b = 0;
        
        public Calcul_tool()
        {

        }
        public Calcul_tool(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int Plus()
        {
            return this.a + this.b;
        }

        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus()
        {
            return this.a - this.b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }

        public void Swap(ref int a, ref int b) //참조애 의한 전달 키워드 ref
        {
            int temp = a;
            a = b;
            b = temp;
        } 

        public void Swap(int a, int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        
        public void Divide(int a, int b, ref int quotient, ref int remainder) //ref 대신 out 키워드를 사용하게되면 출력 전용 매개변수를 만들 수 있음
        {
            quotient = a / b;
            remainder = a % b;
        }
        
        public void Divide_2(int a, int b, out int quotient, out int remainder) //ref 대신 out 키워드를 사용하게되면 출력 전용 매개변수를 만들 수 있음
        {
            quotient = a / b;
            remainder = a % b;
        }

        public int Sum(params int[] args)
        {
            Console.Write("Summing...");
            int sum = 0;
            foreach (int elements in args)
            {
                Console.Write(elements + ", ");
                sum += elements;
            }
            Console.WriteLine();
            return sum;
        } //가변길이의 매개변수를 만들기 위한 키워드 'params'

        private int getterA()
        {
            return this.a;
        }
    }
}
