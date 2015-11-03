using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CurrencyStore.Communication;
using CurrencyStore.Entity;

namespace CurrencyStore.BatchInsert
{
    public class SourceData
    {
        public static CurrencyInfo Value { get; set; }

        static SourceData()
        {
            string fileName = Application.StartupPath + @"\data.svd";

            using (CurrencyFileReader fileReader = new CurrencyFileReader(fileName))
            {
                FileHeader fileHeader = fileReader.FileHeader;
                SourceData.Value = fileReader.Read(false).First();
            }
        }

        public static void Create(bool isInsertCurrencyImage)
        {
            SourceData.Value.CurrencyImage = isInsertCurrencyImage ? SourceData.Value.CurrencyImage : new byte[] { 0 };
        }
    }
}
