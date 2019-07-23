using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFace_Abstrat
{
    interface IProperty
    {
        string ProductName
        {
            set;
            get;
        }
        string ProductValue
        {
            set;
            get;
        }
    }

    class Product : IProperty
    {
        private string productName;
        private string productValue;
        public string ProductName { get; set; }
        public string ProductValue { get; set; }

        public void print()
        {
            Console.WriteLine($"{this.ProductName}, {this.ProductValue}");
        }
    }

}
