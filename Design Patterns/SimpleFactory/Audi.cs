using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class Audi : ICar
    {
        private int hp;
        private int fuelAmmount;
        public Audi(int hp,int fuelAmmount)
        {
            this.hp = hp;
            this.fuelAmmount = fuelAmmount;
        }
        public int FuelAmount()
        {
            return fuelAmmount;
        }

        public int GetHp()
        {
            return hp;
        }
    }
}
