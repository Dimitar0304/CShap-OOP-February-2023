using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class CarFactory
    {
        public static ICar MakeBMW(int hp, int fuelAmmount)
        {
            return new BMW(hp, fuelAmmount);    
        }

        public static ICar MakeAudi(int hp, int fuelAmmount)
        {
            return new Audi(hp, fuelAmmount);
        }

    }
}
