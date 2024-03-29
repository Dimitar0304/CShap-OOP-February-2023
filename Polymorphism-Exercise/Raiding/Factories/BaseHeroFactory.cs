﻿using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public class BaseHeroFactory : IBaseHeroFactory
    {
        public IBaseHero Create(string type, string name)
        {
            switch (type)
            {
                case"Paladin":
                    return new Paladin(name);   
                case "Druid":
                    return new Druid(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
