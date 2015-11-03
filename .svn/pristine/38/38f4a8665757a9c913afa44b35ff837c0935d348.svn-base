using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace CurrencyStore.Repository
{
    public class DbQueryDetailHelper
    {
        public static string QueryDetail { get; set; }
        public static string GetQueryDetail(string commandText, DateTime dtStart, DateTime dtEnd, DbParameterCollection cmdParams)
        {
            string tr = "<tr>";
            string colums = "";
            string dbtypes = "";
            string values = "";
            string paramdetails = "";
            if (cmdParams != null && cmdParams.Count > 0)
            {
                foreach (DbParameter param in cmdParams)
                {
                    if (param == null)
                    {
                        continue;
                    }

                    colums += "<td style=\"text-align:center\">" + param.ParameterName + "</td>";
                    dbtypes += "<td style=\"text-align:center\">" + param.DbType.ToString() + "</td>";
                    values += "<td style=\"text-align:center\">" + param.Value.ToString() + "</td>";
                }
                paramdetails = string.Format("<table cellspacing=\"5px\" cellpadding=\"5px\" style=\"font-size: 12px;\">{0}{1}</tr>{0}{2}</tr>{0}{3}</tr></table>", tr, colums, dbtypes, values);
            }
            string outputstring = string.Format("<div style=\"border: 1px solid black; padding: 5px; width: 98%; clear: both; margin: 5px auto; text-align: left\"><div style=\"font-size: 12px; padding: 5px;\"><b>耗时:</b> {0}</div><div style=\"font-size: 12px; line-height: 18px; padding: 5px;\">{1}</div>{2}</div><br/>", dtEnd.Subtract(dtStart).ToString(), commandText, paramdetails);
            
            /*
            //写入文件操作
            string debugsql = "";
            debugsql += "\r\nTIME:" + dtEnd.Subtract(dtStart).ToString();
            debugsql += "\r\nSQL:" + commandText;
            if (cmdParams != null && cmdParams.Count > 0)
            {
                foreach (DbParameter param in cmdParams)
                {
                    if (param == null)
                    {
                        continue;
                    }

                    debugsql += "\r\nParameterName:" + param.ParameterName;
                    debugsql += "     DbType:" + param.DbType.ToString();
                    debugsql += "     Value:" + param.Value.ToString();
                }
            }

            //WriteDdbguSQLFile(debugsql);
            */

            return outputstring;
        }
        private static void WriteDdbguSQLFile(string debugsql)
        {
            string logText = "\r\n-----------------------------------------------------------------------------------------";
            logText += "\r\n发生时间：" + DateTime.Now.ToString();
            logText += debugsql;
            logText += "\r\n-----------------------------------------------------------------------------------------\r\n";
            //日志物理路径
            string mapPath = AppDomain.CurrentDomain.BaseDirectory + "/DdbugSQLLog/";


            StreamWriter writer = null;
            try
            {
                //写入日志 
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string path = string.Empty;

                //得到文件夹完全路径
                string pathMonth = mapPath;

                //判断文件是否存在
                if (!Directory.Exists(pathMonth))//判断文件夹是否存在
                {
                    //创建月份文件夹
                    Directory.CreateDirectory(pathMonth);
                }

                //得到日志文件的名称
                string filename = DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                //得到日志文件的完整路径
                path = pathMonth + "/" + filename;

                FileInfo file = new FileInfo(path);
                writer = new StreamWriter(file.FullName, true);//文件不在则创建，true表示追加
                writer.WriteLine(logText);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
