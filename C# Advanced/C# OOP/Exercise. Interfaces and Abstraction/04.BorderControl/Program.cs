using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<IId> ids = new List<IId>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] elements = command
                    .Split(" ");

                if (elements.Length == 2)
                {
                    string model = elements[0];
                    string id = elements[1];

                    IId currentId = new Robot(model, id);
                    ids.Add(currentId);
                }
                else
                {
                    string name = elements[0];
                    int age = int.Parse(elements[1]);
                    string id = elements[2];

                    IId currentId = new Citizen(name, age, id);
                    ids.Add(currentId);
                }
            }

            string fakeMatch = Console.ReadLine();

            IEnumerable<IId> fakeIds = ids.Where(x => x.Id.EndsWith(fakeMatch));

            Console.WriteLine(string.Join(Environment.NewLine, fakeIds.Select(x => x.Id)));
        }
    }
}
