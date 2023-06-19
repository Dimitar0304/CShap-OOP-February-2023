using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class AudiGarage : Garage
    {
        public override Car CreateCar(string id, string model, int hp)
        {
            return new Audi(id, model, hp);
        }
    }
}
