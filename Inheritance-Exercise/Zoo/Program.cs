namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear    ("mecho");
            Lizard lizard = new Lizard("lizard");
            Gorilla gorrila = new Gorilla("gorilla");
            Snake snake = new Snake("sako");
            Console.WriteLine(snake.Name);
            Console.WriteLine(bear.Name);
            Console.WriteLine(lizard.Name);
            Console.WriteLine(gorrila.Name);

        }
    }
}