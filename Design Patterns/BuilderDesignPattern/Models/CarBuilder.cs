using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Models
{
    public class CarBuilder : VehicleBuilder
    {
        public override void BuildDoors()
        {
            Console.WriteLine("Car doors");
        }

        public override void BuildEngine()
        {
            Console.WriteLine("5000cc");
        }

        public override void BuildFrame()
        {
            Console.WriteLine("Car frame");
        }

        public override void BuildWheels()
        {
            Console.WriteLine("Car wheels");
        }
    }
}
