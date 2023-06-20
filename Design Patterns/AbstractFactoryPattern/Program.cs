

using AbstractFactoryPattern.Models;

ContinentFactory africa = new AfricaContinent();

AnimalWorld animalWorld = new AnimalWorld(africa);
animalWorld.FoodChain();

ContinentFactory america = new AmericaContinent();
AnimalWorld americaAnimals = new AnimalWorld(america);
americaAnimals.FoodChain(); 
