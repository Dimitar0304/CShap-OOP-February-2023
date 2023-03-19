

using System.Reflection;
using System.Text;

namespace Stealer;

public class StartUp
{
    static void Main(string[] args)
    {
       string type= Console.ReadLine();
        Spy spy = new Spy();
        string[] fieldsToHack = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine(spy.StealFieldInfo(type,fieldsToHack));


    }
}