using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThiknessPoints = 200;
        private bool submergeMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThiknessPoints)
        {
        }

        public bool SubmergeMode
        {
            get => submergeMode;
            set => submergeMode = value;
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode==false)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                SubmergeMode = true;
            }
            else if(SubmergeMode==true)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
                SubmergeMode = false;
            }
        }
        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThiknessPoints;
        }
        public override string ToString()
        {
            string submegeTosttring = string.Empty;
            if (SubmergeMode==false)
            {
                submegeTosttring = "No";

            }
            else
            {
                submegeTosttring = "Yes";
            }
            return base.ToString()+Environment.NewLine+$"*Submerge mode: {submegeTosttring}";
        }
    }
}
