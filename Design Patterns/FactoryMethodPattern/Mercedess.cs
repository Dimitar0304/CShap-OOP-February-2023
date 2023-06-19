using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class Mercedess : Car
    {
        public Mercedess(string id, string model, int hp) : base(id, model, hp)
        {
        }
    }
}
