using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class BMW : ICar
    {
        private int hp;
        private int fuelAmmount;
        public BMW(int hp,int fuelAmmount)
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
