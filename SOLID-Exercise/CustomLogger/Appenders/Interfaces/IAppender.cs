using CustomLogger.Appenders.Models.Interfaces;
using CustomLogger.Enum;
using CustomLogger.Layouts.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomLogger.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        public int MessageAppended { get; }

        void AppendMessage(IMessage message);



    }
}
