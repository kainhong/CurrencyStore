using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Business;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    [TestClass()]
    public class DeviceCacheTest
    {
        [TestMethod()]
        public void CacheTest()
        {
            string key = "ABC";
            var item = new DeviceInfo() { DeviceNumber = key, KindCode = 1, OrgId = 1 };

            DeviceCache.Current.Set(item);
            var actual = DeviceCache.Current.Get(key);
            Assert.IsNotNull(actual);

            item.OrgId = 2;
            DeviceCache.Current.Set(item);
            actual = DeviceCache.Current.Get(key);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.OrgId == 2);

            DeviceCache.Current.Remove(key);
            actual = DeviceCache.Current.Get(key);
            Assert.IsNull(actual);
        }
    }
}
