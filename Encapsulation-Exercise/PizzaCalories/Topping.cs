using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private double weight;
        private string toppingType;
        private double toppingCalories;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }


        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public string ToppingType
        {
            get { return toppingType; }
            private set
            {
                string lowerValue = value.ToLower();
                if (lowerValue != "meat" && lowerValue != "veggies" && lowerValue != "cheese" && lowerValue != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                }
                if (lowerValue == "meat")
                {
                    toppingCalories = 1.2;
                }
                else if (lowerValue == "veggies")
                {
                    toppingCalories = 0.8;
                }
                else if (lowerValue == "cheese")
                {
                    toppingCalories = 1.1;
                }
                else if (lowerValue == "sauce")
                {
                    toppingCalories = 0.9;
                }


                toppingType = value;
            }
        }

        public double Calories
        {
            get { return 2 * Weight * toppingCalories; }
            private set { Calories = value; }
        }
    }
}
