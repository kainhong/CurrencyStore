using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using CurrencyStore.Common;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;

namespace CurrencyStore.Communication
{
    public class Unity
    {
        const int FLAG_LENGTH = 2;
        static ElibLogging logger = new ElibLogging("app");
        public static CurrencyInfo GetCurrency(byte[] datas, int index, byte key)
        {
            CurrencyInfo item = new CurrencyInfo();

            DEntry(datas, index, key);

            item.OperateTime = new DateTime(2000 + datas[index + 0], datas[index + 1],
                                datas[index + 2], datas[index + 3], datas[index + 4], datas[index + 5]);

            item.OperatorNumber = datas[index + 6];
            item.ClientCardNumber = datas.ToHexString(index + 7, 10);
            item.BusinessType = datas[index + 17];
            item.BatchNumber = GetBatchNumber(datas, 18);
            item.OrderNumber = datas.ReadShort(index + 21);
            item.CurrencyKindCode = datas[index + 23];
            item.FaceAmount = datas.ReadShort(index + 24);
            item.CurrencyVersion = datas.ReadShort(index + 26);
            var flag = GetFlag(datas[index + 28]);
            item.CurrencyType = flag[0];
            item.PortNumber = flag[1];
            item.IsSuspicious = datas[index + 29] == 0 ? (byte)0 : (byte)1;
            item.CurrencyNumber = GetCurrencyNo(datas, index + 30);
            item.CurrencyImageType = datas[index + 43];
            item.CurrencyImage = GetPicData(datas, index + 44, item.CurrencyImageType);
            return item;
        }

        public static string GetMechineVersion(byte[] buff, int index)
        {
            var h = new byte[] { buff[index], 0 };
            var m = new byte[] { buff[index + 1], 0 };
            var s = new byte[] { buff[index + 2], 0 };
            var hh = BitConverter.ToInt16(h, 0);
            var mm = BitConverter.ToInt16(m, 0);
            var ss = BitConverter.ToInt16(s, 0);
            return string.Format("20{0:00}{1:00}{2:00}", hh, mm, ss);
        }

        private static string GetBatchNumber(byte[] buff, int index)
        {
            var h = new byte[] { buff[index], 0 };
            var m = new byte[] { buff[index + 1], 0 };
            var s = new byte[] { buff[index + 2], 0 };
            var hh = BitConverter.ToInt16(h, 0);
            var mm = BitConverter.ToInt16(m, 0);
            var ss = BitConverter.ToInt16(s, 0);
            return string.Format("{0:00}{1:00}{2:00}", hh, mm, ss);
        }

        private static void DEntry(byte[] datas, int index, byte key)
        {
            for (int i = 0; i < datas.Length - FLAG_LENGTH; i++)
            {
                datas[i] ^= key;
            }
        }

        static byte[] GetPicData(byte[] buffer, int index, byte type)
        {
            var length = 0;

            if (type == 1)
            {
                length = 360;
            }

            else if (type == 2)
            {
                length = 240;
            }

            else if (type == 3)
            {
                length = 120;
            }

            if (length == 0 || index + length > buffer.Length - 1)
            {
                throw new ArgumentOutOfRangeException("图像数据长度错误");
            }

            var data = new byte[length];

            Buffer.BlockCopy(buffer, index, data, 0, length);

            return data;
        }

        public static string GetCurrencyNo(byte[] buffer, int index)
        {
            const byte dot = 33;

            if (dot == buffer[index])
            {
                return GetInvalideCurrentNo(buffer, index);
            }

            var val = string.Empty;
            var by = new byte[2] { 0, 0 };
            var vals = new char[12];
            var i = 0;
            for (; i < 12; i++)
            {
                by[0] = buffer[index + i];
                if (by[0] == 0)
                    break;
                vals[i] = BitConverter.ToChar(by, 0);
            }

            return new string(vals, 0, i);
        }

        private static string GetInvalideCurrentNo(byte[] buffer, int index)
        {
            var len = 0;

            for (; len < 13; len++)
            {
                if (buffer[len + index] == 0)
                {
                    break;
                }
            }

            return System.Text.Encoding.Default.GetString(buffer, index, len);
        }

        public static byte[] GetFlag(byte val)
        {
            var str = val.ToString("x").PadLeft(2, '0');

            var h = Convert.ToByte(str[0].ToString(), 16);
            var l = Convert.ToByte(str[1].ToString(), 16);

            return new byte[] { h, l };
        }

        public static string GetDeviceNumber(byte[] data, int index)
        {
            var prefix = data.GetString(index, 4).CheckAsciiChar();
            var number = data.ReadInt32(index + 4);

            return prefix + number;
        }

        public static void UpdateDeviceState(DeviceInfo deviceinfo, Device device, bool disconnected)
        {
            if (device.Updated && !disconnected)
            {
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(device.Number))
                {
                    return;
                }

                var service = ServiceFactory.GetService<IDeviceService>();

                if (deviceinfo != null && deviceinfo.PkId == 0)
                {
                    deviceinfo.RegisterIp = device.RemoteIP;

                    service.Save_Info(deviceinfo);
                }

                var item = service.GetObjectByDeviceNumber_Connection(device.Number);

                if (item == null)
                {
                    item = new DeviceConnection();
                }

                item.CollectorName = CurrencyStore.Common.Configration.CurrencyStoreSection.Instance.Name;
                item.ConnectTime = device.ConnectionDate;
                item.DisconnectTime = device.DisconnectionDate;
                item.UploadCount = device.Counter;
                item.DeviceIp = device.RemoteIP;
                item.DeviceNumber = device.Number;
                item.CollectorIp = device.LocalIP;
                item.ConnectionStatus = (byte)(device.Connected ? 1 : 2);

                service.Save_Connection(item);

                device.Updated = true;
            }
            catch (Exception ex)
            {
                logger.Error("更新连接状态错误.", ex);
            }
        }
    }
}
