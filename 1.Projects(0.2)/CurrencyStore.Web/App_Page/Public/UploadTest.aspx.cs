using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Web.App_Page.Public
{
    public partial class UploadTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //byte[] buffer = new Buffer[512];

            using (FileStream fs = File.Open(@"Z:\20121204.SVD", FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    FileHead fh = new FileHead();

                    fh.Name = br.ReadSByte().ToChar().ToString() + br.ReadSByte().ToChar().ToString() + br.ReadSByte().ToChar().ToString();
                    fh.Ver = br.ReadSByte().ToString();
                    fh.Size = br.ReadInt16().ToString();

                    byte[] temp = new byte[8];
                    br.Read(temp, 0, 8);

                    //fh.MachineSN = br.ReadSByte().ToString() + br.ReadSByte().ToString() + br.ReadSByte().ToString() + br.ReadSByte().ToString() + br.ReadSByte().ToString() + br.ReadSByte().ToString() + br.ReadSByte().ToString() + br.ReadSByte().ToString();
                    fh.MachineSN = temp.ToHexString();
                    fh.BootVer = br.ReadSByte().ToString() + br.ReadSByte().ToString() + br.ReadSByte().ToString();
                    fh.SoftVer = br.ReadSByte().ToString() + br.ReadSByte().ToString() + br.ReadSByte().ToString();
                    fh.SumRecord = br.ReadInt32().ToString();
                    fh.UploadRecord = br.ReadInt32().ToString();
                    fh.NextUploadFPtr = br.ReadInt32().ToString();

                    Response.Write(fh.ToString());
                }
            }
        }

        public class FileHead
        {
            public string Name { get; set; }
            public string Ver { get; set; }
            public string Size { get; set; }
            public string MachineSN { get; set; }
            public string BootVer { get; set; }
            public string SoftVer { get; set; }
            public string SumRecord { get; set; }
            public string UploadRecord { get; set; }
            public string NextUploadFPtr { get; set; }
            public string Bak { get; set; }

            public override string ToString()
            {
                return "Name:{0}|Ver:{1}|Size:{2}|MachineSN:{3}|BootVer:{4}|SoftVer:{5}|SumRecord:{6}|UploadRecord:{7}|NextUploadFPth:{8}".
                    FormatWith(this.Name, this.Ver, this.Size, this.MachineSN, this.BootVer, this.SoftVer, this.SumRecord, this.UploadRecord, this.NextUploadFPtr);
            }
        }
    }
}