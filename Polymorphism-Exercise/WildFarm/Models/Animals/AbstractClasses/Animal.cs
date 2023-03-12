using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals.AbstractClasses
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            EatenFoods = new HashSet<string>();
           
        }

        public string Name { get; private set; }

        public double Weight { get;  set; }

        public int FoodEaten { get;  set; }
        public HashSet<string> EatenFoods { get; set; }

        public virtual string ProduceSound()
        {
            return " ";
        }
        public virtual void Eat(IFood food)
        {
            if (!EatenFoods.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            FoodEaten += food.Quantity;
        }
    }
}
