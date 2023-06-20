using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoTypeDesignPattern.Models
{
    public class CarManager
    {
        private Dictionary<Car,CarPrototype> cars= new Dictionary<Car, CarPrototype>();

        public CarPrototype this[Car car]
        {
            get { return cars[car]; }
            set { cars.Add(car, value); }
        }
    }
}
