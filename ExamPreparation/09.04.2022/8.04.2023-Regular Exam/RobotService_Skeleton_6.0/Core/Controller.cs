using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            if (typeName != "DomesticAssistant"&&typeName!= "IndustrialAssistant")
            {
                return $"Robot type {typeName} cannot be created.";
            }
            IRobot robot = null;
            switch (typeName)
            {
                case "DomesticAssistant":
                    robot = new DomesticAssistant(model);
                    break;
                case "IndustrialAssistant":
                    robot = new IndustrialAssistant(model);
                    break;
            }
            robots.AddNew(robot);
            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName!= "SpecializedArm"&&typeName!= "LaserRadar")
            {
                return $"{typeName} is not compatible with our robots.";
            }
            ISupplement supplement = null;
            switch (typeName)
            {
                case "SpecializedArm":
                    supplement = new SpecializedArm();

                    break;
                case "LaserRadar":
                    supplement = new LaserRadar();
                    break;
            }
            supplements.AddNew(supplement);
            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsThatSupport = robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).ToList();
            if (robotsThatSupport.Count==0)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }
            robotsThatSupport = robotsThatSupport.OrderByDescending(r => r.BatteryLevel).ToList();
            var sum = robotsThatSupport.Sum(r => r.BatteryLevel);

            if (sum<totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - sum} more power needed.";
            }
            int robotCounter = 0;
            foreach (var robot in robotsThatSupport)
            {
                if (totalPowerNeeded<=0)
                {
                    break;
                }
                if (robot.BatteryLevel>=totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    totalPowerNeeded-=robot.BatteryLevel;
                    robotCounter++;
                }
                else
                {
                    totalPowerNeeded-=robot.BatteryLevel;
                    robot.ExecuteService(totalPowerNeeded);
                    robotCounter++;
                }
            }
            return $"{serviceName} is performed successfully with {robotCounter} robots.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            var orderedRobots = robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity);
            foreach (var item in orderedRobots)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RobotRecovery(string model, int minutes)
        {
            int countOfFedRobots = 0;
            List<IRobot> halfBatteryLevelRobots = robots.Models().Where(r =>r.Model==model).ToList();
            
            halfBatteryLevelRobots = halfBatteryLevelRobots.Where(r => r.BatteryLevel < r.BatteryCapacity / 2).ToList();
            foreach (var robot in halfBatteryLevelRobots)
            {
                robot.Eating(minutes);
                countOfFedRobots++;
            }
            return $"Robots fed: {countOfFedRobots}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var suplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            List<IRobot> robotsWithoutThisSuplement = robots.Models().Where(r => !r.InterfaceStandards.Contains(suplement.InterfaceStandard)).ToList();
            List<IRobot> robotsWithThisModel = robotsWithoutThisSuplement.Where(r => r.Model == model).ToList();
            if (robotsWithThisModel.Count==0)
            {
                return $"All {model} are already upgraded!";
            }
            else
            {
                IRobot robot = robotsWithThisModel[0];
                robot.InstallSupplement(suplement);
                supplements.RemoveByName(supplementTypeName);
                return $"{model} is upgraded with {supplementTypeName}.";
            }
        }
        
    }
}
