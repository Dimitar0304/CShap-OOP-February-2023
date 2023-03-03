using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private const string PizzaNameExeption = "Pizza name should be between 1 and 15 symbols.";

        private string name;
        private List<Topping> toppings;
        private Dough dough;
        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();


        }

        public Dough Dough
        {
            get => dough;
            set
            { dough = value; }

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(PizzaNameExeption);
                }
                if (value.Length > 15)
                {
                    throw new ArgumentException(PizzaNameExeption);
                }
                name = value;
            }
        }
        public double TotalCalories
        {
            get
            {
                double toppingsCalories = 0;
                foreach (var topping in toppings)
                {
                    toppingsCalories += topping.Calories;
                }
                return toppingsCalories + dough.Calories;
            }
            private set
            {
                this.TotalCalories = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count + 1 <= 10)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }


    }
}
