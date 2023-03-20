using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Exeptions
{
    public class InvalidFileExtentionExeption:Exception
    {

        private const string DefaultMessage = "Invalid FileExtention Exeption";

        public InvalidFileExtentionExeption() : base(DefaultMessage)
        {

        }
        public InvalidFileExtentionExeption(string message) : base(message)
        {

        }
    }
}
