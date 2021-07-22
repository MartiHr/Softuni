using _01.Logger.Enumerations;
using _01.Logger.Interfaces;

namespace _01.Logger.Apppenders
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevelEnum ReportLevel { get; set; }

        public int MessageCount { get; protected set; }

        public abstract void Append(string date, ReportLevelEnum reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, " +
                $"Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessageCount}";
        }
    }
}

