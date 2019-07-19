using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Method_example
{
    class Calculator
    {
        static void Main(string[] args)
        {
            Calcul_tool ct = new Calcul_tool();
            WriteLine(ct.Plus(3,4));
            WriteLine(ct.Minus(5, 2));
        }
    }
}
