using System;
using NLog;

namespace NLogDemo
{
    class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();

            
            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
                        
            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logconsole);
            
            //config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
                        
            // Apply config           
            NLog.LogManager.Configuration = config;

            
    
            try
            {
                Logger.Debug("This is a debug message");
                Logger.Error("This is an error message");
                Logger.Fatal("This is a fatal message");
                Logger.Info("Hello World!");

                throw new Exception("oops");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Goodbye cruel world");
            }
            
        }
    }    
}