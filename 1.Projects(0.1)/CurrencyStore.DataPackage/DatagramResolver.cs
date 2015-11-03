using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class DatagramResolver
    {
        public static byte[] HeadTag
        {
            get;
            set;
        }
        static DatagramResolver()
        {
            DatagramResolver.HeadTag = new byte[] { 0xAA, 0xBB };
        }
        public static Datagram ResolveRequest(byte[] rawDatagram)
        {
            Datagram result = null;

            Datagram temp = new DatagramRequest();

            temp.Parse(rawDatagram);

            if (DatagramResolver.HeadTag.SequenceEqual(temp.Head))
            {
                if (temp.CommandCode.SequenceEqual(HeartbeatRequest.FixCommandCode) &&
                    rawDatagram.Length == HeartbeatRequest.Length)
                {
                    result = new HeartbeatRequest();
                }

                if (temp.CommandCode.SequenceEqual(LoginRequest.FixCommandCode) &&
                    rawDatagram.Length == LoginRequest.Length)
                {
                    result = new LoginRequest();
                }

                if (temp.CommandCode.SequenceEqual(BlacklistQueryRequest.FixCommandCode) &&
                   rawDatagram.Length == BlacklistQueryRequest.Length)
                {
                    result = new BlacklistQueryRequest();
                }

                if (temp.CommandCode.SequenceEqual(BlacklistDownloadRequest.FixCommandCode) &&
                   rawDatagram.Length == BlacklistDownloadRequest.Length)
                {
                    result = new BlacklistDownloadRequest();
                }

                if (temp.CommandCode.SequenceEqual(CurrencyRequest.FixCommandCode) &&
                    rawDatagram.Length == CurrencyRequest.Length)
                {
                    result = new CurrencyRequest();
                }

                if (result != null)
                {
                    result.Parse(rawDatagram);
                }
            }

            return result;
        }
        public static Datagram ResolveResponse(byte[] rawDatagram)
        {
            Datagram result = null;

            Datagram temp = new DatagramResponse();

            temp.Parse(rawDatagram);

            if (DatagramResolver.HeadTag.SequenceEqual(temp.Head))
            {
                if (temp.CommandCode.SequenceEqual(HeartbeatResponse.FixCommandCode) &&
                    rawDatagram.Length == HeartbeatResponse.Length)
                {
                    result = new HeartbeatResponse();
                }

                if (temp.CommandCode.SequenceEqual(LoginResponse.FixCommandCode) &&
                    rawDatagram.Length == LoginResponse.Length)
                {
                    result = new LoginResponse();
                }

                if (temp.CommandCode.SequenceEqual(BlacklistQueryResponse.FixCommandCode) &&
                   rawDatagram.Length == BlacklistQueryResponse.Length)
                {
                    result = new BlacklistQueryResponse();
                }

                if (temp.CommandCode.SequenceEqual(BlacklistDownloadResponse.FixCommandCode) &&
                   rawDatagram.Length == BlacklistDownloadResponse.Length)
                {
                    result = new BlacklistDownloadResponse();
                }

                if (temp.CommandCode.SequenceEqual(CurrencyResponse.FixCommandCode) &&
                    rawDatagram.Length == CurrencyResponse.Length)
                {
                    result = new CurrencyResponse();
                }

                if (result != null)
                {
                    result.Parse(rawDatagram);
                }
            }

            return result;
        }
    }
}
