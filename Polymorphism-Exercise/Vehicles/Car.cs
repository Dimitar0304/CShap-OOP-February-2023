using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption = fuelConsumption+0.9;
            FuelQuantity = fuelQuantity;
        }

        public override double FuelQuantity { get; set; }
        public override double FuelConsumption { get ; set ; }

        public override double Drive(double kilometers)
        {
            double result = 0;

            if (FuelConsumption * kilometers <= FuelQuantity)
            {

                FuelQuantity -= FuelConsumption * kilometers;
                result = kilometers;

            }
            else
            {
                throw new ArgumentException("Car needs refueling");
            }
            return result;
        }

        public override void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }
    }
}
