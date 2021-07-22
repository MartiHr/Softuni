using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<IId> ids = new List<IId>();
            List<IBirthday> birthdays = new List<IBirthday>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] elements = command
                    .Split(" ");

                string objectType = elements[0];

                if (objectType == "Robot")
                {
                    string model = elements[0];
                    string id = elements[1];

                    IId currentId = new Robot(model, id);
                    ids.Add(currentId);
                }
                else if(objectType == "Citizen")
                {
                    string name = elements[1];
                    int age = int.Parse(elements[2]);
                    string id = elements[3];
                    string birthDate = elements[4];

                    Citizen currentCitizen = new Citizen(name, age, id, birthDate);
                    IId currentId = currentCitizen;
                    ids.Add(currentId);
                    IBirthday birthday = currentCitizen;
                    birthdays.Add(birthday);
                }
                else
                {
                    string name = elements[1];
                    string birthDate = elements[2];

                    IBirthday birthday = new Pet(name, birthDate);
                    birthdays.Add(birthday);
                }
            }

            string filterYear = Console.ReadLine();

            List<IBirthday> filteredBirthdays = birthdays
                .Where(x => x.Birthdate.EndsWith(filterYear))
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, filteredBirthdays.Select(x => x.Birthdate)));
        }
    }
}
