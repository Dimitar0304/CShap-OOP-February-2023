using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Models
{
    public class AnimalWorld
    {
        private Herbivore herbivore;
        private Carnivore carnivore;

        public AnimalWorld(ContinentFactory cf)
        {
            herbivore = cf.CreateHerbivore();
            carnivore = cf.CreateCarnivore();
        }
        public void FoodChain()
        {
            carnivore.Eat(herbivore);
        }
    }
}
