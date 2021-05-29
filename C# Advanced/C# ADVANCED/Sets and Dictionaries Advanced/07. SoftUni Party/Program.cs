using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }
                if (command == "PARTY")
                {
                    string arrivedGuest = string.Empty;

                    while ((arrivedGuest = Console.ReadLine()) != "END")
                    {
                        if (char.IsDigit(arrivedGuest[0]))
                        {
                            vip.Remove(arrivedGuest);
                        }
                        else
                        {
                            regular.Remove(arrivedGuest);
                        }
                    }

                    break;
                }
               
                if (char.IsDigit(command[0]))
                {
                    vip.Add(command);
                }
                else
                {
                    regular.Add(command);
                }

            }

            Console.WriteLine(vip.Count + regular.Count);

            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
