using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.Communication
{
    enum CommandType
    {
        Beep = 1,
        Login = 3,
        BlackTable = 5,
        DownLoadBlackTable = 6,
        Detail = 10
    }
}
