using System;
using System.Collections.Generic;

using System.Text;
using System.Linq;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double MeatCalories = 1.2;
        private const double VeggiesCalories = 0.8;
        private const double CheeseCalories = 1.1;
        private const double SauceCalories = 0.9;
        
        private string toppingType;
        private double weight;

        public Topping()
        {

        }

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public double Weight
        {
            get => weight;
            set
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
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }


        public double GetToppingCalories()
        {
            double modifier = 0.0;
            switch (ToppingType.ToLower())
            {
                case "meat":
                    modifier = MeatCalories;
                    break;
                case "veggies":
                    modifier = VeggiesCalories;
                    break;
                case "cheese":
                    modifier = CheeseCalories;
                    break;
                case "sauce":
                    modifier = SauceCalories;
                    break;
            }
         
            return 2 * modifier * Weight;
        }
    }
}
