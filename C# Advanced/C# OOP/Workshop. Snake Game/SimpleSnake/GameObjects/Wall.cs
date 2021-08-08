using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeBorders();
        }

        /// <param name="snake">snake head</param>
        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.TopY == TopY ||
                snake.LeftX == 0 || snake.LeftX == LeftX;
        }

        private void InitializeBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY);

            SetVerticalLine(0);
            SetVerticalLine(LeftX - 1);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }
    }
}
