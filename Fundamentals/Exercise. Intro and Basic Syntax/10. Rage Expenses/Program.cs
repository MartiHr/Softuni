using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice= double.Parse(Console.ReadLine());
            double dispalyPrice= double.Parse(Console.ReadLine());

            int headsetTrash = lostGamesCount / 2;
            int mouseTrash = lostGamesCount / 3;
            int keyboardTrash = lostGamesCount / 6;
            int displayTrash = lostGamesCount / 12;

            double expense = (headsetTrash * headsetPrice) + (mouseTrash * mousePrice) + (keyboardTrash * keyboardPrice) +
                (displayTrash * dispalyPrice);

            Console.WriteLine($"Rage expenses: {expense:f2} lv.");

        }
    }
}
