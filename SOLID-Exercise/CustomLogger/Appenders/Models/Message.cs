using CustomLogger.Appenders.Models.Interfaces;
using CustomLogger.Enum;
using CustomLogger.Exeptions;
using CustomLogger.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Appenders.Models
{
    public class Message : IMessage
    {
        private List<string> formats;
        private string createdTime;
        private string text;

        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
            formats = new List<string>();
        }


        //Do validate for:
        //1 - Invalid text Input
        //2 - Invalid DateTime format
        //3 - Invalid Created time wrong exept

        public string CreatedTime
        {
            get=>createdTime;
          private  set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidCreatedTimeExeption();
                }
                if (!DateTimeFormatValidator.IsDateTimeFormatExist(value)==false)
                {
                    throw new InvalidDateTimeFormatExeption();
                }
                createdTime = value;
            }
        }

        public string Text
        {
            get=>text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidTextExeption();
                }
                text = value;
            }

        }

        public ReportLevel ReportLevel { get; private set; }

        
        
    }
}
