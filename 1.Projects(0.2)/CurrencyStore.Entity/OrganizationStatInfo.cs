﻿using System;
using System.Collections.Generic;

namespace CurrencyStore.Entity
{
    [Serializable]
    public class OrganizationStatInfo
    {
        public int OrgId { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }
    }
}
