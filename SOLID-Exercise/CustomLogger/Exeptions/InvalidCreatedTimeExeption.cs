using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Exeptions
{
    public class InvalidCreatedTimeExeption:Exception
    {
        private const string DefaultMessage = "Invalid Created Time";
        public InvalidCreatedTimeExeption():base(DefaultMessage)
        {
            
        }
        public InvalidCreatedTimeExeption(string message):base(message)
        {
            
        }
    }
}
