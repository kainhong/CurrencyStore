﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Utility.Query;

namespace CurrencyStore.Repository
{
    public interface IDeviceStatInfoRepository
    {
        List<DeviceStatInfo> GetList(int orgId, string orgFullPath, int deviceKind, int deviceModel, Pagination paging);
    }
}
