using System;
using System.Timers;

namespace CurrencyStore.Task
{
    public static class TaskFactory
    {
        private static readonly object locker = new object();
        private static Timer CurrentTimer
        {
            get;
            set;
        }
        public static void CreateTimer()
        {
            lock (locker)
            {
                if (TaskFactory.CurrentTimer == null)
                {
                    lock (locker)
                    {
                        TaskFactory.CurrentTimer = new Timer()
                        {
                            Interval = 1000,
                            Enabled = true,
                            AutoReset = true
                        };

                        TaskFactory.CurrentTimer.Elapsed += new ElapsedEventHandler(ExportCurrencyTask.Timer_Elapsed);
                        TaskFactory.CurrentTimer.Elapsed += new ElapsedEventHandler(RequestPageTask.Timer_Elapsed);
                        TaskFactory.CurrentTimer.Elapsed += new ElapsedEventHandler(DeleteFailureDataTask.Timer_Elapsed);
                    }
                }
            }
        }
    }
}
