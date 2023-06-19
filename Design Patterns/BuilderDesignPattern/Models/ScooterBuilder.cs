using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Models
{
    public class ScooterBuilder : VehicleBuilder
    {
        public override void BuildDoors()
        {
            Console.WriteLine("Scooter doors");
        }

        public override void BuildEngine()
        {
            Console.WriteLine("50cc");
        }

        public override void BuildFrame()
        {
            Console.WriteLine("Scooter frame");
        }

        public override void BuildWheels()
        {
            Console.WriteLine("Scooter wheels");
        }
    }
}
