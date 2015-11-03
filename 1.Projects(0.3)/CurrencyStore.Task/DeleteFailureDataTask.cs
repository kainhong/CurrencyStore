using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.Task
{
    public class DeleteFailureDataTask
    {
        #region Datetime
        private static int EHour = 0;
        private static int EMinute = 0;
        private static int ESecond = 0;
        #endregion

        static DeleteFailureDataTask()
        {
            RefreshPeriod();
        }
        public static void Execute()
        {
            ICurrencyService currencyService = ServiceFactory.GetService<ICurrencyService>();
            IUserService userService = ServiceFactory.GetService<IUserService>();

            DateTime beforeTime = DateTime.Now.AddDays(-SystemParameter.DataStorageDays);

            currencyService.Clear_Info(beforeTime);
            userService.Clear_Login(beforeTime);
        }
        public static void Timer_Elapsed(object source, ElapsedEventArgs e)
        {
            int cHour = e.SignalTime.Hour;
            int cMinute = e.SignalTime.Minute;
            int cSecond = e.SignalTime.Second;

            if (cHour == DeleteFailureDataTask.EHour && cMinute == DeleteFailureDataTask.EMinute && cSecond == DeleteFailureDataTask.ESecond)
            {
                DeleteFailureDataTask.Execute();
            }
        }
        public static void RefreshPeriod()
        {
            DateTime temp = (DateTime.Now.ToShortDateString() + " " + SystemParameter.DataClearTime).ToDateTime();

            EHour = temp.Hour;
            EMinute = temp.Minute;
            ESecond = temp.Second;
        }
    }
}
