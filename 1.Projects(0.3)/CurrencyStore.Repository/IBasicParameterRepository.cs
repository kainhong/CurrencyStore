﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Repository
{
    public interface IBasicParameterRepository
    {
        bool CheckExists(BasicParameter objBasicParameter);
        void Save(BasicParameter objBasicParameter);
        BasicParameter GetObject(int pkId);
        List<BasicParameter> GetList();
    }
}
