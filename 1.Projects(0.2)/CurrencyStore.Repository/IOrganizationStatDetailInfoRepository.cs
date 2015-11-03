﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Repository
{
    public interface IOrganizationStatDetailInfoRepository
    {
        List<OrganizationStatDetailInfo> GetList(int orgId, string startTime, string endTime, int currencyKind, int deviceKind, int deviceModel);
    }
}
