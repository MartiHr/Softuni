using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // List<string> pieces = new List<string>();
            Dictionary<string, string[]> pieces = new Dictionary<string, string[]>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string piece = elements[0];
                string composer = elements[1];
                string key = elements[2];

                pieces.Add(piece, new string[] { composer, key });

               
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Stop")
                {
                    break;
                }

                string[] parts = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Add")
                {
                    string currentPiece = parts[1];
                    string currentComposer = parts[2];
                    string currentKey = parts[3];

                    if (pieces.ContainsKey(currentPiece))
                    {
                        Console.WriteLine($"{currentPiece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(currentPiece, new string[] { currentComposer, currentKey });
                        Console.WriteLine($"{currentPiece} by {currentComposer} in {currentKey} added to the collection!");
                    }
                }
                else if (parts[0] == "Remove")
                {
                    string currentPiece = parts[1];

                    if (pieces.ContainsKey(currentPiece))
                    {
                        pieces.Remove(currentPiece);
                        Console.WriteLine($"Successfully removed {currentPiece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                    }
                }
                else
                {
                    string currentPiece = parts[1];
                    string newKey = parts[2];

                    if (pieces.ContainsKey(currentPiece))
                    {
                        pieces[currentPiece][1] = newKey;
                        Console.WriteLine($"Changed the key of {currentPiece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {currentPiece} does not exist in the collection.");
                    }
                }
            }

            pieces = pieces
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value[1])
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
