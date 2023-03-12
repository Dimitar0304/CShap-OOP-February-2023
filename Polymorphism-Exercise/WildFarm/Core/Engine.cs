using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private List<IAnimal> _animals;
        private List<IFood> _food;
        private IReader reader = new ConsoleReader();
        private IWriter writer = new ConsoleWriter();
        private IAnimalFactory animalFactory = new AnimalFactory();
        private IFoodFactory foodFactoy = new FoodFactory();

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactoy)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactoy = foodFactoy;
            _animals = new List<IAnimal>();
            _food = new List<IFood>();
        }

        public void Run()
        {
            string command = reader.ReadLine();
            while (command != "End")
            {
                string[] linesOfInput = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                _animals.Add(animalFactory.Create(linesOfInput));

                _food.Add(foodFactoy.CreateFood(foodInfo[0], int.Parse(foodInfo[1])));

                command = reader.ReadLine();
            }
            for (int i = 0; i < _animals.Count; i++)
            {
                    IAnimal currentAnimal = _animals[i];
                    IFood currentFood = _food[i];
                try
                {
                    currentAnimal.Eat(currentFood);
                    writer.WriteLine(currentAnimal.ProduceSound());

                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(currentAnimal.ProduceSound());
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var animal in _animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }
}
