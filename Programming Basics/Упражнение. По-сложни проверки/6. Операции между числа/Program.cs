using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Операции_между_числа
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = int.Parse(Console.ReadLine());
            double second= int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            double n = 0;
            if (second==0)
            {
                Console.WriteLine($"Cannot divide {first} by zero");
            }
            else
            {
                switch (symbol)
                {
                    case "+":
                        n = first + second;
                        if (n % 2 == 0)
                        {
                            Console.WriteLine($" { first} {symbol} {second} = {n} - even");
                        }
                        else
                        {
                            Console.WriteLine($" { first} {symbol} {second} = {n} - odd");
                        }

                        break;
                    case "-":
                        n = first - second;
                        if (n % 2 == 0)
                        {
                            Console.WriteLine($" { first} {symbol} {second} = {n} - even");
                        }
                        else
                        {
                            Console.WriteLine($" { first} {symbol} {second} = {n} - odd");
                        }
                        break;
                    case "*":
                        n = first * second;
                        if (n % 2 == 0)
                        {
                            Console.WriteLine($" { first} {symbol} {second} = {n} - even");
                        }
                        else
                        {
                            Console.WriteLine($" { first} {symbol} {second} = {n} - odd");
                        }
                        break;
                    case "/":
                        n = first / second;
                        Console.WriteLine($"{first} / {second} = {n:f2}");
                        break;
                    case "%":
                        n = first % second;
                        Console.WriteLine($"{first} % {second} = {n}");
                        break;

                }

            }


        }
    }
}
