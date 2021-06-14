using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string, bool> startsWith = (str, parameter) => str.StartsWith(parameter);
            Func<string, string, bool> endsWith = (str, parameter) => str.EndsWith(parameter);
            Func<string, int, bool> chekLength = (str, parameter) => str.Length == parameter;
            Func<string, string, bool> contains = (str, parameter) => str.Contains(parameter);

            List<(string filter, string parameter)> prfmCommands = new List<(string filter, string parameter)>();
            
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] elements = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string prfmCommand = elements[0];
                string filterType = elements[1];
                string parameter = elements[2];

                switch (prfmCommand)
                {
                    case "Add filter":
                        AddByFilterType(filterType, parameter, prfmCommands);
                        break;
                    case "Remove filter":
                        RemoveByFilterType(filterType, parameter, prfmCommands);
                        break;
                }
            }

            foreach (var prfmCommand in prfmCommands)
            {

                switch (prfmCommand.filter)
                {
                    case "Starts with":
                        people = people
                            .Where(x => !startsWith(x, prfmCommand.parameter))
                            .ToList();
                        break;
                    case "Ends with":
                        people = people
                            .Where(x => !endsWith(x, prfmCommand.parameter))
                            .ToList();
                        break;
                    case "Length":
                        people = people
                            .Where(x => !chekLength(x, int.Parse(prfmCommand.parameter)))
                            .ToList();
                        break;
                    case "Contains":
                        people = people
                            .Where(x => !contains(x, prfmCommand.parameter))
                            .ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static void AddByFilterType(string filterType, string parameter, List<(string, string)> prfmCommands)
        {
            prfmCommands.Add((filterType, parameter));
        }

        private static void RemoveByFilterType(string filterType, string parameter, List<(string, string)> prfmCommands)
        {
            prfmCommands.Remove((filterType, parameter));
        }
    }
}
