using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoTypeDesignPattern.Models
{
    public abstract class CarPrototype
    {
        public abstract CarPrototype Clone();
    }
}
