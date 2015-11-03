using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyStore.DataPackage
{
    public class Datagram
    {
        public DatagramTypeEnum Type
        {
            get;
            set;
        }
        public short HeadSize
        {
            get;
            set;
        }
        public byte[] Head
        {
            get;
            set;
        }
        public short DatagramLengthSize
        {
            get;
            set;
        }
        public byte[] DatagramLength
        {
            get;
            set;
        }
        public short CommandCodeSize
        {
            get;
            set;
        }
        public byte[] CommandCode
        {
            get;
            set;
        }
        public short FootSize
        {
            get;
            set;
        }
        public byte[] Foot
        {
            get;
            set;
        }
        public short FullDatagramSize
        {
            get;
            set;
        }
        public byte[] FullDatagram
        {
            get;
            set;
        }
        public Datagram()
        {
            this.HeadSize = 2;
            this.DatagramLengthSize = 2;
            this.CommandCodeSize = 2;
            this.FootSize = 2;

            this.Head = new byte[] { 0xAA, 0xBB };
        }
        public virtual void Parse(byte[] rawDatagram)
        {
            this.FullDatagram = rawDatagram.Read(0, this.FullDatagramSize);

            this.Head = rawDatagram.Read(0, this.HeadSize);
            this.DatagramLength = rawDatagram.Read(2, this.DatagramLengthSize);
        }
        public virtual byte[] BuildFull()
        {
            return null;
        }
        public virtual byte[] BuildFoot()
        {
            return null;
        }
        public override string ToString()
        {
            return this.FullDatagram.ToText();
        }
        public static Datagram GetResponse(Datagram request)
        {
            if (request.CommandCode.SequenceEqual(HeartbeatRequest.FixCommandCode) &&
                request.FullDatagram.Length == HeartbeatRequest.Length)
            {
                return new HeartbeatResponse();
            }

            if (request.CommandCode.SequenceEqual(HeartbeatResponse.FixCommandCode) &&
                request.FullDatagram.Length == HeartbeatResponse.Length)
            {
                return new HeartbeatRequest();
            }

            if (request.CommandCode.SequenceEqual(LoginRequest.FixCommandCode) &&
                request.FullDatagram.Length == LoginRequest.Length)
            {
                return new LoginResponse();
            }

            if (request.CommandCode.SequenceEqual(LoginResponse.FixCommandCode) &&
                request.FullDatagram.Length == LoginResponse.Length)
            {
                return new CurrencyRequest();
            }

            if (request.CommandCode.SequenceEqual(BlacklistQueryRequest.FixCommandCode) &&
                request.FullDatagram.Length == BlacklistQueryRequest.Length)
            {
                return new BlacklistQueryRequest();
            }

            if (request.CommandCode.SequenceEqual(BlacklistQueryResponse.FixCommandCode) &&
                request.FullDatagram.Length == BlacklistQueryResponse.Length)
            {
                return new BlacklistQueryRequest();
            }

            if (request.CommandCode.SequenceEqual(BlacklistDownloadRequest.FixCommandCode) &&
                request.FullDatagram.Length == BlacklistDownloadRequest.Length)
            {
                return new BlacklistDownloadRequest();
            }

            if (request.CommandCode.SequenceEqual(BlacklistDownloadResponse.FixCommandCode) &&
                request.FullDatagram.Length == BlacklistDownloadResponse.Length)
            {
                return new BlacklistDownloadResponse();
            }

            if (request.CommandCode.SequenceEqual(CurrencyRequest.FixCommandCode) &&
                request.FullDatagram.Length == CurrencyRequest.Length)
            {
                return new CurrencyResponse();
            }

            if (request.CommandCode.SequenceEqual(CurrencyResponse.FixCommandCode) &&
                request.FullDatagram.Length == CurrencyResponse.Length)
            {
                return new CurrencyRequest();
            }

            return null;
        }
    }
}
