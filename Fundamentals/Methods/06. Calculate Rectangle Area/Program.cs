using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
           
            double area = CalcRectangleArea(width, height);
           
            Console.WriteLine(area);
        }

        static int CalcRectangleArea(int width, int height)
        {
            return width * height;
        }
    }
}
