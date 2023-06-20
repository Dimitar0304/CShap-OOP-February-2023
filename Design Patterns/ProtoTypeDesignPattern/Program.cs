

using ProtoTypeDesignPattern.Models;

CarManager carManager = new CarManager();

Car car = new Car(150,2000,"black");

carManager[car] = new Car(150, 2000, "blackS3");


Car colnedCar = carManager[car].Clone() as Car;
Console.WriteLine(colnedCar.ToString());