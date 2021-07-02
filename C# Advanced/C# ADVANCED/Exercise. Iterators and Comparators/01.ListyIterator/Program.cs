using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] elements = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (elements[0])
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(elements.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }
            }
        }
    }
}
