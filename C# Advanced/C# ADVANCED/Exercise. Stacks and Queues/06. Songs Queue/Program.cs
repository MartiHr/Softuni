using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(", ");

            Queue<string> songs = new Queue<string>(elements);

            while (songs.Count > 0)
            {
                string[] tokens = Console.ReadLine()
                    .Split();

                string command = tokens[0];

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Add")
                {
                    string[] songParts = new string[tokens.Length - 1];

                    for (int i = 0; i < songParts.Length; i++)
                    {
                        songParts[i] += tokens[i + 1];
                    }

                    string song = string.Join(" ", songParts);

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
