﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class Audi : Car
    {
        public Audi(string id, string model, int hp) : base(id, model, hp)
        {
        }
    }
}
