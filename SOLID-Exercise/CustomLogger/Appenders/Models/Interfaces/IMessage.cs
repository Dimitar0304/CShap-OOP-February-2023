using CustomLogger.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Appenders.Models.Interfaces
{
    public interface IMessage
    {
        public string CreatedTime { get;  }

        public string Text { get;  }

        public ReportLevel ReportLevel { get;  }
    }
}
