using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Common.File
{
    public class FileHelper
    {
        public static string ConvertPath(string relativePath)
        {
            if (!relativePath.Contains(@":\"))
            {
                return HttpContext.Current.Server.MapPath(relativePath);
            }

            else
            {
                return relativePath;
            }
        }
        public static bool CheckFileExists(string filePath)
        {
            return System.IO.File.Exists(FileHelper.ConvertPath(filePath));
        }
        public static bool CheckDirectoryExists(string directoryPath)
        {
            return Directory.Exists(FileHelper.ConvertPath(directoryPath));
        }
        public static void CreateDirectory(string directoryPath, bool isDeleteExists)
        {
            string currentDirectoryPath = FileHelper.ConvertPath(directoryPath);

            if (FileHelper.CheckDirectoryExists(directoryPath))
            {
                if (isDeleteExists)
                {
                    Directory.Delete(currentDirectoryPath);
                }

                else
                {
                    return;
                }
            }

            Directory.CreateDirectory(currentDirectoryPath);
        }
        public static void DeleteFile(string filePath)
        {
            string path = FileHelper.ConvertPath(filePath);

            if (CheckFileExists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        public static void DeleteDirectory(string directoryPath)
        {
            Directory.Delete(FileHelper.ConvertPath(directoryPath));
        }
        public static string GetFileNamebyGuid(string extensionName)
        {
            return Guid.NewGuid().ToString() + extensionName;
        }
        public static string GetFileNameByDateTime(string extensionName, bool isLong)
        {
            return (isLong ? DateTime.Now.ToString("yyyyMMddHHmmssffff") : DateTime.Now.ToString("yyyyMMdd")) + extensionName;
        }
        public static string GetFileExtensionName(string fileName)
        {
            string result = String.Empty;

            if (fileName.IsNotNullOrEmpty())
            {
                result = new FileInfo(fileName).Extension;
            }

            return result;
        }
        public static string GetFileSize(string filePath)
        {
            FileInfo objFileInfo = new FileInfo(FileHelper.ConvertPath(filePath));

            return FileHelper.GetFileSize(objFileInfo.Length);
        }
        public static string GetFileSize(long bytes)
        {
            string result = "0 Bytes";

            if (bytes >= (1024 * 1024 * 1024))
            {
                result = String.Format("{0:##.##} GB", Decimal.Divide(bytes, (1024 * 1024 * 1024)));
            }

            else if (bytes >= (1024 * 1024))
            {
                result = String.Format("{0:##.##} MB", Decimal.Divide(bytes, (1024 * 1024)));
            }

            else if (bytes >= 1024)
            {
                result = String.Format("{0:##.##} KB", Decimal.Divide(bytes, 1024));
            }

            else if (bytes > 0 & bytes < 1024)
            {
                result = String.Format("{0:##.##} Bytes", bytes);
            }

            return result;
        }
        public static DataTable GetFileList(string folderPath)
        {
            DataTable result = new DataTable();

            result.Columns.Add(new DataColumn("FileName", typeof(string)));
            result.Columns.Add(new DataColumn("FileSize", typeof(string)));
            result.Columns.Add(new DataColumn("CreateTime", typeof(string)));
            result.Columns.Add(new DataColumn("LastAccessTime", typeof(string)));

            {
                FileInfo[] files = new DirectoryInfo(FileHelper.ConvertPath(folderPath)).GetFiles();

                if (files.Length > 0)
                {
                    DataRow objDR = null;

                    foreach (FileInfo objFI in files)
                    {
                        objDR = result.NewRow();

                        objDR["FileName"] = objFI.Name;
                        objDR["FileSize"] = FileHelper.GetFileSize(objFI.Length);
                        objDR["CreateTime"] = objFI.CreationTime.ToString();
                        objDR["LastAccessTime"] = objFI.LastAccessTime.ToString();

                        result.Rows.Add(objDR);
                    }
                }
            }

            return result;
        }
        public static string[] GetDirectoryList(string folderPath)
        {
            return null;
        }
        public static string ReadFile(string filePath)
        {
            string result = null;

            lock (new object())
            {
                using (FileStream objFS = new FileStream(FileHelper.ConvertPath(filePath), FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (StreamReader objSR = new StreamReader(objFS))
                    {
                        result = objSR.ReadToEnd();

                        objSR.Close();
                        objFS.Close();
                    }
                }
            }

            return result;
        }
        public static void WriteFile(string filePath, string fileContent)
        {
            lock (new object())
            {
                using (FileStream objFS = new FileStream(FileHelper.ConvertPath(filePath), FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter objSW = new StreamWriter(objFS))
                    {
                        objSW.Write(fileContent);
                        objSW.Flush();

                        objSW.Close();
                        objFS.Close();
                    }
                }
            }
        }
        public static void DownloadFile(string realFilePath, string rename, string contentType, bool isFinishDelete)
        {
            string path = FileHelper.ConvertPath(realFilePath);

            if (FileHelper.CheckFileExists(path))
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.Charset = "UTF-8";
                HttpContext.Current.Response.ContentType = contentType.IsNullOrEmpty() ? "application/octet-stream" : contentType;
                HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
                HttpContext.Current.Response.AddHeader("Connection", "Keep-Alive");
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(rename, System.Text.Encoding.UTF8));
                HttpContext.Current.Response.AddHeader("Content-Transfer-Encoding", "binary");

                using (FileStream objFS = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    int size = 1024;
                    int length = 0;

                    for (int i = 0; i < objFS.Length / size + 1; i++)
                    {
                        byte[] buffer = new byte[size];

                        length = objFS.Read(buffer, 0, size);

                        if (length > 0)
                        {
                            HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                            HttpContext.Current.Response.Flush();
                        }
                    }

                    objFS.Close();
                }

                if (isFinishDelete)
                {
                    FileHelper.DeleteFile(realFilePath);
                }
            }
        }
        public static void DownloadFileWithPage(string realFilePath, string rename)
        {
            HttpContext.Current.Response.Redirect(GetDownloadFileUrl(realFilePath, rename));
        }
        public static string GetDownloadFileUrl(string realFilePath, string rename)
        {
            return "~/App_Page/Public/FileDownload.aspx?RealFilePath={0}&Rename={1}".FormatWith(realFilePath.UrlEncode(), rename.UrlEncode());
        }
    }
}
