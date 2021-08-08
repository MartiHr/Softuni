using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public int LeftX { get; set; }

        public int TopY { get; set; }

        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(LeftX, TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
