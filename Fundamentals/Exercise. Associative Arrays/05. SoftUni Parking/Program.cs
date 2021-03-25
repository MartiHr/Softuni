using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split();

                if (elements[0] == "register")
                {
                    string username = elements[1];
                    string licensePlate = elements[2];

                    if (dictionary.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                    else
                    {
                        dictionary.Add(username, licensePlate);
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    }
                }
                else
                {
                    string username = elements[1];

                    if (!dictionary.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        dictionary.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var vkp in dictionary)
            {
                string username = vkp.Key;
                string licensePlate = vkp.Value;

                Console.WriteLine($"{username} => {licensePlate}");
            }
        }
    }
}
