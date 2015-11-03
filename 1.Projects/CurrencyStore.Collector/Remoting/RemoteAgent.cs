using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Collector.Configration;
using CurrencyStore.Collector.Storage;

namespace CurrencyStore.Collector.Remoting
{
    public class RemoteAgent : MarshalByRefObject, ICurrencyStorage
    {
        static RemoteAgent instance;
        ICurrencyStorage service;
        public string Id { get; set; }

        public RemoteAgent()
        {
            var storaged = CurrencyStoreSection.Instance.Task.Storage.Enable;
            if (!storaged)
                service = new EmptyStorage();
            var type = CurrencyStoreSection.Instance.Task.Storage.Type;
            if (type == "file")
                service = new FileStorage();
            else if (type == "empty")
                service = new EmptyStorage();
            else
                service = ServiceFactory.GetService<ICurrencyService>();
        }


        public static RemoteAgent Regist(string id, string address)
        {
            if (instance != null)
                return instance;

            RemoteAgency agent;
            ServerUtilities.GetTcpChannel();
            agent = Activator.GetObject(typeof(RemoteAgency), address) as RemoteAgency;
            instance = new RemoteAgent() { Id = id };
            agent.Regist(id, instance);
            return instance;
        }

        public void BatchSave_Info(List<Entity.CurrencyInfo> values)
        {
            var action = new Action(() => { service.BatchSave_Info(values); });
            action.BeginInvoke((ar) =>
            {
                action.EndInvoke(ar);
                ServerInstrumentation.Current.Queue(-1);
            }, action);
        }
    }
}
