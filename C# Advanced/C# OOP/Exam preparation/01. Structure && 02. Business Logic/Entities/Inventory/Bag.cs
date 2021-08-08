using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        protected Bag(int capacity)
        {
            Capacity = capacity;
            Items = new List<Item>();
            Load = Items.Sum(x => x.Weight);
        }

        public int Capacity { get; set; } = 100;

        public int Load { get; }

        public IReadOnlyCollection<Item> Items { get; private set; }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            List<Item> itemsClone = (List<Item>)Items;
            itemsClone.Add(item);
            Items = itemsClone;
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            List<Item> itemsClone = (List<Item>)Items;
            Item wantedItem = Items.FirstOrDefault(x => x.GetType().Name == name);
            
            if (itemsClone.Contains(wantedItem) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            itemsClone.Remove(wantedItem);
            Items = itemsClone;

            return wantedItem;
        }
    }
}
