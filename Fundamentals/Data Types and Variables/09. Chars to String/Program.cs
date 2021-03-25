using System;

namespace _09._Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            string combined = a.ToString() + b.ToString() + c.ToString();
            Console.WriteLine(combined);
        }
    }
}
