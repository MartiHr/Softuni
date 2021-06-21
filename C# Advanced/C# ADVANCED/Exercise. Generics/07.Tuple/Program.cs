using System;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = firstInput[0] + " " + firstInput[1];
            string address = firstInput[2];

            Tuple<string, string> nameAndAddress = new Tuple<string, string>(name, address);

            Console.WriteLine(nameAndAddress);
            
            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name2 = secondInput[0];
            int amountOfBeer = int.Parse(secondInput[1]);

            Tuple<string, int> nameAndAmountOfBeer = new Tuple<string, int>(name2, amountOfBeer);

            Console.WriteLine(nameAndAmountOfBeer);

            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int integer = int.Parse(thirdInput[0]);
            double db = double.Parse(thirdInput[1]);    

            Tuple<int, double> integerAndDouble = new Tuple<int, double>(integer, db);

            Console.WriteLine(integerAndDouble);
        }
    }
}
