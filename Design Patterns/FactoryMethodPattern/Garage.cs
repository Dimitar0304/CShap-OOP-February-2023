using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    abstract public class Garage
    {
        List<Car> cars = new List<Car>();
        public Garage()
        {
            
        }
        public List<Car> Cars { get { return cars; } }
        public abstract Car CreateCar(string id,string model,int hp);

    }
}
