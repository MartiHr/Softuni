using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier= int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine("0");
                return;
            }

            int remainder = 0;

            List<string> result = new List<string>(); 

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(number[i].ToString());

                remainder += currentDigit * multiplier;
               
                if (remainder > 9)
                {
                    result.Add((remainder % 10 ).ToString());

                    remainder /= 10;
                }
                else
                {
                    result.Add(remainder.ToString());
                    remainder = 0;
                }
            }

            if (remainder > 0)
            {
                result.Add(remainder.ToString());
            }

            result.Reverse();

            foreach (var item in result)
            {
                Console.Write(item);
            }
        }
    }
}
