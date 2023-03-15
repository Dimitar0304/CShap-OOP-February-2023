
namespace P03DetailPrinter
{
    public class Employee:IWorker
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"Hello my name is {this.Name}");
        }
    }
}
