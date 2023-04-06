using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
            EquipmentWeight = equipments.Sum(x => x.Weight);
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }
                name = value;
            }
        }


        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        private List<IEquipment> equipments;

        public ICollection<IEquipment> Equipment { get => equipments.AsReadOnly(); }

        private List<IAthlete> athletes;
        public ICollection<IAthlete> Athletes { get => athletes.AsReadOnly(); }




        private double equipmentWeight ;

        
        public double EquipmentWeight
        {
            get => equipmentWeight;
            private set { equipmentWeight = value; }
        }



        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count+1<=Capacity)
            {
                athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
           equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (athletes.Count == 0)
            {
                sb.AppendLine("No athletes");
            }
            else
            {
                sb.AppendLine($"{string.Join(", ", athletes)}");
            }
            sb.AppendLine($"Equipment total count: {equipments.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight} grams");
            return sb.ToString().Trim();
            
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
