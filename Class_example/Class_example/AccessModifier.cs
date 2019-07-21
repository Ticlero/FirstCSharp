using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_example
{
    class AccessModifier
    {
        protected int temperature;

        public void SetTemperature(int temperature)
        {
            if(temperature < -5 || temperature > 42)
            {
                throw new Exception($"{temperature}is Out of temperature range");
            }
            this.temperature = temperature;
        }

        internal void TurnOnWater()
        {
            Console.WriteLine($"Turn on water : {this.temperature}");
        }
    }
}
