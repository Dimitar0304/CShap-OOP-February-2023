using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternExample3.Models
{
    public class NewspapersWriter : IWriter
    {
        public void WriteBook()
        {
            Console.WriteLine("I write onlt newspapers");
        }
    }
}
