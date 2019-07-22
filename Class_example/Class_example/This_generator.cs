using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    partial class This_generator //partial 키워드를 통해 클래스를 분할하여 관리 할 수 있음
    {
        private int a = 0, b = 0, c = 0;

        public This_generator()
        {
            this.a = 12345;
        }

        public This_generator(int b) : this() //This_generator()를 호출
        {
            //this.a = 12345;
            this.b = b;
        }

        public This_generator(int b, int c) : this(b) //This_generator(int b)를 호출
        {
            //this.a = 12345;
            //this.b = b;
            this.c = c;
        }      
    }

    partial class This_generator
    {
        public int GetA()
        {
            return this.a;
        }

        public int GetB()
        {
            return this.b;
        }

        public int GetC()
        {
            return this.c;
        }

    }
}
