using _01.Logger.Enumerations;
using _01.Logger.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = new List<IAppender>(appenders);
        }

        public List<IAppender> Appenders { get; }

        public void Critical(string date, string message)
        {
            AppendAll(date, ReportLevelEnum.Critical, message);
        }

        public void Error(string date, string message)
        {
            AppendAll(date, ReportLevelEnum.Error, message);
        }

        public void Fatal(string date, string message)
        {
            AppendAll(date, ReportLevelEnum.Fatal, message);
        }

        public void Info(string date, string message)
        {
            AppendAll(date, ReportLevelEnum.Info, message);
        }

        public void Warning(string date, string message)
        {
            AppendAll(date, ReportLevelEnum.Warning, message);
        }

        private void AppendAll(string date, ReportLevelEnum reportLevelEnum, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(date, reportLevelEnum, message);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");
            foreach (var appender in Appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
