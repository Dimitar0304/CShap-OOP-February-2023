namespace PersonsInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());  
        List<Person> persons = new List<Person>(); 
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));
            persons.Add(person);
        }
        Team team = new Team("SoftUni");
        foreach (Person person in persons)
        {
            team.AddPlayer(person);
        }


    }
}