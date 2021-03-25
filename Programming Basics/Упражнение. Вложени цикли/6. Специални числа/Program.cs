using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Специални_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            
            for (int i = 1111; i < 9999; i++)
            {
                string text = i.ToString();
                bool isSpecial = true;

                for (int j = 0; j < text.Length; j++)
                {
                    int currentDigit = int.Parse(text[j].ToString());
                   
                    if (currentDigit==0 || n%currentDigit!=0)
                    {
                        isSpecial = false;
                        break;
                    }
                }
             
                if (isSpecial)
                {
                    Console.Write($"{i} ");
                }

            }

        }
    }
}
