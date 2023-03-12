using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals.AbstractClasses;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private HashSet<string> eatenFood = new HashSet<string>()
        {

            "Meat"

        };
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            EatenFoods = eatenFood;
        }
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
        public override void Eat(IFood food)
        {
            base.Eat(food);

            Weight += food.Quantity * 0.25;
        }
    }
}
