using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace_Abstrat
{
    class Main_Class
    {
        static void Main(string[] args)
        {
            //print_01(); //인터페이스 예제
            //print_02(); //인터페이스 다중 상속
            print_03();
        }

        static void print_01()
        {
            string input = "";
            while (true)
            {
                ClimateMonitor monitor;
                Console.Write("('0' 또는 '1')입력해 주세요>>");
                input = Console.ReadLine();
                if (input == "1")
                {
                    monitor = new ClimateMonitor(new FileLogger("MyLog.txt"));
                }
                else if (input == "0")
                {
                    monitor = new ClimateMonitor(new ConsoleLogger());
                }
                else
                    break;
                
                monitor.start();
            }
        }

        static void print_02()
        {
            Car car = new Car();
            Plane plane = new Plane();
            FlyingCar flyingcar = new FlyingCar();

            car.Run();
            plane.Fly();
            flyingcar.Run();
            flyingcar.Fly();
        }

        static void print_03()
        {
            Property p = new Property();
        }
    }
}
