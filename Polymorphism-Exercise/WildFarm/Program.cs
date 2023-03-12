

using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IFoodFactory foodFactory = new FoodFactory();
IAnimalFactory animalFactory = new AnimalFactory();

IEngine engine = new Engine(reader, writer, animalFactory,foodFactory);
engine.Run();