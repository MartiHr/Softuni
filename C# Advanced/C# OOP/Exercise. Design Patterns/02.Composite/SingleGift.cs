using System;

namespace _02.Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with price {price}");

            return price;
        }
    }
}
