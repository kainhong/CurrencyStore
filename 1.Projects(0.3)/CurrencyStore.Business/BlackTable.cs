using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using CurrencyStore.Common;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using Enyim.Caching;

namespace CurrencyStore.Business
{
    [Serializable]
    public class BlackTable
    {
        public BlackTable()
        {
            this.CurrenciesNumber = new List<byte[]>();
        }
        public int Version { get; set; }
        public List<byte[]> CurrenciesNumber { get; set; }
        public static byte[] Blank = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    public static class BlackTableHelper
    {
        static BlackTable _table = new BlackTable();
        static object _sync = new object();
        static MemcachedClient _client = new MemcachedClient();
        static ElibLogging logger = new ElibLogging("trace");

        public static BlackTable Load()
        {
            var version = GetVersion();
            var service = ServiceFactory.GetService<ICurrencyService>();
            var lst = service.GetList_Blacklist(null, null);
            var table = new BlackTable();
            table.Version = version;
            table.CurrenciesNumber = new List<byte[]>();
            foreach (var item in lst)
            {
                var val = GetCurrencyNumberBytes(item);
                table.CurrenciesNumber.Add(val);
            }
            string key = "BlackTable";
            _client.AddOrReplace(key, table);
            logger.Info("black table information updated.");
            return table;
        }
        public static byte[] GetCurrencyNumberBytes(CurrencyBlacklist item)
        {
            var buff = new byte[18];
            buff[0] = item.CurrencyKindCode;
            var tmp = BitConverter.GetBytes(item.FaceAmount);
            buff[1] = tmp[1];
            buff[2] = tmp[0];
            tmp = BitConverter.GetBytes(item.CurrencyVersion);
            buff[3] = tmp[1];
            buff[4] = tmp[0];
            tmp = System.Text.Encoding.ASCII.GetBytes(item.CurrencyNumber);
            for (int i = 0; i < tmp.Length; i++)
            {
                buff[i + 5] = tmp[i];
            }
            return buff;
        }
        private static int GetVersion()
        {
            return Convert.ToInt32(SystemParameter.BlacklistVersion);
        }
        public static byte[] GetBlackTableVersion(BlackTable table)
        {
            var version = table.Version.ToString();

            if (version == "0")
            {
                version = "20000101";
            }

            var result = new byte[3];

            for (int i = 0; i < 3; i++)
            {
                var val = version.Substring(i * 2 + 2, 2);
                var j = Convert.ToInt16(val);
                result[i] = Convert.ToByte(j);
            }

            return result;
        }
        public static BlackTable GetBlackTable()
        {
            _table = _client.Get<BlackTable>("BlackTable");

            if (_table == null)
            {
                lock (_sync)
                {
                    if (_table == null)
                    {
                        _table = Load();
                    }
                }
            }

            return _table;
        }
        public static void Update()
        {
            Load();
        }
    }
}
