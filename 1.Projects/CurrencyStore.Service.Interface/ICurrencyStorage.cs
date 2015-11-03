using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;

namespace CurrencyStore.Service.Interface
{
    public interface ICurrencyStorage
    {
        void BatchSave_Info(List<CurrencyInfo> values);
    }
}
