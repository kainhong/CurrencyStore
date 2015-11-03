using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Common;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using System.Threading;

namespace CurrencyStore.BatchInsert
{
    public class Batcher
    {
        ICurrencyService currencyService = ServiceFactory.GetService<ICurrencyService>();

        private int BatchCount { get; set; }
        private int TargetCurrencyCount { get; set; }
        private int TotalBatch { get; set; }
        public int RealInsertCurrencyCount { get; private set; }
        private List<CurrencyInfo> Value { get; set; }

        public Batcher(int batchCount, int targetCurrencyCount)
        {
            this.BatchCount = batchCount;
            this.TargetCurrencyCount = targetCurrencyCount;

            this.TotalBatch = this.TargetCurrencyCount / this.BatchCount;

            if (this.TargetCurrencyCount % this.BatchCount != 0)
            {
                this.TotalBatch += 1;
            }

            this.Value = this.CreateInesrtData(SourceData.Value, this.BatchCount);
        }

        public void Insert()
        {
            for (int i = 1; i <= this.TotalBatch; i++)
            {
                currencyService.BatchSave_Info(this.Value);

                this.RealInsertCurrencyCount += this.BatchCount;

                DataCounter.AddCurrency(this.BatchCount);
            }
        }

        private List<CurrencyInfo> CreateInesrtData(CurrencyInfo sourceData, int currencyCount)
        {
            var result = new List<CurrencyInfo>();

            for (int i = 0; i < currencyCount; i++)
            {
                result.Add(new CurrencyInfo()
                {
                    OrgId = sourceData.OrgId,
                    DeviceNumber = sourceData.DeviceNumber,
                    DeviceKindCode = sourceData.DeviceKindCode,
                    DeviceModelCode = sourceData.DeviceModelCode,
                    OperatorNumber = sourceData.OperatorNumber,
                    OperateTime = sourceData.OperateTime,
                    BusinessType = sourceData.BusinessType,
                    ClientCardNumber = sourceData.ClientCardNumber,
                    BatchNumber = sourceData.BatchNumber,
                    OrderNumber = sourceData.OrderNumber,
                    CurrencyKindCode = sourceData.CurrencyKindCode,
                    FaceAmount = sourceData.FaceAmount,
                    CurrencyVersion = sourceData.CurrencyVersion,
                    CurrencyType = sourceData.CurrencyType,
                    PortNumber = sourceData.PortNumber,
                    IsSuspicious = sourceData.IsSuspicious,
                    CurrencyNumber = sourceData.CurrencyNumber,
                    CurrencyImageType = sourceData.CurrencyImageType,
                    CurrencyImage = sourceData.CurrencyImage
                });
            }

            return result;
        }
    }
}
