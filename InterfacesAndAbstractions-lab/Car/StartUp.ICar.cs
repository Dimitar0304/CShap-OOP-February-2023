using Car;

namespace Cars;

public class StartUp
{
    static void Main(string[] args)
    {
        Seat seat = new Seat("LEon", "white");
        Console.WriteLine(seat.Start());
        Console.WriteLine(seat.Stop());
        Console.WriteLine(seat.Model);
        Console.WriteLine(seat.Color);

        Tesla tesla = new Tesla("M$", "Yellow", 8);
        Console.WriteLine(tesla.Start());
        Console.WriteLine(tesla.Stop());
        Console.WriteLine(tesla.Battery);
        Console.WriteLine(tesla.Color);
        Console.WriteLine(tesla.Model);
    }

}