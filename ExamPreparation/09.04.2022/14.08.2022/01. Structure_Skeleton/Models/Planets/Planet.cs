using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
            //MilitaryPower = SumMilitaryPower();
        }
        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }
                name = value;
            }
        }

        private double budget;
        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }
                budget = value;
            }
        }

        private double militaryPower;

        private double SumMilitaryPower()
        {
            return Math.Round(army.Sum(u => (double)u.EnduranceLevel) + weapons.Sum(w => w.DestructionLevel), 3);
        }
        public double MilitaryPower
        {
            get => SumMilitaryPower();
            private set
            {
                IMilitaryUnit anonymounsImpactUnit = army.FirstOrDefault(u=>u.GetType().Name== "AnonymousImpactUnit");
                IWeapon nuclearWeapon = weapons.FirstOrDefault(w => w.GetType().Name == "NuclearWeapon");
                if (anonymounsImpactUnit!=null)
                {
                    value += value * 0.3;
                }
                if (nuclearWeapon!= null)
                {
                    value += value * 0.45;
                }
                militaryPower = value;
            }
        }

        private List<IMilitaryUnit> army;
        public IReadOnlyCollection<IMilitaryUnit> Army { get => army.AsReadOnly(); }

        private List<IWeapon> weapons;

        public IReadOnlyCollection<IWeapon> Weapons { get => weapons.AsReadOnly(); }


        public void AddUnit(IMilitaryUnit unit)
        {
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            if (army.Count == 0)
            {
                sb.AppendLine("--Forces: No units");
            }
            else
            {

                sb.AppendLine($"--Forces: {string.Join(", ", army)}");
            }
            if (weapons.Count==0)
            {
                sb.AppendLine("--Combat equipment: No weapons");
            }
            else
            {
                sb.AppendLine($"--Combat equipment: {string.Join(", ", weapons)}");
            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");
            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget - amount < 0)
            {
                throw new InvalidOperationException("Budget too low!");
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var item in army)
            {
                item.IncreaseEndurance();
            }
        }
    }
}
