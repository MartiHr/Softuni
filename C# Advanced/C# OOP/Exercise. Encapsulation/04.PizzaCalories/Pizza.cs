using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private int numberOfToppings;
        private List<Topping> toppings;
        private double totalCalories;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough { get => dough; set => dough = value; }

        public List<Topping> Toppings { get => toppings; private set => toppings = value; }

        public int NumberOfToppings
        {
            get { return numberOfToppings; }
            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                numberOfToppings = value;
            }
        }

        public double TotalCalories { get => totalCalories; set => totalCalories = value; }
       
        public void AddToping(Topping Topping)
        {
            NumberOfToppings++;
            Toppings.Add(Topping);
        }
    }
}
