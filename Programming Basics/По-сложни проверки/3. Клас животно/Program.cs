﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Клас_животно
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal = Console.ReadLine();

            switch (animal)
            {
                case "dog": Console.WriteLine("mammal");
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                Console.WriteLine("reptile");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }




        }
    }
}
