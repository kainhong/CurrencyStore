using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace CurrencyStore.Utility
{
    public static class ServiceFactory
    {
        static UnityContainer contianer;

        public static IUnityContainer Contianer { get { return contianer; } }

        static ServiceFactory()
        {
            contianer = new UnityContainer();
            var name = "oracle";
            contianer.LoadConfiguration(name);
        }

        public static T GetService<T>()
        {
            return contianer.Resolve<T>();
        }
    }
}
