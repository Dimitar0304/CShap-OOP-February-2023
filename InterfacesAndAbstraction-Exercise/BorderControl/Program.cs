using BorderControl;

string command = Console.ReadLine();
List<IIdentityInCity> LivingInCity = new List<IIdentityInCity>();
while (command!="End")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (tokens.Length == 3)
    {
        IIdentityInCity citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
        LivingInCity.Add(citizen);
    }
    else
    {
        IIdentityInCity robot = new Robot(tokens[0], tokens[1]);
        LivingInCity.Add(robot);
    }




    command = Console.ReadLine();
}

string number = Console.ReadLine();


foreach (var living in LivingInCity)
{
    if (living.Id.EndsWith(number))
    {
        Console.WriteLine(living.Id);
    }
}