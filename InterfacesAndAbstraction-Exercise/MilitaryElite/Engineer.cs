using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string crop, Repair[] reparis) : base(id, firstName, lastName, salary, crop)
        {
            Repairs = new List<Repair>(reparis);
        }

        public List<Repair> Repairs { get ; set ; }
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            if (Crop == "Airforces" || Crop == "Marines")
            {
                
                sb.AppendLine($"Crops: {Crop}");
            }
            
            sb.AppendLine("Repairs:");
            foreach (var item in Repairs)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
