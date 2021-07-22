using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Foods
{
    public abstract class Food
    {
        protected Food(double quantity)
        {
            Quantity = quantity;
        }

        public double Quantity { get; set; }
    }
}
