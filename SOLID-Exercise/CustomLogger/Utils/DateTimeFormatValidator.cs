using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger.Utils
{
    public class DateTimeFormatValidator
    {

        private static readonly ISet<string> formats = new HashSet<string> { "M/dd/yyyy h:mm:ss tt" };
        public void AddFormat(string format)
        {
            if (!formats.Contains(format))
            {
                formats.Add(format);
            }
        }
        internal static bool IsDateTimeFormatExist(string createdTime)
        {
            foreach (var format in formats)
            {
                if (DateTime.TryParseExact(createdTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
