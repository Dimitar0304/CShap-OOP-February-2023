using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03DetailPrinter
{
    public interface IWorker
    {
        public string Name { get; set; }
        void Print();
    }
}
