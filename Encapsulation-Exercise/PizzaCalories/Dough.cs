using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private const string FlourAndBakingExeption = "Invalid type of dough.";

        private double weight;
        private string flourType;
        private string bakingTechnique;
        private double flourCalories;
        private double bakingTechniqueCalories;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                string lowerValue = value.ToLower();
                if (lowerValue != "chewy" && lowerValue != "homemade" && lowerValue != "crispy")
                {
                    throw new ArgumentException(FlourAndBakingExeption);
                }
                if (lowerValue== "chewy")
                {
                    bakingTechniqueCalories = 1.1;
                }
                else if (lowerValue== "homemade")
                {
                    bakingTechniqueCalories = 1.0;
                }
                else if (lowerValue== "crispy")
                {
                    bakingTechniqueCalories = 0.9;
                }
                bakingTechnique = value;
            }
        }


        public string FlourType
        {
            get { return flourType; }
            private set
            {
                string lowerValue = value.ToLower();
                if (lowerValue != "wholegrain" && lowerValue != "white")
                {
                    throw new ArgumentException(FlourAndBakingExeption);
                }
                if (lowerValue == "wholegrain")
                {
                    flourCalories = 1.0;
                }
                else if (lowerValue =="white")
                {
                    flourCalories = 1.5;
                }
                flourType = value;
            }
        }


        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public double Calories
        {
            get { return 2 * (Weight) * flourCalories * bakingTechniqueCalories; }
           private set { this.Calories = value; }
        }

    }
}
