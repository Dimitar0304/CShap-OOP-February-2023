using Vehicles;


string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Car car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2])) ;

string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Truck truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
	if (command[0]== "Drive")
	{
		try
		{

		if (command[1]=="Car")
		{
            Console.WriteLine($"Car travelled {car.Drive(double.Parse(command[2]))} km");
        }
		else
		{
            Console.WriteLine($"Truck travelled {truck.Drive(double.Parse(command[2]))} km");
        }
		}
		catch (Exception ex)
		{

            Console.WriteLine(ex.Message);
        }
	}
	else if (command[0]== "Refuel")
	{
        if (command[1] == "Car")
        {
            car.Refuel(double.Parse(command[2]));
        }
        else
        {
            truck.Refuel(double.Parse(command[2]));
        }
    }

}

Console.WriteLine($"Car: {car.FuelQuantity:f2}");
Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");