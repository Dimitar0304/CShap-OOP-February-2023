using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Pet : IBirthdayble
    {
        public Pet(string name, string birthdayData)
        {
            Name = name;
            BirthdayData = birthdayData;
        }

        public string Name { get; set; }
        public string BirthdayData { get ; set ; }
    }
}
