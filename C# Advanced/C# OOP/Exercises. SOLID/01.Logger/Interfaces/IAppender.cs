using _01.Logger.Enumerations;

namespace _01.Logger.Interfaces
{
    public interface IAppender
    {
        public ReportLevelEnum ReportLevel { get; set; }

        void Append(string date, ReportLevelEnum reportLevel, string message);
    }
}
