
using System;
using Serilog;
using _2ndproject;
namespace SerilogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Properties:j} {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Class1 testclass = new Class1();

            /// <summary>
            /// One way to add Context
            /// </summary>
            var myLog = Log.ForContext<Program>();
            myLog.Information("Here is a log with context from the main method");
            Log.Information("Here is a log with no context from the same place");

            //run test 2 from 2nd class
            testclass.test2();

            //run test 1 from 2nd class
            testclass.test1();
            Console.WriteLine();           
            

            //with Exceptions
            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong and an exception was thrown");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
    }
}