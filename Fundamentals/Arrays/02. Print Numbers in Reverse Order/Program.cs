using System;
using System.Linq;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                arr[i] = number;
            }
           
            Console.WriteLine(string.Join(' ', arr.Reverse()));
               
        }
    }
}
