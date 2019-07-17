using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("여러분, 안녕하세요?\n반갑습니다!");
                return;
            }
            Console.WriteLine("Hello, {0}!", args[0]);
        }
    }
}
