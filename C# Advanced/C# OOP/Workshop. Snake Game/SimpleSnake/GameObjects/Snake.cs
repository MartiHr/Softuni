using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Wall wall;
        private Queue<Point> snakeElements;
        private Food[] foods;
        private int foodIndex;
        private int nextLeftX;
        private int nextTopY;
        private const char snakeSymbol = '\u25CF';
        private const char emptySpace = ' ';
        private bool isFirstMove = true;

        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            foods = new Food[3];
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateSnake();
        }

        public int RandomFoodNumber =>
                new Random().Next(0, foods.Length);

        public void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool IsMoving(Point direction)
        {
            if (isFirstMove)
            {
                foods[foodIndex].SetRandomPosition(snakeElements);
                isFirstMove = false;
            }

            Point currentSnakeHead = snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                Eat(direction, snakeNewHead);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(emptySpace);

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;
            Progress.AddProgrss(foods[foodIndex].FoodPoints);

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            foodIndex = RandomFoodNumber;
            foods[foodIndex].SetRandomPosition(snakeElements);
        }
    }
}
