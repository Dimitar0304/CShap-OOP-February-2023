using CommandPattern.Core.Contracts;
using CommandPattern.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand Create(string input)
        {
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandInfo = tokens[0];

            string[] commandArgs = tokens.Skip(1).ToArray();

            Type currentCommand = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name == $"{commandInfo}Command");

            if (currentCommand is null)
            {
                throw new InvalidOperationException("Invalid command type");
            }

           return Activator.CreateInstance(currentCommand) as ICommand;
        }
    }
}
