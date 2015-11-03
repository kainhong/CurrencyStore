using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.Business
{
    public class DeviceCache : CacheBase<DeviceInfo>
    {
        public static readonly DeviceCache Current = new DeviceCache();
        private DeviceCache() : base() { }
        protected override IEnumerable<DeviceInfo> LoadItems()
        {
            var service = ServiceFactory.GetService<IDeviceService>();

            return service.GetAllList_Info();
        }
        protected override string Prefix
        {
            get { return "di_"; }
        }
        protected override string GetItemKey(DeviceInfo item)
        {
            return item.DeviceNumber;
        }
    }
}
