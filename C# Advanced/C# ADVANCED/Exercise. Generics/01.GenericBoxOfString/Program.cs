using System;

namespace _01.GenericBoxOfString
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                Box<string> currentBox = new Box<string>(str);
                Console.WriteLine(currentBox.ToString());
            }
        }
    }
}
