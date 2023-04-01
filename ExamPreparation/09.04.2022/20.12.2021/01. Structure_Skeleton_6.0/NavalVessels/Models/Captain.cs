using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private List<IVessel> vessels;
        public Captain(string fullName)
        {
            FullName = fullName;
            vessels = new List<IVessel>();  
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                fullName = value;
            }
        }

        public int CombatExperience
        {
            get => combatExperience;
            set
            {
                if (value==0)
                {
                    value += 10;
                }
                combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels { get => vessels; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw  new NullReferenceException("Null vessel cannot be added to the captain.");


            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {

            this.CombatExperience += 10;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels} vessels.");
            if (Vessels.Count > 0)
            {


                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
                return sb.ToString().Trim();
        }
    }
}
