using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocExampe01.Dependecies
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
