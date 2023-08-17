using FactoryMethodExample2.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodExample2
{
    abstract public class Service
    {
        abstract protected IMechanic MakeCar();
        public void CreatingCar()
        {
            var car = this.MakeCar();
            car.CreateCar();
        }
    }
}
