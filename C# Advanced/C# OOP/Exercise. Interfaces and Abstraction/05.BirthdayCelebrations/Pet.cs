﻿namespace _05.BirthdayCelebrations
{
    public class Pet : IBirthday
    {
        public string Name { get; set; }

        public string Birthdate { get; set; }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
