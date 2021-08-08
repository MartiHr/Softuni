using System;
using System.Collections.Generic;

namespace _02.Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;
        public CompositeGift(string name, int price)
        : base(name, price)
        {
            gifts = new List<GiftBase>();
        }
        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }
        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }
        public override int CalculateTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{name} contains the following products with prices:");
            
            foreach (var gift in gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}
