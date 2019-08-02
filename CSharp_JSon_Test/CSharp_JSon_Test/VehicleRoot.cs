using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_JSon_Test
{
    class VehicleRoot
    {
        public List<Vehicle> VehiclesList
        {
            get;
            set;
        }

        public VehicleRoot()
        {
            this.VehiclesList = new List<Vehicle>();
        }
    }
}
