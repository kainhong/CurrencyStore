﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common.Query;
using CurrencyStore.Entity;

namespace CurrencyStore.Repository
{
    public interface IBasicDictionaryRepository
    {
        bool CheckExists(BasicDictionary objBasicDictionary);
        void Save(BasicDictionary objBasicDictionary);
        void Delete(int pkId);
        BasicDictionary GetObject(int pkId);
        List<BasicDictionary> GetList();
    }
}
