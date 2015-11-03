using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public enum DatagramTypeEnum
    {
        HeartbeatRequest,
        HeartbeatResponse,
        LoginRequest,
        LoginResponse,
        BlacklistQueryRequest,
        BlacklistQueryResponse,
        BlacklistDownloadRequest,
        BlacklistDownloadResponse,
        CurrencyRequest,
        CurrencyResponse
    }
}
