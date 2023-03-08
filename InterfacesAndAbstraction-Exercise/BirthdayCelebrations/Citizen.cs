using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Citizen : IIdentityInCity,IBirthdayble
    {
        public Citizen(string name, int age, string id, string birthdayData)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthdayData = birthdayData;    
        }

        public string Name { get; set ; }
        public int Age { get; set; }
        public string Id { get ; set ; }
        public string BirthdayData { get ; set ; }
    }
}
