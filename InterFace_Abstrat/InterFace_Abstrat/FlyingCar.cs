using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace_Abstrat
{
    class FlyingCar : IRunnable, IFlyable
    {
        private Car car = new Car();
        private Plane plane = new Plane();
        public void Fly()
        {
            plane.Fly();
        }

        public void Run()
        {
            car.Run();
        }
    }
}
