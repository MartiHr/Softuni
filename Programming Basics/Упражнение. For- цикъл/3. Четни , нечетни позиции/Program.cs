using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Четни___нечетни_позиции
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double evenSum = 0;
            double evenMax = double.MinValue;
            double evenMin = double.MaxValue;

            double oddSum = 0;
            double oddMax = double.MinValue;
            double oddMin = double.MaxValue;

            for (int i = 1; i <=n ; i++)
            {
                if (i%2==0)
                {
                    double aChetno = double.Parse(Console.ReadLine());
                    evenSum = evenSum + aChetno;

                    if (aChetno>evenMax)
                    {
                        evenMax = aChetno;
                    }
                    if (aChetno<evenMin)
                    {
                        evenMin = aChetno;
                    }
                }
                else
                {
                    double aNechetno= double.Parse(Console.ReadLine());
                    oddSum = oddSum + aNechetno;

                    if (aNechetno> oddMax)
                    {
                        oddMax = aNechetno;
                    }
                    if (aNechetno< oddMin)
                    {
                        oddMin = aNechetno;
                    }


                }


            }

   
            Console.WriteLine($"OddSum={oddSum:f2},");
           
            if (oddMin!=double.MaxValue)
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }
            else
            {
                Console.WriteLine("OddMin=No,");
            }
           
            if (oddMax != double.MinValue)
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            else
            {
                Console.WriteLine("OddMax=No,");
            }


            Console.WriteLine($"EvenSum={evenSum:f2},");
           
            if (evenMin != double.MaxValue)
            {
                Console.WriteLine($"EvenMin={evenMin:f2}," );
            }
            else
            {
                Console.WriteLine("EvenMin=No,");
            }
           
            
            if (evenMax != double.MinValue)
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
            else
            {
                Console.WriteLine("EvenMax=No");
            }



        }
    }
}
