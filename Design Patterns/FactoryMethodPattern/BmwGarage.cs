using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class BmwGarage : Garage
    {
       

        public override Car CreateCar(string id, string model, int hp)
        {
            return new Bmw(id, model, hp);
        }
    }
}
