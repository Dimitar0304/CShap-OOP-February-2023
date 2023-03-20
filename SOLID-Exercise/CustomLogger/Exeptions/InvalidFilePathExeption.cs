using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Exeptions
{
    public class InvalidFilePathExeption:Exception
    {
        private const string DefaultMessage = "Invalid FilePath Exeption";

        public InvalidFilePathExeption() : base(DefaultMessage)
        {

        }
        public InvalidFilePathExeption(string message) : base(message)
        {

        }
    }
}
