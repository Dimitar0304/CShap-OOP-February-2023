using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            interfaceStandards = new List<int>();
            BatteryLevel = batteryCapacity;
        }
        private string model;
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }
                model = value;
            }
        }

        private int batteryCapacity;
        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }
                batteryCapacity = value;
            }
        }

        private int batteryLevel;
        public int BatteryLevel { get => batteryLevel; private set { batteryLevel = value; } }

        public int ConvertionCapacityIndex { get; private set; }

        private List<int> interfaceStandards;
        public IReadOnlyCollection<int> InterfaceStandards { get => interfaceStandards.AsReadOnly(); }

        public  void Eating(int minutes)
        {
            while (BatteryLevel < BatteryCapacity&&minutes>0)
            {

                BatteryLevel +=this.ConvertionCapacityIndex;
                minutes--;
                if (BatteryCapacity==BatteryLevel)
                {
                    break;
                }
            }

        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel>=consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                
                return false;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryLevel -= supplement.BatteryUsage;
            BatteryCapacity-= supplement.BatteryUsage; 
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} {Model}: ");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            if (InterfaceStandards.Count==0)
            {
                sb.AppendLine("--Supplements installed: none");
            }
            else
            {
                sb.AppendLine($"--Supplements installed: {string.Join(" ",InterfaceStandards)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
