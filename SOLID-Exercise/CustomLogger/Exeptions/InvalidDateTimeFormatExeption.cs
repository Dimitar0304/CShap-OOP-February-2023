using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Exeptions
{
    public class InvalidDateTimeFormatExeption:Exception
    {
        private const string DefaultMessage = "Invalid Date Time Format";
        public InvalidDateTimeFormatExeption():base(DefaultMessage)
        {
            
        }
        public InvalidDateTimeFormatExeption(string message):base(message)
        {
            
        }
    }
}
