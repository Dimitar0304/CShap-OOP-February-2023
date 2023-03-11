using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public  abstract double FuelQuantity { get; set; }
        public abstract double FuelConsumption { get; set; }

        public abstract void Refuel(double fuel);
        
        public abstract double Drive(double kilometers);
        

    }
}
