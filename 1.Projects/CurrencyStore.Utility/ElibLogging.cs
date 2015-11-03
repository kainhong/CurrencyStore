using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using elib = Microsoft.Practices.EnterpriseLibrary.Logging;

namespace CurrencyStore.Utility
{
    public class ElibLogging
    {
        static HashSet<string> _category = new HashSet<string>();
        static string _defaultCategory;
        static ElibLogging()
        {
            var mg = Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ConfigurationSourceFactory.Create();//
            var section = (elib.Configuration.LoggingSettings)mg.GetSection(Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings.SectionName);
            _defaultCategory = section.DefaultCategory;
            var q = section.TraceSources.AsQueryable<elib.Configuration.TraceSourceData>();
            foreach (var item in q)
            {
                _category.Add(item.Name);
            }
        }
        public string Category { get; private set; }
        public ElibLogging(string category)
        {
            this.Category = category;
            if (!_category.Contains(Category))
                Category = _defaultCategory;
        }
        public static readonly ElibLogging Current = new ElibLogging("trace");

        /// <summary>
        /// 向指定的日志种类（日志种类指的是配置文件如：App.config里面配置的具体Logger种类）
        /// 写入一个新的带有调试信息的LogEntry.
        /// </summary>
        /// <param name="message">调试信息</param>
        public void Debug(string message)
        {
            elib.Logger.Write(new elib.LogEntry()
            {
                Message = message,
                Categories = new string[] { Category },
                Severity = System.Diagnostics.TraceEventType.Verbose
            });
        }
        /// <summary>
        /// 向指定的日志种类（日志种类指的是配置文件如：App.config里面配置的具体Logger种类）
        /// 写入一个新的带有一般信息的LogEntry.
        /// </summary>
        /// <param name="message">一般信息</param>
        public void Info(string message)
        {
            elib.Logger.Write(new elib.LogEntry()
            {
                Message = message,
                Categories = new string[] { Category },
                Severity = System.Diagnostics.TraceEventType.Information
            });
        }
        /// <summary>
        /// 向指定的日志种类（日志种类指的是配置文件如：App.config里面配置的具体Logger种类）
        /// 写入一个新的带有错误信息的LogEntry.
        /// </summary>
        /// <param name="message">错误信息</param>
        public void Error(string message)
        {
            elib.Logger.Write(new elib.LogEntry()
            {
                Message = message,
                Categories = new string[] { Category },
                Severity = System.Diagnostics.TraceEventType.Error
            });
        }
        /// <summary>
        /// 向指定的日志种类（日志种类指的是配置文件如：App.config里面配置的具体Logger种类）
        /// 写入一个新的带有错误异常信息的LogEntry.
        /// </summary>
        /// <param name="message">错误异常信息</param>
        /// <param name="ex">错误异常对象</param>
        public void Error(string message, System.Exception ex)
        {
            elib.LogEntry le = new elib.LogEntry();
            le.Message = message;
            le.Priority = 2;
            le.Categories = new string[] { Category };
            le.Severity = System.Diagnostics.TraceEventType.Error;
            le.ExtendedProperties.Add("Exception", ex.Message);
            le.ExtendedProperties.Add("ExceptionType", ex.GetType().Name);
            le.ExtendedProperties.Add("CallStack", ex.StackTrace);
            elib.Logger.Write(le);
        }
        /// <summary>
        /// 向指定的日志种类（日志种类指的是配置文件如：App.config里面配置的具体Logger种类）
        /// 写入一个新的带有警告信息的LogEntry.
        /// </summary>
        /// <param name="message">警告信息</param>
        public void Warn(string message)
        {
            elib.Logger.Write(new elib.LogEntry()
            {
                Message = message,
                Categories = new string[] { Category },
                Severity = System.Diagnostics.TraceEventType.Warning
            });
        }
        /// <summary>
        /// 向指定的日志种类（日志种类指的是配置文件如：App.config里面配置的具体Logger种类）
        /// 写入一个新的带有致命错误信息的LogEntry.
        /// </summary>
        /// <param name="message">致命错误信息</param>
        public void Fatal(string message)
        {
            elib.Logger.Write(new elib.LogEntry()
            {
                Message = message,
                Categories = new string[] { Category },
                Severity = System.Diagnostics.TraceEventType.Critical
            });
        }
    }
}
