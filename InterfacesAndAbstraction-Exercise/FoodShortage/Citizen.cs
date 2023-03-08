using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public class Citizen :IBuyer
    {
        public Citizen(string name, int age, string id, string birthdayData)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthdayData = birthdayData;
            Food = 0;
        }

        public string Name { get; set ; }
        public int Age { get; set; }
        public string Id { get ; set ; }
        public string BirthdayData { get ; set ; }
        public int Food { get ; set ; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
