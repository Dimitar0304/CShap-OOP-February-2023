using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class LeutenantGeneral : Private
    {
        public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, Private[] privates) : base(id, firstName, lastName, salary)
        {
            Privates = new List<Private>(privates);
        }

        public List<Private> Privates { get; set ; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}");
            sb.AppendLine("Privates:");
            foreach (var item in Privates)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
