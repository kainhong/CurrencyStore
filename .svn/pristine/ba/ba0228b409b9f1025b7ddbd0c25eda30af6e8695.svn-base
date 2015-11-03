using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Diagnostics;
using CurrencyStore.Utility;

namespace CurrencyStore.Collector.Remoting
{
    internal sealed class ProccessGuard
    {

        static Dictionary<Guid, AgentRecord> _processes = new Dictionary<Guid, AgentRecord>();
        static int agentCount;
        public static void LaunchAgentProcess()
        {
            var folder = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory);
            var sub = folder.GetDirectories();
            foreach (var dir in sub)
            {
                if (dir.Name.StartsWith("_"))
                    continue;
                var file = Path.Combine(dir.FullName, "CurrencyStore.Agent.exe");
                if (!File.Exists(file))
                    continue;
                LaunchAgentProcess(file);
                agentCount += 1;
            }
        }

        public static void Release()
        {
            foreach (var p in _processes.Values)
            {
                p.Stop();
            }
        }

        internal static void LaunchAgentProcess(string file)
        {
            var record = AgentRecord.Create(file);
            _processes.Add(record.Id, record);
            record.Launch();
        }
    }

    class AgentRecord
    {
        static string ServerUrl = "tcp://localhost:5501/Agency";

        public static AgentRecord Create(string file)
        {
            var agentId = Guid.NewGuid();
            string arglist = "-id " + agentId.ToString() + " -url " + ServerUrl;
            if (Debugger.IsAttached)
                arglist += " --launch-debugger";
            var record = new AgentRecord(agentId, file, arglist);
            return record;
        }
        private ElibLogging logger;
        public AgentRecord(Guid id, string file, string args)
        {
            this.Id = id;
            this.File = file;
            this.Arguments = args;
            logger = new ElibLogging("app");
        }

        public void Launch()
        {
            Process p = new Process();
            p.StartInfo.FileName = File;
            p.StartInfo.Arguments = Arguments;
            p.StartInfo.UseShellExecute = false;
            p.EnableRaisingEvents = true;
            p.Exited += (o, e) =>
            {
                var file = new System.IO.FileInfo(File);
                logger.Warn(file.DirectoryName + ":exited at" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                this.Process = null;
            };
            p.Start();
            this.Process = p;
            try
            {
                RemoteAgency.Instance.WaitRegist(Id.ToString());
            }
            catch (Exception ex)
            {
                //ExceptionManager.HandleException(ex, "Golbal");
                Trace.TraceInformation("ProccessGuard\t" + ex.Message);
            }
        }

        public void Stop()
        {
            if (Process != null && Process.HasExited)
                Process.Kill();
        }

        public bool HasExited
        {
            get
            {
                return Process == null || Process.HasExited;
            }
        }

        public string Arguments { get; private set; }

        public string File { get; private set; }

        public Guid Id { get; private set; }

        System.Diagnostics.Process Process { get; set; }


    }
}
