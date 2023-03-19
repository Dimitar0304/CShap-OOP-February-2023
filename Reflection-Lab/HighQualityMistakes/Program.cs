namespace Stealer;
public class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string className = Console.ReadLine();
        Console.WriteLine(spy.AnalyzeAccessModifiers(className));
    }
}