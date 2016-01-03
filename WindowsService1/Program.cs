using System;
using System.ServiceProcess;

[assembly:log4net.Config.XmlConfigurator]

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //log4net.Config.BasicConfigurator.Configure();
            //log4net.Config.XmlConfigurator.Configure();

            var logger = log4net.LogManager.GetLogger(typeof (Program));
            logger.Info("Hello from log4net!");

            if (!Environment.UserInteractive)
            {
                var servicesToRun = new ServiceBase[]
                {
                    new MyService()
                };
                ServiceBase.Run(servicesToRun);
            }
            else
            {
                var myService = new MyService();
                myService.WriteMessage("Debug");
                Console.WriteLine("Service start...");

                Console.ReadKey();
            }
        }
    }
}
