using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int charSum = 0;

            for (int i = 1; i <= n; i++)
            {
                char current = char.Parse(Console.ReadLine());
                
                charSum += current;
            }
        
            Console.WriteLine(charSum);
        }
    }
}
