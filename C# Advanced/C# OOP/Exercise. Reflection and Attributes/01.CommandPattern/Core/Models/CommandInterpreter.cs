using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] elements = args
                       .Split(" ");

            string commandName = elements[0];
            string[] commandArgs = elements[1..];

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}Command");
            object instance = Activator.CreateInstance(commandType);

            ICommand command = instance as ICommand;
            return command.Execute(commandArgs);
        }
    }
}
