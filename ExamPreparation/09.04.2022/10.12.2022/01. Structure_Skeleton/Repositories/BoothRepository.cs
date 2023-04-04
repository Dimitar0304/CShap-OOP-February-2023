using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> booths = new List<IBooth>();
        public IReadOnlyCollection<IBooth> Models { get => booths; }

        public void AddModel(IBooth model)
        {
           booths.Add(model);
        }
    }
}
