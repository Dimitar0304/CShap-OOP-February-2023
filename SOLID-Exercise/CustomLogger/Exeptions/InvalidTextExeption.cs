using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Exeptions
{
    public class InvalidTextExeption:Exception
    {
        private const string DefaultMessage = "Invalid Text";
        public InvalidTextExeption():base(DefaultMessage)
        {
        }
        public InvalidTextExeption(string message):base(message)
        {
            
        }

    }
}
