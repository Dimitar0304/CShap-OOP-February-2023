using CommandPattern.Factories;
using CommandPattern.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
      
        public string Read(string args)
        {
            ICommandFactory commandFactory = new CommandFactory();

            ICommand obj = commandFactory.Create(args);

            string[] commandArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            return obj.Execute(commandArgs);
        }
    }
}
