using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        private bool sonarMode = false;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }
        public bool SonarMode
        {
            get => sonarMode;
            set
            {
                sonarMode = value;
            }
        }


        public void ToggleSonarMode()
        {
            if (SonarMode ==false)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
                SonarMode = true;
            }
            else if(SonarMode ==true) 
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                SonarMode = false;
            }
        }
        public override string ToString()
        {
            string sonarTostring = string.Empty;
            if (SonarMode==false)
            {
                sonarTostring = "No";
            }
            else
            {
                sonarTostring = "Yes";
            }
            return base.ToString() + Environment.NewLine + $"*Sonar mode: {sonarTostring}";

        }
    }
}
