using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Communication.Activation
{
    abstract class MessageActivation
    {
        public abstract void Process(ServerConnection connection, byte[] datas);
    }
}
