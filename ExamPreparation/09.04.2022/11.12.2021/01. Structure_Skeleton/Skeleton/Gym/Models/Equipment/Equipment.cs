using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        public Equipment(double weight, decimal price)
        {
			Weight = weight;

			Price = price;
        }
        private double weight;

		public double Weight
		{
			get { return weight; }
			set { weight = value; }
		}


		private decimal price;

		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}

	}
}
