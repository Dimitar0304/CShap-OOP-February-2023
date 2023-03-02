namespace PersonsInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));
            persons.Add(person);
        }
        decimal increase = decimal.Parse(Console.ReadLine());

        foreach (var person in persons)
        {
            person.IncreaseSalary(increase);
        }
        foreach (var item in persons)
        {
            Console.WriteLine(item);
        }
    }
}