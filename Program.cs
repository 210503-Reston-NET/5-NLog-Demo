using System;
using NLog;
namespace NLogDemo
{

    public static class Program
    {
        public static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        public static void Main()
        {
            try
            {
            logger.Debug("This is a debug message");
            logger.Error("This is an error message");
            logger.Fatal("This is a fatal message");
            logger.Info("Hello World!");
            System.Console.ReadKey();


            }
            catch (Exception ex)
            {
            logger.Error(ex, "Goodbye cruel world");
            }
        }
    }  
}