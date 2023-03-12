using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals.AbstractClasses;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private HashSet<string> eatenFood = new HashSet<string>() { "Meat","Vegetable" };

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            EatenFoods = eatenFood;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override void Eat(IFood food)
        {
            base.Eat(food);

            Weight += food.Quantity* 0.30;
        }
    }
}
