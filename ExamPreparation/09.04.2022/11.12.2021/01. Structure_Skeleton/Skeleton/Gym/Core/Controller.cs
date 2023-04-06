using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType!= "Boxer"&&athleteType!= "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            if (gym.GetType().Name== "BoxingGym"&&athleteType== "Weightlifter")
            {
                return "The gym is not appropriate.";
            }
            if (gym.GetType().Name == "WeightliftingGym" && athleteType == "Boxer")
            {
                return "The gym is not appropriate.";
            }
            IAthlete athlete = null;
            if (athleteType== "Boxer")
            {
                athlete = new Boxer(athleteName,motivation,numberOfMedals);
            }
            else
            {
                athlete = new Weightlifter(athleteName,motivation, numberOfMedals);
            }
            gym.AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType!= "BoxingGloves"&&equipmentType!= "Kettlebell")
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            IEquipment equipment = null;
            if (equipmentType== "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType!= "BoxingGym"&&gymType!= "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type.");
            }
            IGym gym = null;
            if (gymType== "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            return $"The total weight of the equipment in the gym {gymName} is {gym.EquipmentWeight:F2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }

            IEquipment equipment = null;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }
            gym.AddEquipment(equipment);
            return $"Successfully added {equipmentType} to {gymName}.";


        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.ToString());
            }
            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}";
        }
    }
}
