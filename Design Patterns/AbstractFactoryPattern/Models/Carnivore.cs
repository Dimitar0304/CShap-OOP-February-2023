using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Models
{
    public abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
}
