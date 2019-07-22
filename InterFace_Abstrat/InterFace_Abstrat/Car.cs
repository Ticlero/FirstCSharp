using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace_Abstrat
{
    class Car:IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Run~ Run~");
        }
    }
}
