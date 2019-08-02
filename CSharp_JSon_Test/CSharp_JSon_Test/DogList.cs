using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_JSon_Test
{
    class DogList
    {
        public List<Dog> Dogs
        {
            get;
            set;
        }

        public DogList()
        {
            this.Dogs = new List<Dog>();
        }
    }
}
