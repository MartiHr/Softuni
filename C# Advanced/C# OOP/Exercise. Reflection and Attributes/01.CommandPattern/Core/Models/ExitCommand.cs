using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
