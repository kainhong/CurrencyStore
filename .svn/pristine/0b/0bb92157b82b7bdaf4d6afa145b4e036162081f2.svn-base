using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;


namespace CurrencyStore.Collector.Remoting
{
    public class RemoteAgency : MarshalByRefObject
    {
        static int port = 5501;
        static TcpChannel channel;
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        public static string Url { get; private set; }

        public static RemoteAgency Instance { get; private set; }

        public static void Start()
        {
            channel = ServerUtilities.GetTcpChannel("Agency" + "Channel", port, 100);
            Instance = new RemoteAgency();
            RemotingServices.Marshal(Instance, "Agency");
            ChannelDataStore store = channel.ChannelData as ChannelDataStore;
            Url = store.ChannelUris[0];
            System.Diagnostics.Trace.WriteLine("RemoteAgency\t listen at:" + Url);

            ProccessGuard.LaunchAgentProcess();
        }

        public static void Stop()
        {
            ProccessGuard.Release();
            ServerUtilities.SafeReleaseChannel(channel);
        }

        public void WaitRegist(string id)
        {
            _resetEvent.WaitOne(5000);
        }

        Dictionary<string, RemoteAgent> agents = new Dictionary<string, RemoteAgent>();
        public void Regist(string id, RemoteAgent agent)
        {
            agents.Add(id, agent);
            _resetEvent.Set();
        }

        public RemoteAgent GetRandmonAgent(int index)
        {
            index = Math.Abs(index % agents.Count);
            var key = agents.Keys.Skip(index).Take(1).First();
            return agents[key];
        }

        public RemoteAgent GetAgent(string id)
        {
            return agents[id];
        }
    }
}
