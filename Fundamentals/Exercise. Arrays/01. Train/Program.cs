using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int[] peopleArray = new int[n];
            int sum = 0;

            for (int i = 0; i < peopleArray.Length; i++)
            {
                peopleArray[i] = int.Parse(Console.ReadLine());
             
                sum += peopleArray[i];
            }
            
            Console.WriteLine(string.Join(' ', peopleArray));
            Console.WriteLine(sum);
            
            //for (int i = 0; i < peopleArray.Length; i++)
            //{
            //    Console.Write($"{peopleArray[i]} ");
            //}
            //foreach (int array in peopleArray)
            //{
            //    Console.Write($"{array} ");
            //}
        }
    }
}
