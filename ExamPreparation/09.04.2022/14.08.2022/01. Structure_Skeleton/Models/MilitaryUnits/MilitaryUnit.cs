﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            Cost = cost;
        }
        public double Cost { get; private set; }

        private int enduranceLevel;
        public int EnduranceLevel { get => enduranceLevel;private set { enduranceLevel = value; } }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;
            if (EnduranceLevel>20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }
        }
    }
}
