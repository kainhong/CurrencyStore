using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;

namespace CurrencyStore.Task
{
    public class RequestPageTask
    {
        #region Datetime
        private static readonly int ESecond = 20;
        #endregion

        public static string PagePath
        {
            get;
            set;
        }

        public static void Execute()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(RequestPageTask.PagePath);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();

            if (receiveStream != null)
            {
                receiveStream.Close();
            }

            if (response != null)
            {
                response.Close();
            }

            if (request != null)
            {
                request.Abort();
            }
        }
        public static void Timer_Elapsed(object source, ElapsedEventArgs e)
        {
            int cSecond = e.SignalTime.Second;

            if (cSecond % RequestPageTask.ESecond == 0)
            {
                RequestPageTask.Execute();
            }
        }
    }
}
