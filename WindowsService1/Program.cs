using System;
using System.ServiceProcess;

[assembly:log4net.Config.XmlConfigurator]

namespace WindowsService1
{
    static class Program
    {
        private static log4net.ILog _logger;
        private static log4net.ILog Logger
        {
            get
            {
                if (_logger != null) return _logger;
                _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                return _logger;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //log4net.Config.BasicConfigurator.Configure();
            //log4net.Config.XmlConfigurator.Configure();

            //var logger = log4net.LogManager.GetLogger(typeof (Program));
            Logger.Info("Hello from log4net!");

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
