using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length-1; i >= 0; i--)
            {
                password += username[i];
            }

            int count = 0;
            bool isLoggedIn = false;
            bool isBlocked = false;

            while (!isLoggedIn && !isBlocked)
            {
                string inputPassword = Console.ReadLine();

                if (inputPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    isLoggedIn = true;
                }
                else
                {
                    count++;
                   
                    if (count == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        isBlocked = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                }
            }
        }
    }
}
