﻿using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> models;
        public IReadOnlyCollection<IEquipment> Models { get => models.AsReadOnly(); }

        public void Add(IEquipment model)
        {
            models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return models.FirstOrDefault(x=>x.GetType().Equals(type));
        }

        public bool Remove(IEquipment model)
        {
           return models.Remove(model);
        }
    }
}
