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

        private int getterA()
        {
            return this.a;
        }
    }
}
