using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            
            int pokedCounter = 0;
            double originalN = n;

            while (n >= m)
            {
                n -= m;
                pokedCounter++;
                double newN = originalN / 2;
               
                if (newN == n && y != 0)
                {
                    n /= y;
                }
            }

            Console.WriteLine(n);
            Console.WriteLine(pokedCounter);

        }
    }
}
