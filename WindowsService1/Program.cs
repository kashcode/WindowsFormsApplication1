using System;
using System.ServiceProcess;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
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
