
using System.Collections.Generic;

namespace P03DetailPrinter
{
    public class Manager :IWorker
    {
        public Manager(string name, ICollection<string> documents) 
        {
            Name = name;    
            documents.Add("Docomentary");
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }
        public string Name { get; set ; }

        public void Print()
        {
            Console.WriteLine($"Hello my name is {Name} and my documents are: {string.Join(", ",Documents)}");
        }
    }
}
