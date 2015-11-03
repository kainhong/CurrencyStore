using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace CurrencyStore.Common
{
    public static class ServiceFactory
    {
        static UnityContainer contianer;
        static string providerName;

        static ServiceFactory()
        {
            contianer = new UnityContainer();
            var name = ConfigurationManager.AppSettings["UnityContainerName"];
            contianer.LoadConfiguration(name);
            //contianer.LoadConfiguration(_section, CONTAINER_NAME);
            //"CurrencyStore.Services.dll"
            //providerName = System.Configuration.ConfigurationManager.ConnectionStrings[0].ProviderName.Split('.')[0];
            //string path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            //LoadAssemlby(Path.Combine(path, "CurrencyStore.Repository.dll"));
            //LoadAssemlby(Path.Combine(path, "CurrencyStore.Services.dll"));
        }

        private static void LoadAssemlby(string assemblyFile)
        {
            var asm = Assembly.LoadFile(assemblyFile);
            var types = asm.GetExportedTypes().Where(t => t.IsClass);
            foreach (var type in types)
            {
                var name = type.FullName;
                if (name.IndexOf("Repository") > 0 && name.IndexOf(providerName) < 0)
                    continue;
                var interfaces = type.GetInterfaces();
                if (interfaces.Length == 0)
                    continue;
                foreach (var item in interfaces)
                {
                    contianer.RegisterType(item, type);
                }
            }
        }

        public static IUnityContainer Contianer { get { return contianer; } }

        public static T GetService<T>()
        {
            return contianer.Resolve<T>();
        }
    }
}
