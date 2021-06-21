using System;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = firstInput[0] + " " + firstInput[1];
            string address = firstInput[2];
            string town = firstInput[3];

            string[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name2 = secondInput[0];
            int amountOfBeer = int.Parse(secondInput[1]);
            string check = secondInput[2];
            bool drunkOrNot = false;

            if (check == "drunk")
            {
                drunkOrNot = true;
            }

            string[] thirdInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name3 = thirdInput[0];
            double bankBalance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];
            
            Threeuple<string, string, string> nameWithAddressAndTown = new Threeuple<string, string, string>(name, address, town);
            Threeuple<string, int, bool> nameAndAmountOfBeer = new Threeuple<string, int, bool>(name2, amountOfBeer, drunkOrNot);
            Threeuple<string, double, string> NameWithBankBallanceAndBankName = new Threeuple<string, double, string>(name3, bankBalance, bankName);
            
            Console.WriteLine(nameWithAddressAndTown);
            Console.WriteLine(nameAndAmountOfBeer);
            Console.WriteLine(NameWithBankBallanceAndBankName);
        }
    }
}
