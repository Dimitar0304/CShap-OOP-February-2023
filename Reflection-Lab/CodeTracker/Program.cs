using System.Reflection;

namespace AuthorProblem;

[Author("Victor")]
public class StartUp
{
    [Author("Gogi")]
    static void Main(string[] args)
    {
        Type type = typeof(StartUp);
        foreach (MethodInfo item in type.GetMethods((BindingFlags)60))
        {
            AuthorAttribute[]  attributes = item.GetCustomAttributes<AuthorAttribute>().ToArray();
            foreach (AuthorAttribute attribute in attributes)
            {
                Console.WriteLine($"{item.Name} is written by {attribute.Name}");
            }
        }
    }
}