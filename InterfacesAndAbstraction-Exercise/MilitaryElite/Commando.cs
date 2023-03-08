using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier,ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string crop, Mission[] missions) : base(id, firstName, lastName, salary, crop)
        {
            Missions = new List<Mission>(missions); 
        }

        public List<Mission> Missions { get; set ; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            if (Crop == "Airforces" || Crop == "Marines")
            {

                sb.AppendLine($"Crops: {Crop}");
            }
            sb.AppendLine("Missions:");
            foreach (var item in Missions.Where(m=>m.State== "inProgress"))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim(); ;
        }
    }
}
