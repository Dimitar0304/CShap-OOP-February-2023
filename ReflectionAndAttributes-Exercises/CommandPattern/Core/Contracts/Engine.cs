using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CommandPattern.Core.Contracts
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    Console.WriteLine(commandInterpreter.Read(input)); 

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }


            }



        }
    }
}
