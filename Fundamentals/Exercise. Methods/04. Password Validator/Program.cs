using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValid = true;

            if (!CheckCharacterLenght(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }
            if (!CheckWhatConsistsOf(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }
            if (!DigitCountChecker(password, 2))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckCharacterLenght(string input)
        {  
            return input.Length >= 6 && input.Length <= 10;
        }

        static bool CheckWhatConsistsOf(string input)
        {
            foreach (char symbol in input)
            {
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        static bool DigitCountChecker(string input, int count)
        {
            int counter = 0;

            foreach (char symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    counter++;
                }
            }

            if (counter < count)
            {
                return false;
            }

            return true;
        }
    }
}
