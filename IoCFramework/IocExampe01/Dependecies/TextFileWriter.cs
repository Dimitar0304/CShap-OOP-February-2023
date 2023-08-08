using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocExampe01.Dependecies
{
    public class TextFileWriter : IWriter
    {
        public void Write(string value)
        {
            
           StreamWriter writer = new StreamWriter(@"../../../output.txt");
            writer.Write(value);
            writer.Flush();
           


        }
    }
}
