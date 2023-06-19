using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    abstract public class Car
    {
        public Car(string id ,string model, int hp)
        {
            Id = id;
            Hp = hp;
            Model = model;
        }
        public string Id { get; set; }
        public int Hp { get; set; }
        public string Model { get; set; }
    }
}
