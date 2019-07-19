using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_example
{
    class Product
    {
        private int price = 100;

        public ref int GetPrice()
        {
            return ref this.price;
        }

        public void PrintPrice()
        {
            Console.WriteLine($"Price :{price}");
        }
    }
}
