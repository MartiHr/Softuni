using System;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private decimal cost;

        public string Name { get; set; }

        public decimal Cost 
        {
            get => cost;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                cost = value;
            }
        }

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
