using System;

namespace SimpleSnake.GameObjects
{
    public class Progress
    {
        public static int Points { get; set; }

        public static int Level { get; set; }

        public static void AddProgrss(int points)
        {
            Points += points;
            Level = (int)Math.Round((decimal)Points / 12);
        }
    }
}
