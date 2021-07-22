using _01.Logger.Enumerations;
using _01.Logger.Interfaces;
using System;

namespace _01.Logger.Apppenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            if (reportLevel < ReportLevel)
            {
                return;
            }

            MessageCount++;
            string content = string.Format(Layout.Template, date, reportLevel, message);

            Console.WriteLine(content);
        }
    }
}
