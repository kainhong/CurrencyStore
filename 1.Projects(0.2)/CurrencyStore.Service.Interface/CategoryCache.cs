using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using CurrencyStore.Common;
using CurrencyStore.Entity;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using System.IO;
using Enyim.Caching;
namespace CurrencyStore.Services.Interface
{
    static class CategoryCache
    {
        static object _sync = new object();
        static Microsoft.Practices.EnterpriseLibrary.Caching.ICacheManager _impl;

        static System.Collections.Concurrent.ConcurrentDictionary<string, DeviceInfo> _deviceInfos = new ConcurrentDictionary<string, DeviceInfo>();
        static ElibLogging logger = new ElibLogging("trace");
        static CategoryCache()
        {
            _impl = CacheFactory.GetCacheManager("default");
            
        }

        public static void Init()
        {
            LoadDeviceInfo();
        }

        private static ConcurrentDictionary<string, DeviceInfo> LoadDeviceInfo()
        {
            var service = ServiceFactory.GetService<IDeviceService>();
            var items = service.GetList();
            var dict = new ConcurrentDictionary<string, DeviceInfo>();
            foreach (var item in items)
            {
                dict.TryAdd(item.DeviceNumber, item);
            }
            _impl.Add("DeviceInfo", dict, CacheItemPriority.High, null, GetICacheItemExpiration());
            logger.Info("device information updated.");
            return dict;
        }

        static ICacheItemExpiration GetICacheItemExpiration()
        {
            var path = System.Configuration.ConfigurationManager.AppSettings["cachedepencyfolder"];
            var file = Path.Combine(path, "deviceinfo.txt");
            if (!File.Exists(file))
                File.AppendAllText(file, DateTime.Now.ToString());
            return new Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.FileDependency(file);
        }

        public static bool AddDevice(DeviceInfo item)
        {
            Update();
            return _deviceInfos.TryAdd(item.DeviceNumber, item);
        }

        public static void UpdateDevice(DeviceInfo item)
        {
            Update();
            _deviceInfos[item.DeviceNumber] = item;
        }

        public static bool Removeevice(DeviceInfo item)
        {
            Update();
            return _deviceInfos.TryRemove(item.DeviceNumber, out item);
        }

        public static void Update()
        {
            var path = System.Configuration.ConfigurationManager.AppSettings["cachedepencyfolder"];
            var file = Path.Combine(path, "deviceinfo.txt");
            if (File.Exists(file))
            {
                File.AppendAllText(file, DateTime.Now.ToString());
            }
        }
        public static bool TryGetDeviceInfo(string key, out DeviceInfo device)
        {
            _deviceInfos = _impl.GetData("DeviceInfo") as ConcurrentDictionary<string, DeviceInfo>;
            if ( _deviceInfos == null)
            {
                lock (_sync)
                {
                    if( _deviceInfos == null)
                        _deviceInfos = LoadDeviceInfo();
                }
            }

            return _deviceInfos.TryGetValue(key, out device);
        }
    }
 
}
