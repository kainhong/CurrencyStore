using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace CurrencyStore.Common
{
    public static class ElibExceptionHandler
    {
        static ExceptionManager exceptionManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        const string policyName = "Global";
        public static bool Handle(System.Exception exception)
        {
            return exceptionManager.HandleException(exception, policyName);
        }
    }
}
