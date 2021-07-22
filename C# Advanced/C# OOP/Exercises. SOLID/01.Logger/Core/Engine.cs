using _01.Logger.Apppenders;
using _01.Logger.Enumerations;
using _01.Logger.Interfaces;
using _01.Logger.Layouts;
using _01.Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Logger.Core
{
    public class Engine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appendersParts = Console.ReadLine()
                    .Split(" ");

                string appenderType = appendersParts[0];
                string layoutType = appendersParts[1];

                ReportLevelEnum reportLevel = appenders.Length == 3
                    ? Enum.Parse<ReportLevelEnum>(appendersParts[2], true)
                    : ReportLevelEnum.Info;

                ILayout layout = LayoutCreator(layoutType);

                IAppender appender = AppenderCreator(appenderType, layout, reportLevel);

                appenders[i] = appender;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('|');

                string reportLevel = tokens[0];
                string date = tokens[1];
                string message = tokens[2];

                ILogger logger = new Loggers.Logger(appenders);

                switch (reportLevel.ToLower())
                {
                    case "info": logger.Info(date, message); break;
                    case "warning": logger.Warning(date, message); break;
                    case "error": logger.Error(date, message); break;
                    case "critical": logger.Critical(date, message); break;
                    case "fatal": logger.Fatal(date, message); break;
                }
            }

            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }

        private IAppender AppenderCreator(string type, ILayout layout, ReportLevelEnum reportLevel)
        {
            IAppender appender = null;

            switch (type)
            {
                case nameof(ConsoleAppender):

                    appender = new ConsoleAppender(layout) { ReportLevel = reportLevel };

                    break;
                case nameof(FileAppender):

                    appender = new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel };

                    break;
            }

            return appender;
        }

        private ILayout LayoutCreator(string type)
        {
            ILayout layout = null;

            switch (type)
            {
                case nameof(SimpleLayout):

                    layout = new SimpleLayout();

                    break;

                case nameof(XmlLayout):

                    layout = new XmlLayout();

                    break;
            }

            return layout;
        }
    }
}
