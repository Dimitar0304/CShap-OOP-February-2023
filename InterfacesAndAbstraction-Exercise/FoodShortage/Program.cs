using FoodShortage;

int n = int.Parse(Console.ReadLine());
List<IBuyer> buyers = new List<IBuyer>();

for (int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
	if (tokens.Length==4)
	{
		IBuyer citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
		buyers.Add(citizen);
	}
	else
	{
		IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
		buyers.Add(rebel);
	}
}
string name = Console.ReadLine();
bool isExist = false;
int purchasedFood = 0;
while (name!="End")
{
	foreach (var buyer in buyers)
	{
		if (buyer.Name==name)
		{
			isExist =true;
			if (buyer is Citizen)
			{
				purchasedFood += 10;

            }
			else
			{
				purchasedFood += 5;
			}
		}
	}
	name = Console.ReadLine();
}
Console.WriteLine(purchasedFood);
