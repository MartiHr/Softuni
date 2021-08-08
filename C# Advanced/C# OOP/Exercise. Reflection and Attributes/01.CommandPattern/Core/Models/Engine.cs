using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Exit")
            {
                string result = commandInterpreter.Read(command);

                if (result == null)
                {
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}
