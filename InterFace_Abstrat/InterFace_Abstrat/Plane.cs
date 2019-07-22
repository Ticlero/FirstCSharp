using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace_Abstrat
{
    class Plane : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Fly~~ Fly~~");
        }
    }
}
