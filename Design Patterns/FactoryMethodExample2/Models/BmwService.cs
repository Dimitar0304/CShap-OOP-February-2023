using FactoryMethodExample2.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodExample2.Models
{
    public class BmwService : Service
    {
        protected override IMechanic MakeCar()
        {
            return new BmwMechanic();
        }
    }
}
