using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string crop;

        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary,string crop) : base(id, firstName, lastName, salary)
        {
            Crop = crop;    
        }

        public string Crop { get; set; }
    }
}
