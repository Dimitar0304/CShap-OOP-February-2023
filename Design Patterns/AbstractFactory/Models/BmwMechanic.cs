using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Models.Interfaces;

namespace AbstractFactory.Models
{
    public class BmwMechanic : IMechanic
    {
        public void GetDescription()
        {
            Console.WriteLine("Im only bmw mechanic");
        }
    }
}
