using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;
        public RobotRepository()
        {
            robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
           robots.Add(model);   
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            
           return robots.FirstOrDefault(r=>r.InterfaceStandards.Contains(interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return robots.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            var robotToRemove = robots.FirstOrDefault(r=>r.Model==typeName);
            if (robotToRemove!=null)
            {
                return false;
            }
            return robots.Remove(robotToRemove);
        }
    }
}
