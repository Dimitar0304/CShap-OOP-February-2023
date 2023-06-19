

using FactoryMethodPattern;

Garage[] garage = new Garage[3];

garage[0] = new BmwGarage();
garage[1] = new AudiGarage();
garage[2] = new MercedessGarage();

Car car = garage[0].CreateCar("01","E60",400);
Console.WriteLine(car.GetType().Name);

