using System;

namespace _08._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int columns = 1; columns <= n; columns++)
            {
                for (int rows = 1; rows <= columns; rows++)
                {
                    Console.Write(columns + " ");
                }

                Console.WriteLine();
            }




        }
    }
}
