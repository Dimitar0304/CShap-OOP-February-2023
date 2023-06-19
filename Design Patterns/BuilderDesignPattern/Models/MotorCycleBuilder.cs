using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Models
{
    public class MotorCycleBuilder : VehicleBuilder
    {
        public override void BuildDoors()
        {
            Console.WriteLine("Motorcycle doors");
        }

        public override void BuildEngine()
        {
            Console.WriteLine("600cc");
        }

        public override void BuildFrame()
        {
            Console.WriteLine("Motorcycle frame");
        }

        public override void BuildWheels()
        {
            Console.WriteLine("Motorcycle wheels");
        }
    }
}
