using PizzaCalories;
try
{

string[] pizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
Pizza pizza = new Pizza(pizzaName[1]);
string[] doughtInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
pizza.Dough = new Dough(doughtInfo[1], doughtInfo[2], double.Parse(doughtInfo[3]));
while (true)
{
    string command = Console.ReadLine();
	if (command=="END")
	{
		break;
	}
	string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
	Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));
	pizza.AddTopping(topping);
}
    Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
	
}
