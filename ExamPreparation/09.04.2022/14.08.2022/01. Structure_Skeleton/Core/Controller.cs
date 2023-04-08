using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private string[] typeOfUnits = { "SpaceForces", "AnonymousImpactUnit", "StormTroopers" };
        private string[] typeOfWeapons = { "SpaceMissiles", "NuclearWeapon", "BioChemicalWeapon" };
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!typeOfUnits.Contains(unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }
            IMilitaryUnit unit = null;
            //create a unit
            switch (unitTypeName)
            {
                case "SpaceForces":
                    unit = new SpaceForces();
                    break;
                case "AnonymousImpactUnit":
                    unit = new AnonymousImpactUnit();
                    break;
                case "StormTroopers":
                    unit = new StormTroopers();
                    break;
            }
            IMilitaryUnit isPlanetContainsCurrentUnit = planet.Army.FirstOrDefault(u => u.GetType().Name == unit.GetType().Name);
            if (isPlanetContainsCurrentUnit!=null)
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }
            planet.AddUnit(unit);
            planet.Spend(unit.Cost);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!typeOfWeapons.Contains(weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }
            IWeapon weapon = null;
            //create a weapon
            switch (weaponTypeName)
            {
                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
            }
            IWeapon isPlanetContainsCurrentWeapon = planet.Weapons.FirstOrDefault(w => w.GetType().Name == weapon.GetType().Name);
            if (isPlanetContainsCurrentWeapon != null)
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Army of {planetName}!");
            }
            planet.AddWeapon(weapon);
            planet.Spend(weapon.Price);
            return $"{planetName} purchased {weaponTypeName}!";

        }

        public string CreatePlanet(string name, double budget)
        {
            Planet planet = new Planet(name, budget);
            if (planets.FindByName(name)==null)
            {
                planets.AddItem(planet);
                return $"Successfully added Planet: {name}";
            }
            else
            {
                return $"Planet {name} is already added!";
            }
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
          var planetsReport = planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name).ToList();
            foreach (var planet in planetsReport)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var atttackingPlanet = planets.FindByName(planetOne);
            var deffenderPlanet = planets.FindByName(planetTwo);

            IPlanet winner = null;
            IPlanet looser = null;

            if (atttackingPlanet.MilitaryPower>deffenderPlanet.MilitaryPower)
            {
                winner = atttackingPlanet;
                looser = deffenderPlanet;
            }
            else if(deffenderPlanet.MilitaryPower>atttackingPlanet.MilitaryPower)
            {
                winner= deffenderPlanet;
                looser = atttackingPlanet;
            }
            if (winner==null)
            {
                //check wich planet has nuclear weapon
                var attackerWeapon = atttackingPlanet.Army.FirstOrDefault(w => w.GetType().Name == "NuclearWeapon");
                var deffenderWeapoon = deffenderPlanet.Army.FirstOrDefault(w => w.GetType().Name == "NuclearWeapon");
                if (attackerWeapon==null&&deffenderWeapoon!=null)
                {
                    winner = deffenderPlanet;
                    looser = atttackingPlanet;
                    
                }
                else if(attackerWeapon!=null&&deffenderWeapoon==null)
                {
                    winner = atttackingPlanet;
                    looser = deffenderPlanet;
                    
                }
                else
                {
                    atttackingPlanet.Spend(atttackingPlanet.Budget / 2);
                    deffenderPlanet.Spend(deffenderPlanet.Budget / 2);
                    return $"The only winners from the war are the ones who supply the bullets and the bandages!";
                }
            }
            winner.Spend(winner.Budget/2);
            winner.Profit(looser.Budget/2);
            looser.Spend(looser.Budget/2);
            winner.Profit(looser.Army.Sum(w => w.Cost) + looser.Weapons.Sum(w => w.Price));
            planets.RemoveItem(looser.Name);
            return $"{winner.Name} destructed {looser.Name}!";

        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException("Planet {planetName} does not exist!");
            }
            if (planet.Army.Count==0)
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return $"{planetName} has upgraded its forces!";

        }
    }
}
