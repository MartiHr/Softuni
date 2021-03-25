using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine()
                .Split(':')
                .ToList();

            List<string> newDeck = new List<string>();

            string input = Console.ReadLine();

            while (input != "Ready")
            {
                string[] elements = input.Split();

                if (elements[0] == "Add")
                {
                    string cardName = elements[1];
                
                    if (deck.Contains(cardName))
                    {
                        newDeck.Add(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (elements[0] == "Insert")
                {
                    string cardName = elements[1];
                    int index = int.Parse(elements[2]);

                    if (deck.Contains(cardName) && (index >= 0 && index < newDeck.Count))
                    {
                        newDeck.Insert(index, cardName);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (elements[0] == "Remove")
                {
                    string cardName = elements[1];
                    
                    if (newDeck.Contains(cardName))
                    {
                        newDeck.Remove(cardName);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (elements[0] == "Swap")
                {
                    string cardName1 = elements[1];
                    string cardName2 = elements[2];

                    int index1 = newDeck.IndexOf(cardName1);
                    int index2 = newDeck.IndexOf(cardName2);

                    newDeck.Remove(cardName1);
                    newDeck.Remove(cardName2);

                    newDeck.Insert(index1, cardName2);
                    newDeck.Insert(index2, cardName1);
                }
                else if(elements[0] == "Shuffle")
                {
                    newDeck.Reverse();
                }

                input = Console.ReadLine();
            }
            
            Console.WriteLine(string.Join(' ', newDeck));
        }
    }
}
