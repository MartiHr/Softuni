using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double BaseCalories = 2;

        private const double WhiteFlourCalories = 1.5;
        private const double WholegrainFlourCalories = 1.0;

        private const double CrispyBakingTechnique = 0.9;
        private const double ChewyBakingTechnique = 1.1;
        private const double HomemadeBakingTechnique = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double totalCalories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType.ToLower();
            BakingTechnique = bakingTechnique.ToLower();
            Weight = weight;
            TotalCalories = CalculateTotalCalories();
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value != "crispy" && value != "homemade" && value != "chewy")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weight = value;
            }
        }

        public double TotalCalories { get => totalCalories; private set => totalCalories = value; }

        public double CalculateTotalCalories()
        {
            double calories = BaseCalories * Weight;

            switch (flourType)
            {
                case "white":
                    calories *= WhiteFlourCalories;
                    break;
                case "wholegrain":
                    calories *= WholegrainFlourCalories;
                    break;
            }

            switch (BakingTechnique)
            {
                case "crispy":
                    calories *= CrispyBakingTechnique;
                    break;
                case "homemade":
                    calories *= HomemadeBakingTechnique;
                    break;
                case "chewy":
                    calories *= ChewyBakingTechnique;
                    break;
            }

            return calories;
        }
    }
}
