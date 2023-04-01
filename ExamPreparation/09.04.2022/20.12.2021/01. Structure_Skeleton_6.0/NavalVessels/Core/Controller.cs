using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        VesselRepository vessels = new VesselRepository();
        private List<ICaptain> captains = new List<ICaptain>();
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            var vessel = vessels.FindByName(selectedVesselName);
            if (captain is null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            if (vessel is null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if (vessel.Captain == null)
            {
                captain.Vessels.Add(vessel);
                vessel.Captain = captain;
                return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
            }
            else
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vessels.FindByName(attackingVesselName);
            var deffenderVessel = vessels.FindByName(defendingVesselName);

            if (attackingVessel is null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (deffenderVessel is null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (deffenderVessel.ArmorThickness <= 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }
            if (attackingVessel.ArmorThickness <= 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }

            attackingVessel.Attack(deffenderVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            deffenderVessel.Captain.IncreaseCombatExperience();
            return $"Vessel {deffenderVessel.Name} was attacked by vessel {attackingVessel.Name} - current armor thickness: {deffenderVessel.ArmorThickness}.";

        }

        public string CaptainReport(string captainFullName)
        {
            var caption = captains.FirstOrDefault(c => c.FullName == captainFullName);


            return caption.Report();
        }


        public string HireCaptain(string fullName)
        {
            Captain captain = new Captain(fullName);
            if (captains.Contains(captain))
            {
                return $"Captain {fullName} is already hired.";
            }
            else
            {
                captains.Add(captain);
                return $"Captain {fullName} is hired.";
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselType != "Submarine" && vesselType != "Battleship")
            {
                return "Invalid vessel type.";
            }
           
            if (vesselType == "Submarine")
            {
               IVessel vessel = new Submarine(name, mainWeaponCaliber, speed);
                if (vessels.FindByName(vessel.Name) == null)
                {
                    vessels.Add(vessel);
                    return $"{vessel.GetType().Name} {vessel.Name} is manufactured with the main weapon caliber of {vessel.MainWeaponCaliber} inches and a maximum speed of {vessel.Speed} knots.";
                }
                else
                {
                    return $"{vessel.GetType().Name} vessel {vessel.Name} is already manufactured.";

                }
            }
            else if (vesselType == "Battleship")
            {
                IVessel vessel = new Battleship(name, mainWeaponCaliber, speed);
                if (!vessels.Models.Contains(vessel))
                {
                    vessels.Add(vessel);
                    return $"{vessel.GetType().Name} {vessel.Name} is manufactured with the main weapon caliber of {vessel.MainWeaponCaliber} inches and a maximum speed of {vessel.Speed} knots.";
                }
                else
                {

                    return $"{vessel.GetType().Name} vessel {vessel.Name} is already manufactured.";
                }
                
            }
            return null;

           
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel is null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            else
            {
                vessel.RepairVessel();
                return $"Vessel {vesselName} was repaired.";
            }
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if (vessel is null)
            {
                return $"Vessel {vesselName} could not be found.";

            }
            if (vessel is Battleship)
            {
                Battleship battleship = vessel as Battleship;
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";

            }
            else if (vessel is Submarine)
            {
                Submarine submarine = vessel as Submarine;
                submarine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
            return string.Empty;
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            return vessel.ToString();
        }
    }
}
