using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            BigInteger bestSnowball = 0;
            string result = "";

            for (int i = 1; i <= n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue > bestSnowball)
                {
                    bestSnowball = snowballValue;
                    result = $"{snowballSnow} : {snowballTime} = {bestSnowball} ({snowballQuality})";
                }
            }

            Console.WriteLine(result);

        }
    }
}
