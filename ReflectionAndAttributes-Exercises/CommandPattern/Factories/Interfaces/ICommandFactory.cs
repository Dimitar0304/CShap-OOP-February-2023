using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Factories.Interfaces
{
    public interface ICommandFactory
    {
        ICommand Create(string input);
    }
}
