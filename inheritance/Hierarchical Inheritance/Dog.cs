using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Hierarchical_Inheritance
{
    public class Dog:Animal
    {
        public void Bark()
        {
            Console.WriteLine("barking...");
        }
    }
}
