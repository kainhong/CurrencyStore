using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace CurrencyStore.Client
{
    public static class DataCounter
    {
        private static int ConnectedClientCounter;
        private static int HeartbeatCounter;
        private static int LoginCounter;
        private static int BlacklistQueryCounter;
        private static int SingleBlacklistDownloadCounter;
        private static int RealBlacklistDownloadCounter;
        private static int CurrencyCounter;

        public static int ConnectedClientCount
        {
            get { return DataCounter.ConnectedClientCounter; }
        }
        public static int HeartbetaCount
        {
            get { return DataCounter.HeartbeatCounter; }
        }
        public static int LoginCount
        {
            get { return DataCounter.LoginCounter; }
        }
        public static int BlacklistQueryCount
        {
            get { return DataCounter.BlacklistQueryCounter; }
        }
        public static int SingleBlacklistDownloadCount
        {
            get { return DataCounter.SingleBlacklistDownloadCounter; }
        }
        public static int RealBlacklistDownloadCount
        {
            get { return DataCounter.RealBlacklistDownloadCounter; }
        }
        public static int CurrencyCount
        {
            get { return DataCounter.CurrencyCounter; }
        }

        static DataCounter()
        {
            DataCounter.ClearConnectedClient();
            DataCounter.Reset();
        }
        public static void AddConnectedClient()
        {
            Interlocked.Increment(ref DataCounter.ConnectedClientCounter);
        }
        public static void ClearConnectedClient()
        {
            DataCounter.ConnectedClientCounter = 0;
        }
        public static void AddHeartbeat()
        {
            Interlocked.Increment(ref DataCounter.HeartbeatCounter);
        }
        public static void AddLogin()
        {
            Interlocked.Increment(ref DataCounter.LoginCounter);
        }
        public static void AddBlacklistQuery()
        {
            Interlocked.Increment(ref DataCounter.BlacklistQueryCounter);
        }
        public static void AddSingleBlacklistDownload(int count)
        {
            if (DataCounter.SingleBlacklistDownloadCounter == 0)
            {
                DataCounter.SingleBlacklistDownloadCounter = count;
            }
        }
        public static void AddRealBlacklistDownload()
        {
            Interlocked.Increment(ref DataCounter.RealBlacklistDownloadCounter);
        }
        public static void AddCurrency()
        {
            Interlocked.Increment(ref DataCounter.CurrencyCounter);
        }
        public static void Reset()
        {
            DataCounter.HeartbeatCounter = 0;
            DataCounter.LoginCounter = 0;
            DataCounter.BlacklistQueryCounter = 0;
            DataCounter.SingleBlacklistDownloadCounter = 0;
            DataCounter.RealBlacklistDownloadCounter = 0;
            DataCounter.CurrencyCounter = 0;
        }
    }
}
