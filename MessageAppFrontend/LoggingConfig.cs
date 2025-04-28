using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Config;
using NLog.Targets;
using NLog;

namespace MessageAppFrontend
{
    public static class LoggingConfig
    {
        public static void Setup()
        {
            var config = new LoggingConfiguration();

            var logfile = new FileTarget("logfile")
            {
                FileName = "Logs/errors.txt",
                Layout = "${longdate} | ${level:uppercase=true} | ${logger} | ${message} ${exception:format=ToString}"
            };

            config.AddRule(LogLevel.Warn, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }
    }
}
