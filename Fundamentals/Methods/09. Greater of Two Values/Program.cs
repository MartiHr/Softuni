using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            
            if (type == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                
                int greater = GetMax(a, b);
                
                Console.WriteLine(greater);
            }
            else if (type == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                
                char greater = GetMax(a, b);

                Console.WriteLine(greater);
            }
            else if (type == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                
                string greater = GetMax(a, b);
               
                Console.WriteLine(greater);
            }
        }
        
        static int GetMax(int a, int b)
        {
            int result = 0;
            
            if (a > b)
            {
                result = a;
            }
            else 
            {
                result = b;
            }

            return result;
        }
        static char GetMax(char a, char b)
        {
            int result = 0;

            if (a > b)
            {
                result = a;
            }
            else 
            {
                result = b;
            }

            return (char)result;
        }
        static string GetMax(string a, string b)
        {
            string result = "";

            if (a[0] > b[0])
            {
                result = a;
            }
            else 
            {
                result = b;
            }

            return result;
        }
    }
}
