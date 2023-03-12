using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals.AbstractClasses;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private HashSet<string> eatenFood = new HashSet<string>()
        {
            "Vegetable",
            "Fruit",
            
        };
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            EatenFoods = eatenFood;
        }
        public override string ProduceSound()
        {
            return "Squeak";

        }
        public override void Eat(IFood food)
        {
            base.Eat(food);

            Weight += food.Quantity * 0.10;
        }
    }
}
