


using Design_Patterns;
//Singleton singleton;
//Console.WriteLine(  singleton =Singleton.Instance());
////singleton.Name = "Test";    


//Console.WriteLine(singleton.Name);

Singleton s1 = Singleton.Instance();
Singleton s2 = Singleton.Instance();

if (s1 == s2)
{
    Console.WriteLine("Objects are equal");
}
