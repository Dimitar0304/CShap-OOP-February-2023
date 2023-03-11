using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption = fuelConsumption+1.6;
            FuelQuantity = fuelQuantity;
        }

        public override double FuelQuantity { get ; set ; }
        public override double FuelConsumption { get ; set ; }

        public override double Drive(double kilometers)
        {
            double result = 0;

            if (FuelConsumption*kilometers<=FuelQuantity)
            {
                
                FuelQuantity -= FuelConsumption * kilometers;
                result = kilometers;
            return result;
                
            }
            else
            {
                throw new ArgumentException("Truck needs refueling");
            }
            
        }

        public override void Refuel(double fuel)
        {
            fuel = fuel * 0.95;

            FuelQuantity += fuel;
           
        }
    }
}
