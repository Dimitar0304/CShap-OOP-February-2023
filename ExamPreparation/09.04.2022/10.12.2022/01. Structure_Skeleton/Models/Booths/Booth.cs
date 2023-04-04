using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int id;
        private int capacity;
        private double currentBill=0;
        private double turnover=0;
        private bool isReserved = false;
        

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            DelicacyMenu = new DelicacyRepository();
            CocktailMenu = new CocktailRepository();
        }

        public int BoothId { get => id; set => id = value; }

        public int Capacity
        {
            get=>capacity;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu { get; set; }

        public IRepository<ICocktail> CocktailMenu { get; set; }

        public double CurrentBill { get => currentBill;set => currentBill = value; }

        public double Turnover { get => turnover; set => turnover = value; }

        public bool IsReserved { get => isReserved; set => isReserved = value; }

        public void ChangeStatus()
        {
            if (IsReserved==false)
            {
                IsReserved = true;
            }
            else
            {
                IsReserved=false;
            }
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");
            sb.AppendLine("-Cocktail menu:");
            foreach (var item in CocktailMenu.Models)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var item in DelicacyMenu.Models)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
