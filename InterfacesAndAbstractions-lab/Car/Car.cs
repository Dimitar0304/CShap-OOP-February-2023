using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Car : ICar
    {
        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get ; set ; }
        public string Color { get ; set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
