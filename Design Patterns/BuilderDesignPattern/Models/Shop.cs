using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Models
{
    public class Shop
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildDoors();
            
            vehicleBuilder.BuildWheels();

            vehicleBuilder.BuildEngine();

            vehicleBuilder.BuildFrame();
        }
    }
}
