﻿using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private HashSet<IVessel> vessels;
        public VesselRepository()
        {
            vessels = new HashSet<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models { get => vessels; }

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return vessels.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
          return vessels.Remove(model);
        }
    }
}
