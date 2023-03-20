using CustomLogger.Appenders.Interfaces;
using CustomLogger.Appenders.Models.Interfaces;
using CustomLogger.Enum;
using CustomLogger.IO.Interfaces;
using CustomLogger.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel=ReportLevel.Info)
        {
            Layout = layout;
            LogFile = logFile;
            ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ILogFile LogFile { get; private set; }
        public ReportLevel ReportLevel { get; private set; }

        public int MessageAppended { get; private set;}

        public void AppendMessage(IMessage message)
        {
            string content = string.Format(Layout.Format,
                message.CreatedTime,message.ReportLevel,message.Text);
            LogFile.WriteLine(content);
            File.AppendAllText(LogFile.FullPath, content + Environment.NewLine);
            MessageAppended++;
        }
        public override string ToString()
       => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessageAppended}, File size: {LogFile.Size}";
    }

}

