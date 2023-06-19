using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class Bmw : Car
    {
        public Bmw(string id, string model, int hp) : base(id, model, hp)
        {
        }
    }
}
