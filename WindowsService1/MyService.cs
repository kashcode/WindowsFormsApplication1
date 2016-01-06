using System;
using System.Globalization;
using System.ServiceProcess;

namespace WindowsService1
{
    public partial class MyService : ServiceBase
    {
        private System.Timers.Timer _timer;
        private bool _timerTaskSuccess;

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

        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                //
                // Create and start a timer.
                //
                _timer = new System.Timers.Timer {Interval = 60000}; // every one min
                _timer.Elapsed += _timer_Elapsed;
                _timer.AutoReset = false;  // makes it fire only once
                _timer.Start(); // Start

                _timerTaskSuccess = false;
            }
            catch (Exception ex)
            {
                // omitted
            }
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                WriteMessage(DateTime.Now.ToString(CultureInfo.InvariantCulture));

                _timerTaskSuccess = true;
            }
            catch (Exception ex)
            {
                _timerTaskSuccess = false;
            }
            finally
            {
                if (_timerTaskSuccess)
                {
                    _timer.Start();
                }
            }
        }

        public void WriteMessage(string message)
        {
            Logger.Debug(message);
        }

        protected override void OnStop()
        {
            try
            {
                // Service stopped. Also stop the timer.
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }
            catch (Exception ex)
            {
                // omitted
            }
        }
    }
}
