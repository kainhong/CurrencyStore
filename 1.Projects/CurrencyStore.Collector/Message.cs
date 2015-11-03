using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CurrencyStore.Business;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;

namespace CurrencyStore.Collector
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
            DeviceInfo device = DeviceCache.Current.Get(key);

            if (device == null)
            {
                device = new DeviceInfo();
                device.OrgId = 0;
                device.ModelCode = 0;
                device.KindCode = 0;
                device.DeviceNumber = key;
                device.OnLineTime = DateTime.Now;
                device.DeviceStatus = 1;
                device.SoftwareVersion = "00000000";// Unity.GetMechineVersion(buffer, 15);
            }

            var messageType = buffer[13];// (short)(BitConverter.ToInt16(buffer, 12) >> 8);

            var msg = new Message()
            {
                Length = length,
                Type = messageType,
                Device = device
            };

            if (messageType == (short)MessageType.Beep)
            {
                return msg;
            }

            msg.Key = buffer[14];

            if (messageType == (short)MessageType.Login)
            {
                if (device.PkId == 0)
                {
                    device.SoftwareVersion = Unity.GetMechineVersion(buffer, 15);
                    DeviceCache.Current.Set(device);
                }
            }

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

        private short WriteCommand(BinaryWriter sw)
        {
            sw.Write((byte)0xA0);
            sw.Write(Type);
            return (short)((byte)0xA0 + Type);
        }

        public byte[] GetBytes(byte flag)
        {
            byte[] buff = null;
            BinaryWriter sw = null;// new BinaryWriter(stream);
            //Int16 val = 0xAA + 0xBB;
            if (Type == (int)MessageType.Beep)
            {
                buff = new byte[8];
                sw = GetWriter(buff);
                sw.WriteShort((short)buff.Length);
                WriteCommand(sw);
            }

            else if (Type == (int)MessageType.Login)
            {
                buff = new byte[16];
                sw = GetWriter(buff);
                sw.WriteShort((short)buff.Length);
                WriteCommand(sw);
                sw.Write(Key);
                var tmp = DateTime.Now.GetBytes();
                sw.Write(tmp);
                sw.Write(flag);//注册标志;                
            }

            else if (Type == (int)MessageType.Detail)
            {
                buff = new byte[9];
                sw = GetWriter(buff);
                sw.WriteShort((short)buff.Length);
                WriteCommand(sw);

                if (Datas != null)
                {
                    sw.Write(flag);
                }
            }

            else if (Type == (int)MessageType.BlackTable)
            {
                buff = new byte[13];
                sw = GetWriter(buff);
                sw.WriteShort((short)buff.Length);
                WriteCommand(sw);
                var table = BlackTableHelper.GetBlackTable();
                var version = BlackTableHelper.GetBlackTableVersion(table);
                sw.Write(version);
                var len = (short)BlackTableHelper.GetBlackTable().CurrenciesNumber.Count;
                sw.WriteShort(len);
            }

            else if (Type == (int)MessageType.DownLoadBlackTable)
            {
                buff = new byte[26];
                sw = GetWriter(buff);
                sw.WriteShort((short)buff.Length);
                WriteCommand(sw);
                var index = Datas.ReadShort(0);
                var lst = BlackTableHelper.GetBlackTable().CurrenciesNumber;
                if (index > lst.Count)
                {
                    sw.Write(BlackTable.Blank);
                }

                else
                {
                    var item = lst[index - 1];
                    sw.Write(item);
                }
            }

            if (sw != null)
            {
                var count = Sum(buff);
                sw.WriteShort(count);
                sw.Close();
            }

            return buff;
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

            //var length = buffer.ReadShort(2);
            //if (length != buffer.Length)
            //    return false;

            //var flag  = buffer.ReadShort(buffer.Length-2);//  (buffer, buffer.Length - 2);
            //var val = 0;
            //for (int i = 0; i < buffer.Length - 2; i++) {
            //    val += buffer[i];
            //}
            //return (flag == val);

            return true;
        }

        private static void Log(byte[] buff)
        {
            var val = BitConverter.ToString(buff);
            logger.Warn(string.Format("invalided data:{0}", val));
        }
    }
}
