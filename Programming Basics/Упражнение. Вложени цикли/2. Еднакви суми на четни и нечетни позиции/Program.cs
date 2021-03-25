using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Еднакви_суми_на_четни_и_нечетни_позиции
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

           

            for (int i = firstNum; i <= secondNum; i++)
            {
                string currentNum = i.ToString();
                
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDigit = int.Parse(currentNum[j].ToString());
                    if (j%2==0)
                    {
                        evenSum += currentDigit;
                    }
                    else
                    {
                        oddSum += currentDigit;
                    }
                }
                if (oddSum == evenSum)
                {
                    Console.Write(i+" ");
                }
            }




        }
    }
}
