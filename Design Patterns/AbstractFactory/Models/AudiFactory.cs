using AbstractFactory.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Models
{
    public class AudiFactory : ICarFactory
    {
        public IMechanic InitialiseMechanic()
        {
            return new AudiMechanic();
        }

        public ICar MakeCar()
        {
            return new Audi();
        }
    }
}
