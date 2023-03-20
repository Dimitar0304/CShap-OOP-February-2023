using CustomLogger.Appenders.Interfaces;
using CustomLogger.Appenders.Models;
using CustomLogger.Appenders.Models.Interfaces;
using CustomLogger.Enum;
using CustomLogger.Loggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }
        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }
        public void Critical(string dateTime, string text)
        {
            throw new NotImplementedException();
        }

        public void Error(string dateTime, string text)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string dateTime, string text)
        {
            throw new NotImplementedException();
        }

        public void Info(string dateTime, string text)
        {
            throw new NotImplementedException();
        }

        public void Warning(string dateTime, string text)
        {
            throw new NotImplementedException();
        }
        private void AppendAll(string dateTime, string text, ReportLevel reportLevel)
        {
            IMessage message = new Message(dateTime, text, reportLevel);

            foreach (var appender in appenders)
            {
                if (message.ReportLevel>=appender.ReportLevel)
                {
                    appender.AppendMessage(message);
                }
            }
        }
    }
}
