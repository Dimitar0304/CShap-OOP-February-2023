﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces
{
    public interface IPerson
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string GetName();
    }
}
