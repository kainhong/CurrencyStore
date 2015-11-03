﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Entity
{
    [Serializable]
    public class OrganizationStatDetailInfo
    {
        public int OrgId { get; set; }
        public string FaceAmount { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }
    }
}
