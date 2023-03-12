using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.AbstractClasses;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string[] lineOfInput)
        {
            string type = lineOfInput[0];
            string name = lineOfInput[1];
            double weight = double.Parse(lineOfInput[2]);

            if (type== "Owl")
            {
                return new Owl(name, weight, double.Parse(lineOfInput[3]));
            }
            else if (type=="Hen")
            {
                return new Hen(name, weight, double.Parse(lineOfInput[3]));
            }
            else if (type == "Mouse")
            {
                return new Mouse(name, weight, lineOfInput[3]);
            }
            else if (type=="Dog")
            {
                return new Dog(name, weight, lineOfInput[3]);
            }
            else if (type=="Cat")
            {
                return new Cat(name, weight, lineOfInput[3], lineOfInput[4]);
            }
            else if (type=="Tiger")
            {
                return new Tiger(name, weight, lineOfInput[3], lineOfInput[4]);
            }
            else
            {
                throw new ArgumentException("Invalid Type of Animal");
            }

        }


    }
}
