using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Coffee:HotBeverage
    {
        public Coffee(string name,decimal price,double mililitres):base(name,price,mililitres)
        {
            
        }
        public double Coffeine { get; set; }
        private const decimal CoffeePrice = 3.5m;
        private const double CoffeeMilliliters = 50;
    }
}
