namespace Animals;


public class StartUp
{
    static void Main(string[] args)
    {
        Animal cat = new Cat("Peter", "whiskas");
        Animal dog = new Dog("George", "Meat");

        Console.WriteLine(cat.ExplainSelf());
        Console.WriteLine(dog.ExplainSelf());
    }
}