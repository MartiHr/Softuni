﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Student
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Subject { get; private set; }

        public Student(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        public override string ToString()
        {
            return $"Student: First Name = {FirstName}, Last Name = {LastName}, Subject = {Subject}";
        }
    }
}
