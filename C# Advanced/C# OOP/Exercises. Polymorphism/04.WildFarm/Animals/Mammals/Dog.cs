using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Feed(Food food)
        {
            string foodType = food.GetType().Name;

            if (foodType == "Meat")
            {
                FoodEaten += food.Quantity;
                Weight += food.Quantity * 0.40;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {foodType}!");
            }
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
