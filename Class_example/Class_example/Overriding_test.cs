using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    class Overriding_test
    {

    }

    class ArmorSuite
    {
        public virtual void Init()
        {
            Console.WriteLine("Normal Armor");
        }

        public void shoot()
        {
            Console.WriteLine("No equipped weapon");
        }
    }

    class IronMan: ArmorSuite
    {
        public override void Init()
        {
            base.Init();
            Console.WriteLine("IronMan Armor:: Repulsor Rays Armed");
        }

        public new void shoot()
        {
            Console.WriteLine("Beam~~~~~~~");
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Double-Barrel Cannons Armed");
            Console.WriteLine("Micro_Rocket Launcher Armed");
        }

        public new void shoot()
        {
            Console.WriteLine("Boom!!!!!!");
        }
    }
}
