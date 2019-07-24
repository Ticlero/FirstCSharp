using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Concept
{
    class MyException : Exception
    {

        public MyException()
        {

        }

        public MyException(string msg) : base(msg)
        {

        }

        public object Argument
        {
            get;
            set;
        }

        public string Range
        {
            get;
            set;
        }

    }
}
