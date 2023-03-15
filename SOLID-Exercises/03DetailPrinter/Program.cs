

namespace P03DetailPrinter;

class Program
{
    static void Main()
    {
        List<IWorker> workers = new List<IWorker>();    
        IWorker employee = new Employee("Mitko");
        IWorker manager = new Manager("Nikola", new List<string>());

        workers.Add(employee);  
        workers.Add(manager);

        DetailsPrinter detailPrinter = new DetailsPrinter(workers);

        detailPrinter.PrintDetails();


    }
}
