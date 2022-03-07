using System;
using System.Text;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = Console.ReadLine().ToUpper();

            int width = (3 * n) + 6;
            int height = (3 * n) + 1;

            string cup = DrawCup(n, text, width, height);
            Console.WriteLine(cup);
        }

        public static string DrawCup(int n, string text, int width, int height)
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(DrawSteam(n, width));
            result.AppendLine(DrawTopPart(n, width, text));
            result.AppendLine(DrawMiddlePart(n, width));
            result.AppendLine(DrawBottomPart(width));

            return result.ToString().TrimEnd();
        }

        private static string DrawBottomPart(int width)
        {
            string result = string.Empty;

            for (int i = 0; i < width - 1; i++)
            {
                result += '-';
            }

            return result;
        }

        public static string DrawMiddlePart(int n, int width)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string line = string.Empty;

                for (int j = 0; j < i; j++)
                {
                    line += ' ';
                }

                line += '\\';

                for (int k = 0; k < width - n - (i * 2) - 2; k++)
                {
                    line += '@';
                }

                line += '/';
            
                sb.AppendLine(line);
            }

            return sb.ToString().TrimEnd();
        }

        public static string DrawTopPart(int n, int width, string text)
        {
            StringBuilder sb = new StringBuilder();

            string firstLine = string.Empty;
            for (int i = 0; i < width - 1; i++)
            {
                firstLine += '=';
            }

            sb.AppendLine(firstLine);

            StringBuilder middlePart = new StringBuilder();
            for (int i = 0; i < n - 2; i++)
            {
                string line = string.Empty;

                line += '|';

                if (i == (n - 2) / 2)
                {
                    for (int j = 0; j < (width - n - 2 - text.Length) / 2; j++)
                    {
                        line += '~';
                    }

                    line += text;

                    for (int j = 0; j < (width - n - 2 - text.Length) / 2; j++)
                    {
                        line += '~';
                    }
                }
                else
                {
                    for (int j = 0; j < width - n - 2; j++)
                    {
                        line += '~';
                    }
                }

                line += '|';

                for (int j = 0; j < n - 1; j++)
                {
                    line += ' ';
                }

                line += '|';

                middlePart.AppendLine(line);
            }

            sb.AppendLine(middlePart.ToString().TrimEnd());

            string lastLine = string.Empty;
            for (int i = 0; i < width - 1; i++)
            {
                lastLine += '=';
            }

            sb.AppendLine(lastLine);

            return sb.ToString().TrimEnd();
        }

        public static string DrawSteam(int n, int width)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string innerRes = string.Empty;

                for (int j = 0; j < n; j++)
                {
                    innerRes += ' ';
                }

                innerRes += "~ ~ ~";

                sb.AppendLine(innerRes);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
