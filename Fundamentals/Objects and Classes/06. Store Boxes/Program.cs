using System;
using System.Collections.Generic;

namespace _06._Store_Boxes
{
    class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    
    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal BoxPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] data = input.Split();

                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                int itemPrice = int.Parse(data[3]);

                Item currentItem = new Item()
                {
                    Name = itemName,
                    Price = itemPrice
                };
                Box currentBox = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = currentItem,
                    ItemQuantity = itemQuantity,
                    BoxPrice = itemQuantity * itemPrice
                };


                input = Console.ReadLine();
            }
        }
    }
}
