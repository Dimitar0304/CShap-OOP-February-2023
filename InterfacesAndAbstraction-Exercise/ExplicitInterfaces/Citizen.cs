using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Country = country;
            Name = name;
            Age = age;
        }

        public string Country { get ; set ; }
        public string Name { get ; set ; }
        public int Age { get; set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
         string IPerson.GetName()
        {
            return Name;
        }
    }
}
