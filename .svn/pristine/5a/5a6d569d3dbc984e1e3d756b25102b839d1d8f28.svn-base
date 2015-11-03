using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CurrencyStore.Utility;
using CurrencyStore.Collector;

namespace CurrencyStore.DuplicateDataClear
{
    public class FileHeader
    {
        /// <summary>
        /// 文件类型
        /// 长度Char(3) SVD
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public byte Version { get; set; }
        /// <summary>
        /// 头大小，固定128
        /// </summary>
        public Int16 Size { get; set; }
        /// <summary>
        /// 设备版本
        /// 长度Char(8)
        /// </summary>
        public string MachineSN { get; set; }
        /// <summary>
        /// boot版本
        /// Char(3)
        /// </summary>
        public string BootVersion { get; set; }
        /// <summary>
        /// 软件版本
        /// Char(3)
        /// </summary>
        public string SoftVersion { get; set; }
        /// <summary>
        /// 记录数
        /// </summary>
        public int SumRecords { get; set; }
        /// <summary>
        /// 已上传记录数
        /// </summary>
        public int UploadRecord { get; set; }
        /// <summary>
        /// 下一个文件地址
        /// </summary>
        public int NextUpLoadFtp { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        public byte[] Bak { get; set; }
    }

    public class CurrencyFileReader : IDisposable
    {
        BinaryReader reader;
        public FileHeader FileHeader { get; private set; }

        public CurrencyFileReader(string file)
        {
            if (!File.Exists(file))
            {
                new FileNotFoundException(file);
            }

            reader = new BinaryReader(new FileStream(file, FileMode.Open));

            this.FileHeader = ReadHeader();
        }

        public IEnumerable<CurrencyStore.Entity.CurrencyInfo> Read(bool onlyUnLoaded)
        {
            const int ROW_HEADER_LENGTH = 4;
            var count = FileHeader.SumRecords;
            var buff = new byte[350];
            var index = 128;

            for (int i = 0; i < count; i++)
            {
                bool uploaded = false;
                var len = reader.Read(buff, 0, 4);
                index += 4;

                if (buff[0] != 0xAA)
                {
                    uploaded = true;
                }

                var contentLen = buff.ReadShort(2);

                len = reader.Read(buff, 4, contentLen - ROW_HEADER_LENGTH);

                if (len != (contentLen - ROW_HEADER_LENGTH))
                {
                    throw new ArgumentException("错误的文件内容在：" + index);
                }

                index += len;
                var item = Message.ConvertFrom(buff);

                if (uploaded && onlyUnLoaded)
                {
                    continue;
                }

                yield return item.Currency;
            }
        }

        private FileHeader ReadHeader()
        {
            var buff = new byte[128];
            var len = reader.Read(buff, 0, 128);
            if (len < buff.Length)
            {
                throw new InvalidDataException("错误的文件格式");
            }
            var header = new FileHeader();
            header.FileType = buff.GetString(0, 3);
            header.Version = buff[3];
            header.Size = BitConverter.ToInt16(buff, 4);
            header.MachineSN = Unity.GetDeviceNumber(buff, 6);
            header.BootVersion = buff.GetByteString(14, 3);
            header.SoftVersion = buff.GetByteString(17, 3);
            header.SumRecords = BitConverter.ToInt32(buff, 20);
            header.UploadRecord = BitConverter.ToInt32(buff, 24);
            header.NextUpLoadFtp = BitConverter.ToInt32(buff, 28);
            return header;
        }

        private void Dispose(bool diposed)
        {
            if (true)
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
