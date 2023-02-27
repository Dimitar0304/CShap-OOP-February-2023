using Hierarchical_Inheritance;

public class StartUp
{
    static void Main(string[] args)
    {
        Cat cat = new Cat();   
        Dog dog = new Dog();

        cat.Eat();
        cat.Meow(); 
        
        dog.Eat();
        dog.Bark();
    }
}