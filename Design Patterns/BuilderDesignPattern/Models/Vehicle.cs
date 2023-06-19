using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Models
{
    public class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string,string> parts = new Dictionary<string,string>();
        public Vehicle(string vehicleType)
        {
            this._vehicleType = vehicleType;
        }
        public string this[string key]
        {
            get { return parts[key]; }
            set { parts[key] = value; }
        }
        public void Show()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Vehicle type: {_vehicleType}");
            Console.WriteLine($"Frame {parts["frame"]}");
            Console.WriteLine($"Engine {parts["engine"]}");
            Console.WriteLine($"#Wheels {parts["wheels"]}");
            Console.WriteLine($"#Doors {parts["doors"]}");
        }
    }
}
