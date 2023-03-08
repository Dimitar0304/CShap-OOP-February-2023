using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces
{
    public interface IResident
    {
        public string Country { get; set; }
        public  string Name { get; set; }
        public string GetName();
    }
}
