using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color,int battery) : base(model, color)
        {
            Battery = battery;
        }

        public int Battery { get ; set; }
    }
}
