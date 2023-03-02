using Validation;

namespace PersonsInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();
        
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");

            try
            {

                Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));
                people.Add(person);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            }
       
       
        foreach (var item in people)
        {
            Console.WriteLine(item);
        }
        
    }
}