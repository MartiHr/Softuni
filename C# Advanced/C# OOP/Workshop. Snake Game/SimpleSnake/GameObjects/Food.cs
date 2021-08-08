using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            FoodPoints = points;
            this.foodSymbol = foodSymbol;
            random = new Random();
        }

        public int FoodPoints { get; }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == TopY &&
                snake.LeftX == LeftX;
        }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPointOfSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElements
                    .Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
