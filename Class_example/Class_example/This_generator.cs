using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    class This_generator
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
