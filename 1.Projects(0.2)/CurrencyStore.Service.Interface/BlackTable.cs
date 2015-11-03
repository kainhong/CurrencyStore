using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common;
using CurrencyStore.Services.Interface;
using CurrencyStore.Entity;
using System.IO;
using System.Timers;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Enyim.Caching;
namespace CurrencyStore.Services.Interface
{
    [Serializable]
    public class BlackTable
    {
        public BlackTable()
        {
            this.CurrenciesNumber = new List<byte[]>();
        }

        public List<byte[]> CurrenciesNumber { get; set; }

        public int Version { get; set; }

        public static byte[] Blank = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    public static class BlackTableHelper//:CacheBase<BlackTable>
    {
        static BlackTable _table = new BlackTable();
        static object _sync = new object();
        static MemcachedClient _client = new MemcachedClient();
        static ElibLogging logger = new ElibLogging("trace");

        public static BlackTable Load()
        {
            var version = GetVersion();
            var service = ServiceFactory.GetService<ICurrencyService>();
            var lst = service.GetBlacklist();
            var table = new BlackTable();
            table.Version = version;
            table.CurrenciesNumber = new List<byte[]>();
            foreach (var item in lst)
            {
                var val = GetCurrencyNumberBytes(item);
                table.CurrenciesNumber.Add(val);
            }
            string key = "BlackTable";

            var result = _client.Store(Enyim.Caching.Memcached.StoreMode.Add, key, table);
            
            if (!result)
                result = _client.Store(Enyim.Caching.Memcached.StoreMode.Replace, key, table);
            
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
            tmp = BitConverter.GetBytes(item.Version);
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
            var service = ServiceFactory.GetService<IBasicService>();
            var obj = service.GetParameter("BlacklistVersion");
            if (obj == null)
                return 0;
            return Convert.ToInt32(obj.ParamValue);
        }

        public static byte[] GetBlackTableVersion(BlackTable table)
        {
            var version = table.Version.ToString();
            if (version == "0")
                version = "20000101";
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
                        _table = Load();
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
