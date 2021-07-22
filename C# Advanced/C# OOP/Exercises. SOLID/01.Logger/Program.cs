using _01.Logger.Apppenders;
using _01.Logger.Core;
using _01.Logger.Enumerations;
using _01.Logger.Interfaces;
using _01.Logger.Layouts;
using _01.Logger.Loggers;

namespace _01.Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            //1.
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //ILogger logger = new Loggers.Logger(consoleAppender);
            //logger.Error("3/26/ 2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //2.
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);
            //var logger = new Loggers.Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", " Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //3.
            //ILayout xmlLayout = new XmlLayout();
            //IAppender consoleAppender = new ConsoleAppender(xmlLayout);
            //ILogger logger = new Loggers.Logger(consoleAppender);
            //logger.Fatal("3/31/2015 5:23:54 PM ", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM ", "No connection string found in App.config ");

            ////4.
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevelEnum.Error;
            //var logger = new Loggers.Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
            //System.Console.WriteLine(logger);

            Engine engine = new Engine();
            engine.Run();
        }
    }
}
