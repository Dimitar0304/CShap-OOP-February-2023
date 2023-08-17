using FactoryMethodExample2.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodExample2.Models
{
    public class AudiMechanic : IMechanic
    {
        public void CreateCar()
        {
            Console.WriteLine("Creating Audi");
        }
    }
}
