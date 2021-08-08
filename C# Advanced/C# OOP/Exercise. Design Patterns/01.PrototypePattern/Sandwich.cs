using System;
using System.Collections.Generic;
using System.Text;

namespace _01.PrototypePattern
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredients = GetIngredientList();
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");

            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngredientList()
        {
            return $"{bread}, {meat}, {cheese}, {veggies}";
        }
    }
}
