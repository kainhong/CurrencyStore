using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;

namespace CurrencyStore.Business
{
    public class SystemParameter
    {
        private static List<BasicParameter> basicParameterList = null;

        static SystemParameter()
        {

            ///TODO:
            //SystemParameter.Init();
            //SystemParameter.Refresh();
        }

        #region 参数项
        /// <summary>
        /// 黑名单版本号
        /// </summary>
        public static string BlacklistVersion
        {
            get { return basicParameterList.Find(obj => obj.ParamKey.Equals("BlacklistVersion")).ParamValue; }
            set { basicParameterList.Find(obj => obj.ParamKey.Equals("BlacklistVersion")).ParamValue = value; }
        }
        /// <summary>
        /// 数据保存天数
        /// </summary>
        public static uint DataStorageDays
        {
            get { return basicParameterList.Find(obj => obj.ParamKey.Equals("DataStorageDays")).ParamValue.ToUInt(30); }
            set { basicParameterList.Find(obj => obj.ParamKey.Equals("DataStorageDays")).ParamValue = value.ToString(); }
        }
        /// <summary>
        /// 数据清理时间
        /// </summary>
        public static string DataClearTime
        {
            get { return basicParameterList.Find(obj => obj.ParamKey.Equals("DataClearTime")).ParamValue; }
            set { basicParameterList.Find(obj => obj.ParamKey.Equals("DataClearTime")).ParamValue = value; }
        }
        /// <summary>
        /// 文件保存数量
        /// </summary>
        public static uint FileStorageCount
        {
            get { return basicParameterList.Find(obj => obj.ParamKey.Equals("FileStorageCount")).ParamValue.ToUInt(20); }
            set { basicParameterList.Find(obj => obj.ParamKey.Equals("FileStorageCount")).ParamValue = value.ToString(); }
        }
        /// <summary>
        /// 纸币信息字段
        /// </summary>
        public static string CurrencyInfoColumn
        {
            get { return basicParameterList.Find(obj => obj.ParamKey.Equals("CurrencyInfoColumn")).ParamValue; }
            set { basicParameterList.Find(obj => obj.ParamKey.Equals("CurrencyInfoColumn")).ParamValue = value; }
        }
        /// <summary>
        /// 采集系统名称
        /// </summary>
        public static string CollectSystemName
        {
            get { return basicParameterList.Find(obj => obj.ParamKey.Equals("CollectSystemName")).ParamValue; }
            set { basicParameterList.Find(obj => obj.ParamKey.Equals("CollectSystemName")).ParamValue = value; }
        }
        /// <summary>
        /// 系统标志图片
        /// </summary>
        public static string SystemLogoPicture
        {
            get { return basicParameterList.Find(obj => obj.ParamKey.Equals("SystemLogoPicture")).ParamValue; }
            set { basicParameterList.Find(obj => obj.ParamKey.Equals("SystemLogoPicture")).ParamValue = value; }
        }
        #endregion

        private static void Init()
        {
            IBasicService service = ServiceFactory.GetService<IBasicService>();

            basicParameterList = new List<BasicParameter>();

            if (!service.CheckExists_Parameter(new BasicParameter() { ParamKey = "BlacklistVersion" }))
            {
                basicParameterList.Add(new BasicParameter() { ParamKey = "BlacklistVersion", ParamName = "黑名单版本号", ParamValue = "20130101" });
            }

            if (!service.CheckExists_Parameter(new BasicParameter() { ParamKey = "DataStorageDays" }))
            {
                basicParameterList.Add(new BasicParameter() { ParamKey = "DataStorageDays", ParamName = "数据保存天数", ParamValue = "30" });
            }

            if (!service.CheckExists_Parameter(new BasicParameter() { ParamKey = "DataClearTime" }))
            {
                basicParameterList.Add(new BasicParameter() { ParamKey = "DataClearTime", ParamName = "数据清理时间", ParamValue = "00:00:00" });
            }

            if (!service.CheckExists_Parameter(new BasicParameter() { ParamKey = "FileStorageCount" }))
            {
                basicParameterList.Add(new BasicParameter() { ParamKey = "FileStorageCount", ParamName = "文件保存数量", ParamValue = "20" });
            }

            if (!service.CheckExists_Parameter(new BasicParameter() { ParamKey = "CurrencyInfoColumn" }))
            {
                basicParameterList.Add(new BasicParameter() { ParamKey = "CurrencyInfoColumn", ParamName = "纸币信息字段", ParamValue = "[1][2][3][4][5][6][7][8][9][10][11][12][13][14][15][16][17][18]" });
            }

            if (!service.CheckExists_Parameter(new BasicParameter() { ParamKey = "CollectSystemName" }))
            {
                basicParameterList.Add(new BasicParameter() { ParamKey = "CollectSystemName", ParamName = "采集系统名称", ParamValue = "纸币流通管理系统" });
            }

            if (!service.CheckExists_Parameter(new BasicParameter() { ParamKey = "SystemLogoPicture" }))
            {
                basicParameterList.Add(new BasicParameter() { ParamKey = "SystemLogoPicture", ParamName = "系统标志图片", ParamValue = "" });
            }

            if (basicParameterList.Count > 0)
            {
                SystemParameter.Save();
            }
        }
        public static void Save()
        {
            IBasicService service = ServiceFactory.GetService<IBasicService>();

            foreach (BasicParameter item in basicParameterList)
            {
                service.Save_Parameter(item);
            }

            SystemParameter.Refresh();
        }
        public static void Refresh()
        {
            IBasicService service = ServiceFactory.GetService<IBasicService>();

            basicParameterList = service.GetList_Parameter();
        }
        public static void UpdateBlacklistVersion()
        {
            string oldVersion = SystemParameter.BlacklistVersion;

            string temp = oldVersion.Substring(0, 4) + "." + oldVersion.Substring(4, 2) + "." + oldVersion.Substring(6, 2);

            SystemParameter.BlacklistVersion = temp.ToDateTime().AddDays(1).ToString("yyyyMMdd");

            SystemParameter.Save();
        }
    }
}
