using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class MercedessGarage : Garage
    {
        public override Car CreateCar(string id, string model, int hp)
        {
            return  new Mercedess(id, model, hp);
        }
    }
}
