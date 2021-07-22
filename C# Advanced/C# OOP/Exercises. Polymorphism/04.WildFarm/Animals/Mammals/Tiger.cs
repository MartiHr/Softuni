using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;

            if (foodType == "Meat")
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 1.00;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {foodType}!");
            }
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
