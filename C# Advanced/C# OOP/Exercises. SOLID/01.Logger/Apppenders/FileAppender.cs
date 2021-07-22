using _01.Logger.Enumerations;
using _01.Logger.Interfaces;
using System;

namespace _01.Logger.Apppenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            if (reportLevel < ReportLevel)
            {
                return;
            }

            MessageCount++;
            string content = string.Format(Layout.Template, date, reportLevel, message);

            LogFile.Write(content);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {LogFile.Size}";
        }
    }
}
