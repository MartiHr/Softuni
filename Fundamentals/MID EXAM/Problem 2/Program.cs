using System;
using System.Linq;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weaponParts = Console.ReadLine()
                .Split("|")
                .ToArray();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] elements = input.Split();

                if (elements[1] == "Left")
                {
                    int index = int.Parse(elements[2]);

                    if (index > 0 && index < weaponParts.Length)
                    {
                        string currentPart = weaponParts[index];
                        weaponParts[index] = weaponParts[index - 1];
                        weaponParts[index - 1] = currentPart;
                    }
                }
                else if (elements[1] == "Right")
                {

                    int index = int.Parse(elements[2]);

                    if (index >= 0 && index < weaponParts.Length - 1)
                    {
                        string currentPart = weaponParts[index];
                        weaponParts[index] = weaponParts[index + 1];
                        weaponParts[index + 1] = currentPart;
                    }
                }
                else if (elements[1] == "Even")
                {
                    for (int i = 0; i < weaponParts.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write(weaponParts[i] + " ");
                        }
                        
                    }
                    Console.WriteLine();
                }
                else if (elements[1] == "Odd")
                {
                    for (int i = 0; i < weaponParts.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.Write(weaponParts[i] + " ");
                        }

                    }
                    Console.WriteLine();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {string.Join("", weaponParts)}!");
        }
    }
}
