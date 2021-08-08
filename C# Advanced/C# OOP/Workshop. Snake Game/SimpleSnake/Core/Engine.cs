using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirection;
        private Direction direction;
        private Snake snake;
        private Wall wall;
        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            pointsOfDirection = new Point[4];
            sleepTime = 100;
        }

        public void Run()
        {
            CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        public void AskUserForRestart()
        {
            int leftX = wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX + 2, topY - 2);
            Console.Write($"Player points: {Progress.Points}");
            Console.SetCursorPosition(leftX + 2, topY - 1);
            Console.Write($"Player level: {Progress.Level}");

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n -> ");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over.");
            
            Console.SetCursorPosition(0, 21);
            Environment.Exit(0);
        }

        public void CreateDirections()
        {
            pointsOfDirection[0] = new Point(1, 0); // Right
            pointsOfDirection[1] = new Point(-1, 0); // Left
            pointsOfDirection[2] = new Point(0, 1); // Down
            pointsOfDirection[3] = new Point(0, -1); // Up
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }


    }
}
