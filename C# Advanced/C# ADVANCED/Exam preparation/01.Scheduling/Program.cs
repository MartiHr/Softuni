using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksLine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> tasks = new Stack<int>();

            foreach (var task in tasksLine)
            {
                tasks.Push(task);
            }

            int[] threadsLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> threads = new Queue<int>();

            foreach (var thread in threadsLine)
            {
                threads.Enqueue(thread);
            }

            int taskToKill = int.Parse(Console.ReadLine());
            int killerThread = 0;

            while (tasks.Peek() != taskToKill)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                    
                    if (tasks.Peek() == taskToKill)
                    {
                        killerThread = threads.Peek();
                    }
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {killerThread} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
