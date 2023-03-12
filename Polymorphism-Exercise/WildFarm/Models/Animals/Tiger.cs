using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Animals.AbstractClasses;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private HashSet<string> eatenFood = new HashSet<string>()
        {

            "Meat"

        };

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            EatenFoods = eatenFood;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
        public override void Eat(IFood food)
        {
            base.Eat(food);

            Weight += food.Quantity * 1.00;
        }
    }
}
