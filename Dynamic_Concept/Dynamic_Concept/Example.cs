using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Concept
{
    class Duck
    {
        public void Walk()
        {
            Console.WriteLine(this.GetType() + ".Walk");
        }

        public void Swim()
        {
            Console.WriteLine(this.GetType() + ".Swim");
        }

        public void Quack()
        {
            Console.WriteLine(this.GetType() + ".Quack");
        }
    }

    class Mallard : Duck
    { }

    class Robot
    {
        public void Walk()
        {
            Console.WriteLine(this.GetType() + "Robot().Walk");
        }

        public void Swim()
        {
            Console.WriteLine(this.GetType() + "Robot().Swim");
        }

        public void Quack()
        {
            Console.WriteLine(this.GetType() + "Robot().Quack");
        }
    }
}
