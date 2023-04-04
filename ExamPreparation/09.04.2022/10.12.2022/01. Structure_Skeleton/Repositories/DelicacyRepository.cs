using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> items = new List<IDelicacy>();
        public IReadOnlyCollection<IDelicacy> Models { get => items; }

        public void AddModel(IDelicacy model)
        {
            items.Add(model);
        }
    }
}
