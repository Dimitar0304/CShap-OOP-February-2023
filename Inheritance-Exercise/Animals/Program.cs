namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string animaltype = Console.ReadLine();
                if (animaltype=="Beast!")
                {
                    break;
                }
                Console.WriteLine(animaltype);
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (animaltype)
                {
                    case"Dog":
                        Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(dog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(cat);
                        break;
                    case "Frog":
                        Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                        Console.WriteLine(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                        Console.WriteLine(tomcat);
                        break;
                }
            }
        }
    }
}
