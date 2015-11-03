using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CurrencyStore.Utility;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Collector;

namespace CurrencyStore.DuplicateDataClear
{
    public class Message
    {
        static readonly byte[] _header = new byte[] { 0xAA, 0xBB, 0xCC };
        const int MACHINE_NUMBER_LENGTH = 0x08;
        const int COMMAND_NUMBER_LENGTH = 0x02;
        const int PAKAGE_FLAG_LENGTH = 0x10;

        public string Header { get; private set; }

        public Int16 Length { get; private set; }

        public DeviceInfo Device { get; private set; }

        public byte Type { get; private set; }

        public byte[] Datas { get; set; }

        public CurrencyInfo Currency { get; set; }

        public Byte Key { get; set; }

        static ElibLogging logger;

        static Message()
        {
            logger = new ElibLogging("trace");
        }

        static IDeviceService service = ServiceFactory.GetService<IDeviceService>();

        public static Message ConvertFrom(byte[] buffer)
        {
            if (!Validate(buffer))
            {
                Log(buffer);
                return null;
            }

            var length = buffer.ReadShort(2);
            string key = Unity.GetDeviceNumber(buffer, 4);
            DeviceInfo device = new DeviceInfo();

            device.OrgId = 0;
            device.ModelCode = 0;
            device.KindCode = 0;
            device.DeviceNumber = key;
            device.OnLineTime = DateTime.Now;
            device.DeviceStatus = 1;
            device.SoftwareVersion = "00000000";// Unity.GetMechineVersion(buffer, 15);
            
            var messageType = buffer[13];// (short)(BitConverter.ToInt16(buffer, 12) >> 8);

            var msg = new Message()
            {
                Length = length,
                Type = messageType,
                Device = device
            };
            
            msg.Key = buffer[14];
            
            int KEY_LENGTH = 1;
            var dataLength = length - PAKAGE_FLAG_LENGTH;

            if (dataLength > 0)
            {
                dataLength -= KEY_LENGTH;

                if (messageType == (short)MessageType.Detail || messageType == 160)
                {
                    msg.Currency = Unity.GetCurrency(buffer, 15, msg.Key);

                    if (msg.Device != null)
                    {
                        msg.Currency.OrgId = msg.Device.OrgId;
                        msg.Currency.DeviceKindCode = msg.Device.KindCode;
                        msg.Currency.DeviceModelCode = msg.Device.ModelCode;
                        msg.Currency.DeviceNumber = msg.Device.DeviceNumber;
                    }
                }

                else
                {
                    var index = 15;
                    if (messageType == (short)MessageType.DownLoadBlackTable)
                    {
                        dataLength += KEY_LENGTH;
                        index -= KEY_LENGTH;
                    }
                    var data = new byte[dataLength];
                    Array.Copy(buffer, index, data, 0, dataLength);
                    msg.Datas = data;
                }
            }

            return msg;
        }

        private BinaryWriter GetWriter(byte[] buff)
        {
            var mem = new MemoryStream(buff);
            var sw = new BinaryWriter(mem);
            sw.Write(_header, 0, 2);
            return sw;
        }

        private Int16 Sum(byte[] datas)
        {
            var val = 0;

            foreach (var b in datas)
            {
                val += b;
            }

            return (Int16)val;
        }

        private static bool Validate(byte[] buffer)
        {
            if (buffer.Length < 4)
            {
                return false;
            }

            if (!(buffer[0] == _header[0] || buffer[0] == _header[2]) && buffer[1] != _header[1])
            {
                return false;
            }

            return true;
        }

        private static void Log(byte[] buff)
        {
            var val = BitConverter.ToString(buff);
            logger.Warn(string.Format("invalided data:{0}", val));
        }
    }
}
