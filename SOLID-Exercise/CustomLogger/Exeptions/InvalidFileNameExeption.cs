using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Exeptions
{
    public class InvalidFileNameExeption:Exception
    {
        private const string DefaultMessage = "Invalid FileName Exeption";

        public InvalidFileNameExeption():base(DefaultMessage)
        {
            
        }
        public InvalidFileNameExeption(string message):base(message)
        {
            
        }
    }
}
