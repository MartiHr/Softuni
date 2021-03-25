using System;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] users = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var user in users)
            {
                if ((user.Length > 3 && user.Length < 16) && (ContainsSpecial(user)))
                {
                    Console.WriteLine(user);
                }
            }
        }

         static bool ContainsSpecial(string user)
         {
            foreach (var character in user)
            {
                if (!((char.IsLetterOrDigit(character)) ||
                    (character == '-') ||
                    (character == '_')))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
