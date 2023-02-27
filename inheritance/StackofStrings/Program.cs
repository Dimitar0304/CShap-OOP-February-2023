namespace CustomStack;
public class StartUp
{
    static void Main(string[] args)
    {
        StackOfStrings stack = new StackOfStrings();
        Console.WriteLine(stack.IsEmpty());

        List<string> result = new() { "1", "2", "3", "4" };

        stack.AddRange(result);
        
    }
}