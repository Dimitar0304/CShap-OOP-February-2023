using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }


        public string Size
        {
            get => size;
            private set
            {
                if (value == "Small" || value == "Middle" || value == "Large")
                {
                    
                    size = value;
                }
            }
        }

        public double Price
        {
            get => price;
            private set
            {
                if (Size== "Large")
                {
                    price = value;
                }
                else if (Size== "Middle")
                {
                    price = value - value * 0.34;
                }
                else if (Size== "Small")
                {
                    price = value - value * 0.66;
                }
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }
    }
}
