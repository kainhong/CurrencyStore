using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using CurrencyStore.Repository;

namespace CurrencyStore.Web.App_Class
{
    public class ResponseFilter : Stream
    {
        private Stream StreamFilter;

        public ResponseFilter(Stream stream)
        {
            this.StreamFilter = stream;
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Flush()
        {
            StreamFilter.Flush();
        }

        public override long Length
        {
            get
            {
                return StreamFilter.Length;
            }
        }

        public override long Position
        {
            get
            {
                return StreamFilter.Position;
            }
            set
            {
                StreamFilter.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.StreamFilter.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.StreamFilter.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            this.StreamFilter.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            string Html = Encoding.UTF8.GetString(buffer);
            buffer = Encoding.UTF8.GetBytes(Html.Replace("</body>", "<div style=\"margin: 10px auto; font-weight: bold; color: Red; text-align: center; font-size: 12px\">注意: 以下为数据查询分析工具，正式站点使用请使用Release编译。</div>" + DbQueryDetailHelper.QueryDetail + "</body>"));
            StreamFilter.Write(buffer, offset, buffer.Length);
        }
    }
}