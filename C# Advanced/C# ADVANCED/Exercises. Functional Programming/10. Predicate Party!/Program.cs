using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Note: This solution(решение) of the problem gives 80/100, because Dictionary is used. The problem appears,
            // because it doesn't cover an input which contains two names that are exactly the same. A working solution
            // could be made using a List instead of a Dictionary. If List is used the name which you double
            // should simply be inserted at a determined inxed.

            Func<string, string, bool> startsWith = (str, compare) => str.StartsWith(compare);
            Func<string, string, bool> endsWith = (str, compare) => str.EndsWith(compare);
            Func<string, int, bool> lengthCheck = (str, number) => str.Length == number;

            string[] people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var person in people)
            {
                if (!dictionary.ContainsKey(person))
                {
                    dictionary.Add(person, 1);
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] elements = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (elements[0] == "Remove")
                {
                    switch (elements[1])
                    {
                        case "StartsWith":
                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                string person = dictionary
                                    .Keys
                                    .ElementAt(i)
                                    .ToString();
                                Dictionary<string, int> dicToCheck = initializeDicToCheck(startsWith,
                                    dictionary, elements);

                                RemoveFromDictionary(dictionary, dicToCheck, person);
                            }
                            break;
                        case "EndsWith":
                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                string person = dictionary
                                    .Keys
                                    .ElementAt(i)
                                    .ToString();

                                Dictionary<string, int> dicToCheck = initializeDicToCheck(endsWith,
                                    dictionary, elements);

                                RemoveFromDictionary(dictionary, dicToCheck, person);
                            }
                            break;
                        case "Length":
                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                string person = dictionary
                                    .Keys
                                    .ElementAt(i)
                                    .ToString();

                                Dictionary<string, int> dicToCheck = initializeDicToCheck(lengthCheck,
                                   dictionary, elements);

                                RemoveFromDictionary(dictionary, dicToCheck, person);
                            }
                            break;
                    }
                }
                else
                {
                    switch (elements[1])
                    {
                        case "StartsWith":
                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                string person = dictionary
                                    .Keys
                                    .ElementAt(i)
                                    .ToString();
                                Dictionary<string, int> dicToCheck = initializeDicToCheck(startsWith,
                                   dictionary, elements);

                                FillDictionary(dictionary, dicToCheck, person);
                            }
                            break;
                        case "EndsWith":
                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                string person = dictionary
                                    .Keys
                                    .ElementAt(i)
                                    .ToString();

                                Dictionary<string, int> dicToCheck = initializeDicToCheck(endsWith,
                                  dictionary, elements);

                                FillDictionary(dictionary, dicToCheck, person);
                            }
                            break;
                        case "Length":
                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                string person = dictionary
                                    .Keys
                                    .ElementAt(i)
                                    .ToString();

                                Dictionary<string, int> dicToCheck = initializeDicToCheck(lengthCheck,
                                  dictionary, elements);

                                FillDictionary(dictionary, dicToCheck, person);
                            }
                            break;
                    }
                }
            }

            List<string> lastList = new List<string>();

            foreach (var kvp in dictionary)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    lastList.Add(kvp.Key);
                }
            }

            if (lastList.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", lastList)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Dictionary<string, int> initializeDicToCheck(Func<string, string, bool> function,
            Dictionary<string, int> dictionary, string[] elements)
        {
             Dictionary<string, int> dicToCheck = dictionary
                                                .Where(x => function(x.Key, elements[2]))
                                                .ToDictionary(x => x.Key, x => x.Value);
            return dicToCheck;
        }

        private static Dictionary<string, int> initializeDicToCheck(Func<string, int, bool> function,
            Dictionary<string, int> dictionary, string[] elements)
        {
            Dictionary<string, int> dicToCheck = dictionary
                                               .Where(x => function(x.Key, int.Parse(elements[2])))
                                               .ToDictionary(x => x.Key, x => x.Value);
            return dicToCheck;
        }

        private static void FillDictionary(Dictionary<string, int> dictionary, 
            Dictionary<string, int> dicToCheck, string person)
        {
            if (dicToCheck.ContainsKey(person))
            {
                dictionary[person] *= 2;
            }
        }

        private static void RemoveFromDictionary(Dictionary<string, int> dictionary,
            Dictionary<string, int> dicToCheck, string person)
        {
            foreach (var item in dicToCheck)
            {
                while (dictionary.ContainsKey(person))
                {
                    dictionary.Remove(person);
                }
            }
        }
    }
}
