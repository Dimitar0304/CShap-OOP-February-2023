using AbstractFactory.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Models
{
    public class BmwFactory : ICarFactory
    {
        public IMechanic InitialiseMechanic()
        {
           return new BmwMechanic();
        }

        public ICar MakeCar()
        {
            return new Bmw();
        }
    }
}
