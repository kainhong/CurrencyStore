using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CurrencyStore.Collector.Configration;

namespace CurrencyStore.Collector
{
    public class ServerInstrumentation
    {
        const string CATEGORY_NAME = "Currency Store Server";
        const string NAME = "Server Performance Counter";
        private PerformanceCounter _connectedCounter;
        //private PerformanceCounter _disconnetedCounter;
        private PerformanceCounter _faultCounter;
        private PerformanceCounter _loginFailed;
        private PerformanceCounter _unregisted;
        private PerformanceCounter _produceCounterAvg;
        private PerformanceCounter _processCounterAvg;
        private PerformanceCounter _queueLength;

        /// <summary>
        /// 
        /// </summary>
        public static void SetupCategory()
        {
            RemoveCategory();
            //if (!PerformanceCounterCategory.Exists(CATEGORY_NAME)) {

            CounterCreationDataCollection CCDC = new CounterCreationDataCollection();

            CounterCreationData a = new CounterCreationData();
            a.CounterType = PerformanceCounterType.NumberOfItems32;
            a.CounterName = "Connected";
            CCDC.Add(a);

            //CounterCreationData b = new CounterCreationData();
            //b.CounterType = PerformanceCounterType.NumberOfItems64;
            //b.CounterName = "Disconneted";
            //CCDC.Add(b);

            CounterCreationData c = new CounterCreationData();
            c.CounterType = PerformanceCounterType.NumberOfItems64;
            c.CounterName = "Fault Count";
            CCDC.Add(c);

            CounterCreationData d1 = new CounterCreationData();
            d1.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
            d1.CounterName = "Produce/sec";
            CCDC.Add(d1);

            CounterCreationData d2 = new CounterCreationData();
            d2.CounterType = PerformanceCounterType.RateOfCountsPerSecond32;
            d2.CounterName = "Process/sec";
            CCDC.Add(d2);

            CounterCreationData d3 = new CounterCreationData();
            d3.CounterType = PerformanceCounterType.NumberOfItems64;
            d3.CounterName = "Login Failed";
            CCDC.Add(d3);

            CounterCreationData d4 = new CounterCreationData();
            d4.CounterType = PerformanceCounterType.NumberOfItems64;
            d4.CounterName = "Unregisted";
            CCDC.Add(d4);


            CounterCreationData d5 = new CounterCreationData();
            d5.CounterType = PerformanceCounterType.NumberOfItems32;
            d5.CounterName = "Queue length";
            CCDC.Add(d5);

            PerformanceCounterCategory.Create(CATEGORY_NAME, NAME,
                PerformanceCounterCategoryType.MultiInstance, CCDC);

            //}
        }
        private bool instrumentation;
        private ServerInstrumentation()
        {
            instrumentation = CurrencyStoreSection.Instance.Server.Instrumentation;

            if (instrumentation)
            {
                SetupCategory();
                InitCounter("CurrencyStore");
            }
        }

        public void Init()
        {

        }

        private void InitCounter(string name)
        {
            _connectedCounter = new PerformanceCounter(CATEGORY_NAME, "Connected", name, false);
            //_disconnetedCounter = new PerformanceCounter(CATEGORY_NAME, "Disconneted", name, false);
            _faultCounter = new PerformanceCounter(CATEGORY_NAME, "Fault Count", name, false);
            _produceCounterAvg = new PerformanceCounter(CATEGORY_NAME, "Produce/sec", name, false);
            _processCounterAvg = new PerformanceCounter(CATEGORY_NAME, "Process/sec", name, false);
            _loginFailed = new PerformanceCounter(CATEGORY_NAME, "Login Failed", name, false);
            _unregisted = new PerformanceCounter(CATEGORY_NAME, "Unregisted", name, false);
            _queueLength = new PerformanceCounter(CATEGORY_NAME, "Queue length", name, false);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void RemoveCategory()
        {
            if (PerformanceCounterCategory.Exists(CATEGORY_NAME))
            {
                PerformanceCounterCategory.Delete(CATEGORY_NAME);
            }
        }


        public void Connect()
        {
            if (instrumentation)
                _connectedCounter.Increment();
        }

        public void Disconnect()
        {
            if (instrumentation)
                _connectedCounter.IncrementBy(-1);
        }
        public void Fault(int value)
        {
            if (instrumentation)
                _faultCounter.IncrementBy(value);
        }

        public void Produce(int value)
        {
            if (instrumentation)
                _produceCounterAvg.IncrementBy(value);
        }
        public void Produce()
        {
            if (instrumentation)
                _produceCounterAvg.Increment();
        }

        public void Process(int value)
        {
            if (instrumentation)
                _processCounterAvg.IncrementBy(value);
        }

        public void LoginFailed()
        {
            if (instrumentation)
                _loginFailed.Increment();
        }

        public void Unregisted()
        {
            if (instrumentation)
                _unregisted.Increment();
        }

        public void Queue(int len)
        {
            if (instrumentation)
                _queueLength.IncrementBy(len);
        }

        public static readonly ServerInstrumentation Current = new ServerInstrumentation();

    }
}
