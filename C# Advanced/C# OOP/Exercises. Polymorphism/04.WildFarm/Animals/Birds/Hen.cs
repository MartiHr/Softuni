using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * 0.35;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
