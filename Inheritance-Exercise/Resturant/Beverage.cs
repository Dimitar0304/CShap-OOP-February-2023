using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Beverage:Product
    {
        public Beverage(string name,decimal price,double mililitres):base(name,price)
        {
            Milliliters = mililitres;
        }
        public double Milliliters { get; set; }
    }
}
