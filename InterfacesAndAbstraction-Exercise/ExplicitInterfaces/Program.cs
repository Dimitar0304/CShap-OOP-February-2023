

using ExplicitInterfaces;

string command = Console.ReadLine();
List<IResident> iResident = new List<IResident>();  
List<IPerson> iPersons = new List<IPerson>();
while (command!="End")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    IResident iResidentC = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
    IPerson iPersonC = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

    Console.WriteLine(iPersonC.GetName());
    Console.WriteLine(iResidentC.GetName());
    command = Console.ReadLine();
}
