using BirthdayCelebrations;


string command = Console.ReadLine();
List<IBirthdayble> birthdayDatableLiving = new List<IBirthdayble>();
while (command != "End")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (tokens[0] == "Citizen")
    {
        IBirthdayble citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
        birthdayDatableLiving.Add(citizen);
    }
    else if (tokens[0] == "Pet")
    {
        IBirthdayble pet = new Pet(tokens[1], tokens[2]);
        birthdayDatableLiving.Add(pet);
    }





    command = Console.ReadLine();
}

string number = Console.ReadLine();


int counter = 0;
foreach (var living in birthdayDatableLiving)
{
    if (living.BirthdayData.EndsWith(number))
    {
        Console.WriteLine(living.BirthdayData);
        counter++;
    }
}
if (counter == 0)
{
    Console.WriteLine("<empty output>");
}