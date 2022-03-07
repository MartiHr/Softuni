using System;

namespace Problem_1
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int sDivisor = FindSmallestDivisor(n, m);
            int sCommonMultiple = FindLeastCommonMultiple(n, m);

            Console.WriteLine(sDivisor + sCommonMultiple);
        }

        public static int FindSmallestDivisor(int n, int m)
        {
            while (m != 0)
            {
                int temp = m;
                m = n % m;
                n = temp;
            }

            return n;
        }

        public static int FindLeastCommonMultiple(int n, int m)
        {
            return (n / FindSmallestDivisor(n, m)) * m;
        }
    }
}
