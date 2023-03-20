using CustomLogger.Appenders.Interfaces;
using CustomLogger.Appenders.Models.Interfaces;
using CustomLogger.Enum;
using CustomLogger.Layouts.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ReportLevel reportlevel;
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            this.ReportLevel = reportLevel;

        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public int MessageAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            Console.WriteLine(string.Format(Layout.Format, message.CreatedTime
                , message.ReportLevel, message.Text));
            MessageAppended++;
        }
        public override string ToString()
       => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessageAppended}";
    }

}

