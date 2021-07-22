using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    public class FoodFactory
    {
        public static Food Create(string[] foodElements)
        {
            string foodType = foodElements[0];
            double quantity = double.Parse(foodElements[1]);

            switch (foodType)
            {
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                default:
                    throw new ArgumentException("Wrong input");
            }
        }
    }
}
