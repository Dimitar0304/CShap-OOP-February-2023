using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals.AbstractClasses;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private HashSet<string> eatenFood = new HashSet<string>()
        {

            "Meat"

        };
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            EatenFoods = eatenFood;
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override void Eat(IFood food)
        {
            base.Eat(food);

            Weight += food.Quantity * 0.40;
        }
    }
}
