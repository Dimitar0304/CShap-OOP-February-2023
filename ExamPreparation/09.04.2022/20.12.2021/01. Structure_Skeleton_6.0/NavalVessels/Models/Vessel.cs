﻿using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NavalVessels.Models
{
    public class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;

        public Vessel(string name,double mainWeaponCaliber,double speed,double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
             set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get => armorThickness;
            set
            {
                armorThickness = value;
            }

        }

        public double MainWeaponCaliber
        {
        get => mainWeaponCaliber;
            set
            {
                mainWeaponCaliber = value;
            }
            
        }

    public double Speed
        {
            get => speed;
            set
            {
                speed = value;
            }

        }
        public ICollection<string> Targets { get => targets; }

        public void Attack(IVessel target)
        {
            if (target is null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness<0)
            {
                target.ArmorThickness = 0;
            }
            targets.Add(target.Name);
        }

        public virtual void RepairVessel()
        {
            this.ArmorThickness = 0;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {this.Speed} knots");
            if (targets.Count==0)
            {
                sb.AppendLine("*Targets: None");
            }
            else
            {
                sb.AppendLine($"*Targets: {string.Join(", ", targets)}");
            }
            return sb.ToString().Trim();

        }
    }
}
