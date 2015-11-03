Use master
go

if exists (select name from sysdatabases  where name='MoneyDB1')
drop database MoneyDB1
GO

----创建数据库 start------------------------------------------
Create DataBase MoneyDB1
ON PRIMARY
(NAME='DB Primary Main',
FILENAME='D:\MoneyDataBase\Main\MoneyDB.mdf',
SIZE=5,
MAXSIZE=500,
FILEGROWTH=1),  ---主文件存放地址

FILEGROUP [MoneyDB Partition One]
(NAME = 'MoneyDB Partition One',
FILENAME ='D:\MoneyDataBase\One\One.ndf',
SIZE = 5MB,
MAXSIZE=500,
FILEGROWTH=1),  ---第一分区存放地址

FILEGROUP [MoneyDB Partition Two]
(NAME = 'MoneyDB Partition Two',
FILENAME ='D:\MoneyDataBase\Two\Two.ndf',
SIZE = 5MB,
MAXSIZE=500,
FILEGROWTH=1),  ---第二分区存放地址

FILEGROUP [MoneyDB Partition Three]
(NAME = 'MoneyDB Partition Three',
FILENAME ='D:\MoneyDataBase\Three\Three.ndf',
SIZE = 5MB,
MAXSIZE=500,
FILEGROWTH=1),  ---第三分区存放地址

FILEGROUP [MoneyDB Partition Four]
(NAME = 'MoneyDB Partition Four',
FILENAME ='D:\MoneyDataBase\Four\Four.ndf',
SIZE = 5MB,
MAXSIZE=500,
FILEGROWTH=1 )  ---第四分区存放地址

go

---------------创建数据库 end---------------------------------

-------------创建表分区函数 start-------------------------------

Use MoneyDB1
go

CREATE PARTITION FUNCTION [MoneyListFdate](int)
AS RANGE LEFT FOR VALUES (1,2,3)


-------------创建表分区函数 end -------------------------------


------------创建表架构 start------------------------------------

Use MoneyDB1
go

CREATE PARTITION SCHEME [MoneyListScheme]
AS PARTITION [MoneyListFdate]
TO ([MoneyDB Partition One], [MoneyDB Partition Two], [MoneyDB Partition Three],[MoneyDB Partition Four]);


------------创建表架构 end------------------------------------


------------创建表 start----------------------------------------


Use MoneyDB1
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MoneyList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MoneyList](
	[moneyid] [uniqueidentifier] NOT NULL,
	[fdate] [varchar](10) NULL,
	[ftime] [varchar](10) NULL,
	[flowno] [int] NULL,
	[bachno] [varchar](50) NULL,
	[serialno] [varchar](30) NULL,
	[price] [varchar](10) NULL,
	[kindno] [varchar](5) NULL,
	[fakes] [bit] NULL,
	[photo] [image] NULL,
	[fullphoto] [image] NULL,
	[photoname] [varchar](300) NULL,
	[devid] [varchar](20) NULL,
	[devname] [varchar](30) NULL,
	[recognitioninfo] [varchar](50) NULL,
	[mrecognitioninfo] [varchar](100) NULL,
	[bzbh] [varchar](5) NULL,
	[photowidth] [int] NULL,
	[photoheight] [int] NULL,
	[facedirect] [varchar](50) NULL,
	[refusereason] [varchar](100) NULL,
	[outport] [varchar](50) NULL,
	[JobNum] [varchar](20) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeviceModelList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeviceModelList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[cck] [int] NULL,
	[tck] [int] NULL,
	[type] [varchar](20) NULL,
 CONSTRAINT [PK_DeviceModelList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RefuseReason]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RefuseReason](
	[errno] [int] NOT NULL,
	[errmsg] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RefuseReason] PRIMARY KEY CLUSTERED 
(
	[errno] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KeyList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[KeyList](
	[groupname] [varchar](50) NULL,
	[keys] [varchar](50) NOT NULL,
	[values] [varchar](50) NOT NULL,
 CONSTRAINT [PK_KeyList] PRIMARY KEY CLUSTERED 
(
	[keys] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeviceList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeviceList](
	[devid] [varchar](20) NOT NULL,
	[devname] [varchar](30) NULL,
	[firmware_version] [varchar](20) NULL,
	[software_version] [varchar](20) NULL,
	[photoware_version] [varchar](20) NULL,
	[WL__version] [varchar](20) NULL,
	[CH_version] [varchar](50) NULL,
	[dev_state] [int] NULL,
	[moudel_num] [varchar](20) NULL,
	[comm_type] [int] NULL,
	[comm_string] [varchar](50) NULL,
	[updatetime] [datetime] NULL,
	[checkdate] [datetime] NULL,
	[listenport] [int] NULL,
	[portcount] [int] NULL,
	[del] [bit] NULL,
	[reportcount] [int] NULL,
	[defaultgz] [int] NULL,
	[OrgId] [varchar](80) NULL,
	[devtype] [varchar](20) NULL,
	[devmodel] [int] NULL,
	[port] [varchar](20) NULL,
	[ipaddress] [varchar](30) NULL,
	[state] [int] NULL,
 CONSTRAINT [PK_DeviceList] PRIMARY KEY CLUSTERED 
(
	[devid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[portSearchGuiZeList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[portSearchGuiZeList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](20) NOT NULL,
	[name] [varchar](50) NULL,
	[portname] [varchar](50) NULL,
	[ischeck] [bit] NULL,
 CONSTRAINT [PK_ReportSearchGuiZeList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfigList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ConfigList](
	[name] [varchar](20) NOT NULL,
	[value] [varchar](255) NULL,
	[detail] [varchar](255) NULL,
 CONSTRAINT [PK_ConfigList] PRIMARY KEY CLUSTERED 
(
	[name] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PageList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PageList](
	[pageid] [int] NOT NULL,
	[pagename] [varchar](200) NOT NULL,
	[classname] [varchar](200) NULL,
	[path] [nvarchar](200) NULL,
	[comment] [nvarchar](200) NULL,
 CONSTRAINT [PK_PageList] PRIMARY KEY CLUSTERED 
(
	[pageid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MoneyBatchList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MoneyBatchList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deviceid] [nvarchar](50) NOT NULL,
	[batchno] [nvarchar](50) NULL,
	[portname] [nvarchar](10) NULL,
	[tvalue] [int] NULL,
	[fdate] [nvarchar](20) NULL,
	[ftime] [nvarchar](20) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecvList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RecvList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fdatetime] [nvarchar](40) NULL,
	[recvtext] [nvarchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeviceLogRecordList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeviceLogRecordList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deviceid] [varchar](20) NOT NULL,
	[devicename] [varchar](30) NOT NULL,
	[tablename] [varchar](100) NULL,
	[orgId] [varchar](80) NOT NULL,
	[fdatestart] [datetime] NULL CONSTRAINT [DF_DeviceLogRecordList_CreateDate]  DEFAULT (getdate()),
	[fdateend] [datetime] NULL,
 CONSTRAINT [PK_DeviceLogRecordList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MachineError]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MachineError](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[batchno] [nvarchar](50) NULL,
	[errid] [nvarchar](10) NULL,
	[errdate] [nvarchar](20) NULL,
	[errtime] [nvarchar](20) NULL,
	[deviceid] [nvarchar](30) NULL,
 CONSTRAINT [PK_MachineError] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GarbageDataList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GarbageDataList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[errormsg] [nvarchar](4000) NULL,
	[createdate] [datetime] NULL CONSTRAINT [DF_GarbageDataList_CreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_GarbageDataList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StandMoneyList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StandMoneyList](
	[bzbh] [varchar](5) NOT NULL,
	[bz] [varchar](10) NULL,
	[bb] [varchar](30) NULL,
	[me] [varchar](10) NULL,
	[dw] [varchar](10) NULL,
	[fxdw] [varchar](50) NULL,
	[createdate] [datetime] NULL CONSTRAINT [DF_StandMoneyList_CreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_StandMoneyList] PRIMARY KEY CLUSTERED 
(
	[bzbh] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogsList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogsList](
	[logsid] [int] IDENTITY(1,1) NOT NULL,
	[logstime] [datetime] NULL,
	[ipaddress] [varchar](50) NULL,
	[detail] [varchar](100) NULL,
	[logId] [varchar](10) NOT NULL,
 CONSTRAINT [PK_LogsList] PRIMARY KEY CLUSTERED 
(
	[logsid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Money_LS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Money_LS](
	[moneyid] [uniqueidentifier] NOT NULL,
	[bankid] [varchar](100) NULL,
	[bankname] [varchar](60) NULL,
	[fdate] [varchar](10) NULL,
	[ftime] [varchar](10) NULL,
	[flowno] [int] NULL,
	[batchno] [varchar](30) NULL,
	[serialno] [varchar](30) NULL,
	[price] [varchar](10) NULL,
	[kindno] [varchar](5) NULL,
	[fakes] [bit] NULL,
	[photo] [image] NULL,
	[fullphoto] [image] NULL,
	[photoname] [varchar](300) NULL,
	[devid] [varchar](20) NULL,
	[devname] [varchar](30) NULL,
	[recognitioninfo] [varchar](50) NULL,
	[mrecognitioninfo] [varchar](100) NULL,
	[bzbh] [varchar](5) NULL,
	[photowidth] [int] NULL,
	[photoheight] [int] NULL,
	[facedirect] [varchar](50) NULL,
	[refusereason] [varchar](100) NULL,
	[outport] [varchar](50) NULL,
	[JobNum] [varchar](20) NULL,
 CONSTRAINT [PK_MONEY_LS] PRIMARY KEY CLUSTERED 
(
	[moneyid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoleList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserRoleList](
	[userroleid] [int] IDENTITY(1,1) NOT NULL,
	[logid] [varchar](10) NOT NULL,
	[roleid] [int] NOT NULL,
	[ischeck] [bit] NULL,
 CONSTRAINT [PK_UserRoleList] PRIMARY KEY CLUSTERED 
(
	[userroleid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorMsgList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ErrorMsgList](
	[errorno] [varchar](50) NOT NULL,
	[errormsg] [varchar](50) NULL,
 CONSTRAINT [PK_ErrorMsgList] PRIMARY KEY CLUSTERED 
(
	[errorno] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrganizationList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrganizationList](
	[orgid] [varchar](80) NOT NULL,
	[parentid] [varchar](80) NULL,
	[orgname] [varchar](100) NOT NULL,
	[address] [nvarchar](100) NULL,
	[createuserid] [varchar](30) NULL,
	[createdate] [datetime] NULL CONSTRAINT [DF_OrganizationList_CreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_OrganizationList] PRIMARY KEY CLUSTERED 
(
	[orgid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeviceStateLoginList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeviceStateLoginList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[devicecode] [varchar](50) NULL,
	[date] [datetime] NULL,
	[state] [nvarchar](100) NULL,
 CONSTRAINT [PK_DeviceStateLoginList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NotRegisteredDeviceList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NotRegisteredDeviceList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[devicecode] [varchar](80) NULL,
	[date] [datetime] NULL,
	[state] [varchar](100) NULL,
 CONSTRAINT [PK_NotRegisteredDeviceList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NoticeInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NoticeInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DeviceId] [varchar](20) NULL,
	[state] [int] NULL,
	[Date] [datetime] NULL CONSTRAINT [DF_NoticeInfo_Date]  DEFAULT (getdate()),
 CONSTRAINT [PK_NoticeInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserList](
	[logID] [varchar](10) NOT NULL,
	[password] [varchar](10) NULL,
	[logname] [varchar](10) NULL,
	[level] [int] NULL,
	[roleID] [int] NULL,
	[email] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[birthday] [datetime] NULL,
	[isCheck] [bit] NULL,
	[orgId] [varchar](80) NULL,
 CONSTRAINT [PK_UserList] PRIMARY KEY CLUSTERED 
(
	[logID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleProgramList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RoleProgramList](
	[roleprogramid] [int] IDENTITY(1,1) NOT NULL,
	[roleid] [int] NOT NULL,
	[programid] [int] NOT NULL,
 CONSTRAINT [PK_RoleProgramList] PRIMARY KEY CLUSTERED 
(
	[roleprogramid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RoleList](
	[roleid] [int] IDENTITY(1,1) NOT NULL,
	[rolename] [varchar](20) NOT NULL,
	[ischeck] [bit] NULL,
 CONSTRAINT [PK_RoleList] PRIMARY KEY CLUSTERED 
(
	[roleid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SaveDateList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SaveDateList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[savedate] [int] NULL,
	[createdate] [datetime] NULL,
 CONSTRAINT [PK_SaveDateList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProgramList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProgramList](
	[programid] [int] IDENTITY(1,1) NOT NULL,
	[programname] [nvarchar](200) NOT NULL,
	[parentprogramid] [int] NULL,
	[ischeck] [bit] NULL,
	[framename] [varchar](50) NULL,
	[menuchk] [bit] NULL,
	[pageid] [int] NULL,
	[num] [int] NULL,
 CONSTRAINT [PK_ProgramList] PRIMARY KEY CLUSTERED 
(
	[programid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeviceTypeList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeviceTypeList](
	[code] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[createdate] [datetime] NULL,
	[ischeck] [bit] NULL,
	[SaveDate] [int] NULL,
 CONSTRAINT [PK_DeviceTypeList] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UpdateInfo](
	[type] [varchar](20) NOT NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_UpdateInfo] PRIMARY KEY CLUSTERED 
(
	[type] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HeiMingDanList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HeiMingDanList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NULL,
	[date] [datetime] NULL,
	[createuserid] [varchar](50) NULL,
 CONSTRAINT [PK_HeiMingDanList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EmployeeList](
	[jobnum] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[createdate] [datetime] NULL CONSTRAINT [DF_EmployeeList_CreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_EmployeeList] PRIMARY KEY CLUSTERED 
(
	[jobnum] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MoenyList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MoenyList](
	[moneyid] [uniqueidentifier] NOT NULL,
	[fdate] [varchar](10) NULL,
	[ftime] [varchar](10) NULL,
	[flowno] [int] NULL,
	[bachno] [varchar](50) NULL,
	[serialno] [varchar](30) NULL,
	[price] [varchar](10) NULL,
	[kindno] [varchar](5) NULL,
	[fakes] [bit] NULL,
	[photo] [image] NULL,
	[fullphoto] [image] NULL,
	[photoname] [varchar](300) NULL,
	[devid] [varchar](20) NULL,
	[devname] [varchar](30) NULL,
	[recognitioninfo] [varchar](50) NULL,
	[mrecognitioninfo] [varchar](100) NULL,
	[bzbh] [varchar](5) NULL,
	[photowidth] [int] NULL,
	[photoheight] [int] NULL,
	[facedirect] [varchar](50) NULL,
	[refusereason] [varchar](100) NULL,
	[outport] [varchar](50) NULL,
	[JobNum] [varchar](20) NULL,
	[remark] [int] NULL CONSTRAINT [DF_MoenyList_FqYj]  DEFAULT (datepart(month,getdate())%(4))
) ON [MoneyListScheme]([remark])
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'识别信息' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'MoenyList', @level2type=N'COLUMN', @level2name=N'recognitioninfo'

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LogsList_LogsList]') AND parent_object_id = OBJECT_ID(N'[dbo].[LogsList]'))
ALTER TABLE [dbo].[LogsList]  WITH CHECK ADD  CONSTRAINT [FK_LogsList_LogsList] FOREIGN KEY([logsid])
REFERENCES [dbo].[LogsList] ([logsid])



------------创建表 end----------------------------------------

------------创建存储过程---------------------------------------


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertDeviceData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		YangJun
-- Create date: 2011.12.30
-- Description:	新增设备数据
-- =============================================
CREATE PROCEDURE [dbo].[InsertDeviceData] 	-- Add the parameters for the stored procedure here
	@para1		varchar(50)			=NULL
,	@para2		varchar(50)			=NULL
,	@para3		varchar(50)			=NULL
,	@para4		varchar(50)			=NULL
,	@para5		varchar(50)			=NULL
,	@para6		varchar(50)			=NULL
,	@para7		varchar(50)			=NULL
,	@para8		varchar(50)			=NULL
,	@para9		varchar(50)			=NULL
,	@para10		varchar(50)			=NULL
,	@para11		varchar(50)			=NULL
,	@para12		varchar(50)			=NULL
,	@para13		varchar(50)			=NULL
,	@para14		varchar(50)			=NULL
,	@para15		varchar(50)			=NULL
,	@para16		varchar(50)			=NULL
,	@para17		varchar(50)			=NULL
,	@para18		varchar(50)			=NULL
,	@para19		varchar(50)			=NULL
,	@para20		varchar(50)			=NULL
,	@para21		varchar(50)			=NULL
,	@para22		varchar(50)			=NULL
,	@para23		varchar(50)			=NULL
AS
BEGIN
	declare @sql nvarchar(4000)
	set @sql=''INSERT INTO ''+@para1 +'' values(''+@para2+'',''+@para3+'',''+@para4+'',''+@para5+'',''+@para6
	+'',''+@para7+'',''+@para8+'',''+@para9+'',''+@para10+'',''+@para11+'',''+@para12+'',''+@para13+'',''+@para14
	+'',''+@para15+'',''+@para16+'',''+@para17+'',''+@para18+'',''+@para19+'',''+@para20+'',''+@para21+'',''+@para22+'',''+@para23+'')''
	print @sql
	exec (@sql)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HasDevice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[HasDevice]
	(
	@devid varchar(10),
	@devname varchar(30) OUTPUT
	)
AS
	/* SET NOCOUNT ON */
	select distinct @devname=devname from db_owner.devicelist where devid=@devid
RETURN
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOrgTjTu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		YJ
-- Create date: 2012.2.28
-- Description:	网点统计图
-- =============================================
CREATE PROCEDURE [dbo].[GetOrgTjTu]
	@StartDate		varchar(30)			= NULL
,	@EndDate		varchar(30)			= NULL
,	@UserName		varchar(30)			= NULL
,	@OrgId			varchar(1000)		= NULL
,	@DeviceId		varchar(80)			= NULL
AS
BEGIN
    

	IF @StartDate = '''' set @StartDate =NULL
	IF @EndDate = '''' set @EndDate = NULL
	IF @OrgId	= '''' set @OrgId = NULL
	IF @DeviceId = '''' set @DeviceId = NULL
	declare @sql nvarchar(max),@TableName varchar(50)
	set @TableName=''VIEW_''+@UserName
	set @sql='' select   bankid,bankname,
ISNULL(Convert(numeric(18, 0),sum(Convert(INT,me)))/10000,0) as total from (select * from ''+@TableName +'' where 1=1 and outport like ''''%出钞口%''''''



			IF @StartDate Is NOT NULL
				begin
					set @sql=@sql+'' and fdate >= ''''''+@StartDate +''''''''
				end
		
			IF @EndDate Is NOT NULL
				begin
					set @sql=@sql+'' and fdate<=''''''+@EndDate + ''''''''
				end
			IF @OrgId IS NOT NULL
				begin
					set @sql=@sql+'' and bankid in (''+@OrgId+'')''
				end
			IF @DeviceId IS NOT NULL
				begin
					set @sql=@sql+'' and devid =''''''+@DeviceId+ ''''''''
				end
	
		
	set @sql=@sql+''  ) as aa group by bankid,bankname having bankid is not null order by total desc''

	print @sql
	exec (@sql)
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchMoenyListTJ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SearchMoenyListTJ]
	@DeviceID		Varchar(20)			= NULL
,	@BatchNo		Varchar(20)			= NULL
,	@StartDate		Varchar(20)			= NULL
,	@EndDate		Varchar(20)			= NULL
AS
BEGIN
	IF @DeviceID ='''' SET @DeviceID = NULL
	IF @BatchNo ='''' SEt @BatchNo = NULL
	IF @StartDate='''' SET @StartDate=NULL
	IF @EndDate='''' SET @EndDate = NULL
		
	declare @STRSQL NVarchar(4000)
	IF @DeviceID IS NULL
		BEGIN
			
			DECLARE @DEVID VARCHAR(20)
			DECLARE @OUTPORTCOUNT INT
			SET @OUTPORTCOUNT=0
			DECLARE MYDEVICE CURSOR FOR SELECT DEVID FROM db_owner.DeviceList WHERE DEV_STATE=1
			OPEN MYDEVICE
			fetch next from MYDEVICE into @DEVID
			WHILE @@FETCH_STATUS =0
			begin
				IF @STRSQL IS NULL
					BEGIN
						SET @STRSQL=''SELECT * FROM vtable_''+@DEVID+'' where 1=1 ''
						print @STRSQL
					END
				ELSE
					BEGIN
						SET @STRSQL=@STRSQL+''  UNION ALL  SELECT * FROM vtable_''+@DEVID+'' where 1=1 ''
						print @STRSQL
					END
				IF @BatchNo IS NOT NULL SET @STRSQL=@STRSQL+N''  AND batchno=N''''''+CONVERT(VARCHAR,ISNULL(@BatchNo,''''))+''''''''	
				IF @StartDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND fdate>=N''''''+CONVERT(VARCHAR,ISNULL(@StartDate,''''))+''''''''	
				IF @EndDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND fdate<=N''''''+CONVERT(VARCHAR,ISNULL(@EndDate,''''))+''''''''	
				FETCH NEXT FROM MYDEVICE INTO @DEVID
			end
			close MYDEVICE
			deallocate MYDEVICE

		END
	ELSE
		BEGIN
			SET @STRSQL=''SELECT * FROM vtable_''+@DeviceID
					+''	WHERE 1=1 ''
			IF @BatchNo IS NOT NULL SET @STRSQL=@STRSQL+N''  AND batchno=N''''''+CONVERT(VARCHAR,ISNULL(@BatchNo,''''))+''''''''	
			IF @StartDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND fdate>=N''''''+CONVERT(VARCHAR,ISNULL(@StartDate,''''))+''''''''	
			IF @EndDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND fdate<=N''''''+CONVERT(VARCHAR,ISNULL(@EndDate,''''))+''''''''	

			SET @OUTPORTCOUNT=(SELECT portcount FROM db_owner.DeviceList WHERE devid=@DeviceID)		
		END

		PRINT @STRSQL
		DECLARE @SQL NVARCHAR(2000),@I INT
		SET @I=1
		SET @SQL=NULL
		IF @OUTPORTCOUNT!=0
			BEGIN
				WHILE(@I<=@OUTPORTCOUNT)
					BEGIN
						IF @SQL IS NULL BEGIN SET @SQL='' SUM(CASE WHEN A.outport=''''出钞口''+@I+'''''' WHEN 1 ELSE 0 END) AS ONEPORT'' END
						ELSE BEGIN SET @SQL=@SQL+'' ,SUM(CASE WHEN A.outport=''''出钞口''+@I+'''''' WHEN 1 ELSE 0 END) AS ONEPORT'' END
						SET @I=@I+1
					END

			SET @STRSQL=''SELECT COUNT(*) AS TOTAL,SUM(CASE WHEN A.refusereason IS NOT NULL THEN 1 ELSE 0 END) AS TCS
						, ''+@SQL+'' FROM ( ''+@STRSQL + '') AS A''
			END
		ELSE
			BEGIN
				SET @STRSQL=''SELECT COUNT(*) AS TOTAL,SUM(CASE WHEN A.refusereason IS NOT NULL THEN 1 ELSE 0 END) AS TCS
						 FROM ( ''+@STRSQL + '') AS A''
			END
		
			
	   print @STRSQL
		EXEC (@STRSQL)

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEveryMeTJTu]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Description:	网点面额统计
-- =============================================
CREATE PROCEDURE [dbo].[GetEveryMeTJTu]
	@StartDate		varchar(30)				= NULL
,	@EndDate		varchar(30)				= NULL
,	@UserName		varchar(30)				= NULL
,	@OrgId			varchar(1000)			= NULL
,	@DeviceId		varchar(80)				= NULL
AS
BEGIN
	declare @sql nvarchar(max),@TableName varchar(50)
	set @TableName=''VIEW_''+@UserName;

	IF @StartDate ='''' set @StartDate = NULL
	IF @EndDate = '''' set @EndDate = NULL
	IF @UserName ='''' set @UserName = NULL
	IF @OrgId='''' set @OrgId= NULL
	IF @DeviceId = '''' set @DeviceId = NULL
	IF @UserName IS NOT NULL
		begin
			set @sql='' select bankid,me,Convert(numeric(18, 0),count(distinct serialno))*me/10000 as total from 
					 (select bankid,me,serialno from ''+@TableName+'' where 1=1  and bankid is not null and outport like ''''%出钞口%''''''

				IF @StartDate IS NOT NULL
					begin
						set @sql=@sql+'' and fdate >=''''''+@StartDate+''''''''
					end
				IF @EndDate IS NOT NULL
					begin
						set @sql=@sql+'' and fdate <=''''''+@EndDate+''''''''
					end
				IF @OrgId IS NOT NULL
					begin
						set @sql=@sql+'' and bankid in (''+@OrgId+'')''
					end

				IF @DeviceId is not null
					begin
						set @sql=@sql+'' and devid = ''''''+@DeviceId + ''''''''
					end

				set @sql=@sql+'' ) as aa  group by bankid,me having me in(1,10,20,50,100)
						 order  by total desc''
			print @sql
			exec (@sql)

	end
END









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PageSplit]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[PageSplit]
	@SqlStr						NVARCHAR(MAX)
,	@OrderStr					NVARCHAR(MAX)
,	@PageIndex					INT						= 1 
,	@PageSize					INT						= 20
,	@RecordCount					INT						= 0		OUTPUT
AS
BEGIN

	IF @PageIndex IS NULL SET @PageIndex=1
	IF @PageSize IS NULL SET @PageSize=20
	
	DECLARE @Sql NVARCHAR(MAX)
	SET @Sql=''SELECT @RecordCount=COUNT(*) FROM (''+@SqlStr+'') ps1''

	EXEC sp_executesql @Sql,N''@RecordCount INT OUTPUT'',@RecordCount OUTPUT

	SET @Sql=''SELECT * FROM (
			SELECT TOP '' + CONVERT(VARCHAR,@PageIndex*@PageSize) + '' ROW_NUMBER() OVER (ORDER BY ''+@OrderStr+'') AS ROWID,ps1.* 
			FROM ('' + @SqlStr + '') ps1
		) ps2 WHERE ps2.ROWID>''+CONVERT(VARCHAR,(@PageIndex-1)*@PageSize)

    print @Sql

	EXEC(@Sql)
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExcuteSql]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ExcuteSql]
	@sql nvarchar(4000)			= null
AS
BEGIN
	if @sql='''' set @sql=null

	if @sql is not null
		begin
			print @sql
			exec (@sql)
		end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CreateUserView]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'








CREATE PROCEDURE [dbo].[CreateUserView]
	(
	@logid varchar(30)
	)
AS
	/* 建立用户视图 */
	DECLARE #myview CURSOR LOCAL FOR SELECT name FROM SYSOBJECTS where name like ''vtable_%'' and type=''V'';
	DECLARE @sql varchar(8000);
	DECLARE @viewname varchar(20);
	Declare @Isxz INT
	SET @sql='''';
	OPEN #myview;
	FETCH NEXT FROM #myview INTO @viewname;
	WHILE @@FETCH_STATUS=0
	BEGIN
		SET @Isxz=(select count(*) from DeviceList where devid=SUBSTRING(@viewname,charindex(''_'',@viewname)+1,len(@viewname)) and del=0)
		print @isxz
		print @viewname
		IF @Isxz>0
		begin
			
			SET @sql=@sql+'' union All select moneyid,devname,devid,bankid,bankname
				,batchno,fdate,ftime,serialno,flowno
			    ,bzbh,facedirect,refusereason,outport,photo
			    ,fullphoto,me,bz,bb from ''+@viewname;
		end
		FETCH NEXT FROM #myview INTO @viewname
	END
	CLOSE #myview;
	--SET @sql=@sql+'' union All select * from vtable_LS''
	SET @sql=SUBSTRING(@sql,11,len(@sql));
	SET @viewname=''VIEW_''+@logid;
	IF OBJECT_ID(@viewname,''V'') IS NOT NULL
	BEGIN
		EXEC(''DROP VIEW ''+@viewname);
	END
	print @sql
	IF @sql IS NOT NULL and @sql!=''''
	begin
		SET @sql='' CREATE VIEW ''+@viewname+'' AS ''+@sql;
	end
	else
	begin
		SET @sql=''CREATE VIEW ''+@viewname+'' AS select * from vtable_LS'';
	end
		print @sql
		EXEC(@sql);
	RETURN


















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GETDATATJ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[GETDATATJ]
	@DeviceID		Varchar(20)			= NULL
,	@BatchNo		Varchar(20)			= NULL
,	@StartDate		Varchar(20)			= NULL
,	@EndDate		Varchar(20)			= NULL

	
AS
BEGIN
	IF @DeviceID ='''' SET @DeviceID = NULL
	IF @BatchNo ='''' SEt @BatchNo = NULL
	IF @StartDate='''' SET @StartDate=NULL
	IF @EndDate='''' SET @EndDate = NULL	

--------- 设备钞票集合 ------
	DECLARE @STRSQL NVARCHAR(4000) 
	
	IF @DeviceID IS NULL BEGIN SET @STRSQL=(SELECT dbo.GetAllMoenyTabStr())  END
	ELSE BEGIN SET @STRSQL=''SELECT * FROM vtable_''+@DeviceID +'' where 1=1 ''  END
	print @STRSQL
	IF @BatchNo IS NOT NULL SET @STRSQL=@STRSQL+N''  AND batchno=N''''''+CONVERT(VARCHAR,ISNULL(@BatchNo,''''))+''''''''	
	IF @StartDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND fdate>=N''''''+CONVERT(VARCHAR,ISNULL(@StartDate,''''))+''''''''	
	IF @EndDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND fdate<=N''''''+CONVERT(VARCHAR,ISNULL(@EndDate,''''))+''''''''	

	PRINT @STRSQL
	EXEC (@STRSQL)
	
----------------------------------------------


---------设备钞票总数、退钞数量---------
	declare @sql1 nvarchar(4000)
	set @sql1='' select count(*) as total ,sum(case when a.refusereason is not null 
				then 1 else 0 end) as tcs from ('' +@STRSQL +'' ) as a''

	print @sql1
	exec (@sql1)
------------------------------------------------------------

---------识别统计---------------------------

	declare @sql3 nvarchar(4000)
	set @sql3=''''
	
	set @sql3='' select count(*) as total,sum(case when a.serialno like ''''%?%'''' or 
			a.serialno like ''''%#%'''' or a.serialno like ''''%*%'''' then 1 else 0 end) as bnsbs from (''
				+  @STRSQL + '' ) as a''
	
	print @sql3
	exec (@sql3)
-----------------------------------------------------------------------

---------当个设备各出钞口数量-----------------------------
	declare @portTotal INT,@sql2 nvarchar(4000)
	set @sql2=''''
	
	IF @DeviceID IS NOT NULL
		begin
			set @portTotal=(select portcount from DeviceList where devid=@DeviceID )
			declare @i int,@outportname varchar(50)
			set @i=1
			print @portTotal
			print @i
			while(@i<=@portTotal)
				begin
					print @outportname
					set @outportname=''出钞口''+Convert(varchar,@i)
					print @outportname
					if @sql2='''' begin set @sql2='' select sum(case when a.outport=''''''+@outportname+'''''' then 1 else 0 end ) as cck''+Convert(varchar,@i) end
					else begin set @sql2=@sql2+''  ,sum(case when a.outport=''''''+@outportname+'''''' then 1 else 0 end ) as cck''+convert(varchar,@i) end
					set @i=@i+1
				end
			set @sql2=@sql2 +'' ,''+Convert(varchar,@portTotal)+'' as cck from ('' + @STRSQL + '' ) as a''
			print @sql2
			exec (@sql2)
		end
------------------------------------------------------------------------
	
END



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMoneyId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMoneyId]
	@tablename			varchar(100)			= null
,	@fdate				varchar(30)				= null
,	@serino				varchar(50)				= null
,	@ftime				varchar(30)				= null
AS
BEGIN
	declare @sql nvarchar(4000)

	if @tablename='''' set @tablename=null
	if @fdate='''' set @fdate=null
	if @serino='''' set @serino=null
	if @ftime='''' set @ftime=null

	set @sql='' select moneyid from ''+@tablename+'' where 1=1 ''

	if @fdate is not null
		begin
			set @sql=@sql+'' and fdate=''''''+@fdate+''''''''
		end
	if @ftime is not null
		begin
			set @sql=@sql+'' and ftime=''''''+@ftime+''''''''
		end
	if @serino is not null
		begin
			set @sql=@sql+'' and serialno=''''''+@serino+''''''''
		end

	print @sql

	exec (@sql)
	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DropMoneyTable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[DropMoneyTable]
	(
	@devid varchar(30)
	)
AS
	/* SET NOCOUNT ON */
	DECLARE @tablename varchar(100);
	DECLARE @viewer varchar(100);
	DECLARE @sql varchar(200);
	
	SET @tablename=''Money_''+@devid;
	SET @sql=''drop table ''+@tablename;
	EXEC(@sql);
	print @sql
	SET @viewer=''vtable_''+@devid;
	--SET @sql=''drop view ''+@viewer;
	EXEC(@sql);

	RETURN






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CleanRecord]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

create PROCEDURE [dbo].[CleanRecord]
AS
	DECLARE @newdate DATETIME;
	DECLARE @date varchar(10);
	DECLARE @tablename varchar(20);
	DECLARE @sql varchar(200);
	DECLARE @devid varchar(10);

	SET @newdate=DATEADD(mm,-3,GETDATE());
	SET @date=CONVERT(varchar(30),@newdate,20);
	SET @date=SUBSTRING(@date,1,10);

	DECLARE #tablelist CURSOR LOCAL FOR SELECT devid FROM DeviceList;
	OPEN #tablelist;
	FETCH NEXT FROM #tablelist INTO @devid;
	WHILE @@FETCH_STATUS=0
	BEGIN
		SET @tablename=''Money_''+@devid;
		SET @sql=''DELETE FROM ''+@tablename+'' WHERE fdate<''''''+@date+'''''''';
		EXEC(@sql);
		FETCH NEXT FROM #tablelist INTO @devid;

	END
	CLOSE #tablelist;

	RETURN


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[test]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[test]
	@sql nvarchar(4000)
AS
BEGIN
	print @sql
	exec (@sql)
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateDeviceVersion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateDeviceVersion]
	@devid				varchar(50)					= null
,	@firmware_version	varchar(20)					= null  ----主控版本
,	@software_version	varchar(20)					= null  -----软件版本
,	@photoware_version	varchar(20)					= null ----图形版本
,	@ch					varchar(20)					= null  ---测厚版本
,	@wl					varchar(20)					= null  ---网络版本
AS
BEGIN
	UPDATE  DeviceList
		SET         firmware_version = @firmware_version, software_version = @software_version, 
                photoware_version = @photoware_version, CH_version =@ch, WL__version =@wl
		WHERE   devid = @devid
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteDevice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[DeleteDevice]
	@DeviceID			Varchar(20)					= NULL
AS
BEGIN

	Update DeviceList set del=1 where devid=@DeviceID

	update UpdateInfo set date=getdate() where type=''SB''

END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchProgramList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SearchProgramList]
	@ProgramID			INT				= NULL  
,	@ParentProgramID	INT				= NULL  
,	@ClassName			NVARCHAR(200)   = NULL  
AS  
BEGIN  
 WITH tmp_Program (ProgramID,ProgramName,ParentProgramID)  
 AS  
 (
  SELECT a.ProgramID,ProgramName=CONVERT(NVARCHAR(200),''<b>''+a.ProgramName+''</b>''),a.ParentProgramID  
  FROM ProgramList a  
  INNER JOIN PageList b ON b.PageID=a.PageID  
  WHERE b.ClassName=@ClassName and (a.ProgramID = @ParentProgramID or isnull(@ParentProgramID,'''') = '''') 
  UNION ALL  
  SELECT a.ProgramID,a.ProgramName,a.ParentProgramID   
  FROM ProgramList a  
  JOIN tmp_Program b ON b.ParentProgramID=a.ProgramID
 )  
 SELECT * FROM tmp_Program WHERE ParentProgramID!=0 Order by ProgramID   
END  
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchKaCaoReasonTJList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		YangJun
-- Create date: 2012.3.1
-- Description:	查询卡钞原因列表
-- =============================================
CREATE PROCEDURE [dbo].[SearchKaCaoReasonTJList]
	@DeviceId							varchar(20)				= NULL
,	@BatchDateStart						varchar(20)				= NULL
,	@BatchDateEnd						varchar(20)				= NULL
,	@UserId								varchar(20)				= NULL
,	@OrgId								varchar(2000)			= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT	

AS
BEGIN
	declare @sql nvarchar(4000)
	IF @DeviceId='''' set @DeviceId = NULL
	IF @BatchDateStart = '''' set @BatchDateStart = NULL
	IF @BatchDateEnd = '''' set @BatchDateEnd = NULL
	IF @OrgId='''' set @OrgId= NULL
	
	declare @PortName varchar(10),@cckcount int ,@tckcount int,@strs varchar(500)

	DECLARE MYData CURSOR FOR SELECT portname FROM MoneyBatchList group by portname
	 set @strs=''''
	set @sql='' select d.deviceid,d.batchno ''	
	
	OPEN MYData
			fetch next from MYData into @PortName
			WHILE @@FETCH_STATUS =0
			begin
				
				set @sql=@sql+'',sum(case when d.portname=''''''+@PortName+'''''' then d.tvalue else 0 end) as ''+@PortName
				IF @strs = ''''
					begin
						set @strs=''sum(case when d.portname=''''''+@PortName+'''''' then d.tvalue else 0 end) ''
					end
				else
					begin
						set @strs=@strs+''+sum(case when d.portname=''''''+@PortName+'''''' then d.tvalue else 0 end) ''
					end		
				FETCH NEXT FROM MYData INTO @PortName
			end
			close MYData
			deallocate MYData
		IF @strs!=''''
			begin
				set @strs='',(''+@strs+'' ) as Total ''
			end	
	set @sql=@sql+@strs+''
					from 
					(select c.id,c.deviceid,c.batchno,c.portname,c.tvalue,c.fdate,c.ftime,dd.OrgId from MoneyBatchList
						as c
					 left join DeviceList as dd on (dd.devid=c.deviceid)
					 where 1=1 ''
	
	
	
	IF @DeviceId IS NOT NULL
		begin
			set @sql=@sql+'' and c.deviceid = ''''''+@DeviceId+''''''''
		end
	IF @BatchDateStart IS NOT NULL
		begin
			set @sql=@sql+'' and c.fdate>=''''''+@BatchDateStart+''''''''
		end
	IF @BatchDateEnd IS NOT NULL
		begin
			set @sql=@sql+'' and c.fdate<=''''''+@BatchDateEnd+''''''''
		end
	IF @OrgId IS NOT NULL
		begin
			set @sql=@sql+'' and dd.OrgId in (''+@OrgId+'')''
		end

	set @sql=@sql+'' ) as d group by d.deviceid,d.batchno HAVING d.deviceid is not null ''
	declare @ViewTable varchar(20)
	set @ViewTable=(''VIEW_''+@UserId)
	set @sql='' select *
				,(select top 1 (fdate+'''' ''''+ftime) as fdatetime 
					from ''+@ViewTable+'' where batchno=b.BatchNo order by fdate,ftime asc ) as StartDate
				,(select top 1 (fdate+'''' ''''+ftime) as fdatetime 
					from ''+@ViewTable+'' where batchno=b.BatchNo order by fdate,ftime desc ) as EndDate
				,(select count(*) from MachineError where batchNo=b.BatchNo and deviceid=b.deviceid) as ErrorCS
				from (''+@sql+'' ) as b''		
	
	
	print @sql
	IF @PageSize!=0 and @PageIndex!=0
		begin

			EXEC dbo.PageSplit @sql,'' batchno '',@PageIndex,@PageSize,@RecordCount OUTPUT	
		end
	else
		begin
			exec(@sql)
		end
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertLogsList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertLogsList]
	@ipAddress			varchar(50)			=NULL
,	@detail				Varchar(100)		=NULL
,	@logID				Varchar(10)			=NULL
AS
BEGIN
	INSERT INTO LogsList
	(	logsTime
		,	ipAddress
		,	detail
		,	logID)
	VALUES
	(	getdate()
		,	@ipAddress
		,	@detail
		,	@logID)
		
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteDeviceZUOYE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[DeleteDeviceZUOYE]
AS
BEGIN
	begin tran
	
	
	DECLARE @DeviceId varchar(30)

	DECLARE MYDEVICE CURSOR FOR SELECT DEVID FROM DeviceList WHERE  del=1
			OPEN MYDEVICE
			fetch next from MYDEVICE into @DeviceId
			WHILE @@FETCH_STATUS =0
			begin
				print @DeviceId
				exec DropMoneyTable @DeviceId
			FETCH NEXT FROM MYDEVICE INTO @DeviceId
			end

			close MYDEVICE
			deallocate MYDEVICE

		Delete from DeviceList where del=1;
		delete from dbo.Money_LS
	
	if  @@error<>0 
	begin
		rollback   tran   
	end
	else
	begin
		commit  tran
	end	

END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteMoneyLS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		YangJun
-- Create date: 2012.3.5
-- Description:	删除临时表数据
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMoneyLS]
	
AS
BEGIN
	delete from Money_LS
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MoveMoney_LSData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[MoveMoney_LSData]
	@DeviceID			varchar(30)					= NULL
,	@DeviceName			Varchar(30)					= NULL
,	@OrgId				varchar(80)					= NULL
AS
BEGIN
		declare @lssql nvarchar(4000),@isHaveData int,@OrgName varchar(50)
	set @OrgName=(select OrgName from OrganizationList where OrgId=@OrgId)
	print @DeviceID
	set @isHaveData=(select count(*) from Money_LS where devid=@DeviceID)
	print @isHaveData
	IF @isHaveData>0
		begin
			print ''aa''
			update Money_LS set bankid=@OrgId,bankname=@OrgName,devname=@DeviceName where devid=@DeviceID
			set @lssql=''insert into Money_''+@DeviceID+'' select * from Money_LS where devid=''''''+@DeviceID+''''''''
		
			exec(@lssql)
			print @lssql
	delete from Money_LS where devid=@DeviceID
		end
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchUserList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[SearchUserList]
	
AS
BEGIN
	select a.logid,a.password,a.logname,a.[level],a.roleID,a.isCheck,a.email,a.OrgId 
	,b.OrgName,b.ParentId
	from UserList as a
	left join OrganizationList as b on (a.OrgId=b.OrgId)
END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertDeviceStateLog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertDeviceStateLog]
	@devicecode				varchar(80)				= null
,	@date					varchar(30)				= null
,	@state					varchar(100)			= null
AS
BEGIN
	insert into DeviceStateLoginList (devicecode,date,state) values (@devicecode,@date,@state)


END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateUserProgram]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[UpdateUserProgram]
	@StrSql NVarchar(4000) 
,	@RoleID  Varchar(20)
AS
BEGIN
	print @StrSql
	begin tran
	
	declare @counts INT
	set @counts=(select count(*) from dbo.RoleProgramList where roleID=@RoleID)

	IF @counts >0
	begin
		delete from dbo.RoleProgramList where roleID=@RoleID
	end
	
	exec (@StrSql)
	if  @@error<>0 
	begin
		rollback   tran   
	end
	else
	begin
		commit  tran
	end
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteUserProgram]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[DeleteUserProgram]
	@RoleID Varchar(20)
,	@ProgramID	Varchar(20)
	
AS
BEGIN

	begin tran	

	declare @isDel INT ,@ParentPid INT
	set @ParentPid=(select parentProgramID from dbo.ProgramList where  programID=@ProgramID)
	print @ParentPid
	set @isDel=(select count(*) from dbo.RoleProgramList where programID in (select programID 
		from dbo.ProgramList where parentProgramID=@ParentPid) and roleid=@RoleID)
	print @isDel
	IF @isDel>1
		begin
			delete from dbo.RoleProgramList where roleID=@RoleID and programID=@ProgramID
		end
	else
		begin
			delete from dbo.RoleProgramList where roleID=@RoleID and programID=@ProgramID
			delete from dbo.RoleProgramList where roleID=@RoleID and programID=@ParentPid
		end	

	if  @@error<>0 
	begin
		rollback   tran   
	end
	else
	begin
		commit  tran
	end

END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClearData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ClearData] 
	
AS
BEGIN
	begin tran
	declare @SaveDate INT,@NewDate datetime,@aa varchar(30)
	,@DeviceId varchar(20),@sql varchar(1000)
	set @SaveDate=(select  SaveDate from SaveDateList )
	
	set @NewDate=(select dateadd(dd,-@SaveDate,getdate()))
	set @aa=Convert(varchar(11),@NewDate,20)
	print @aa
	DECLARE MYDEVICE CURSOR FOR SELECT DEVID FROM DeviceList
			OPEN MYDEVICE
			fetch next from MYDEVICE into @DeviceId
			WHILE @@FETCH_STATUS =0
			begin
			print @aa
			set @sql=''delete from Money_''+@DeviceId
			print @sql
				exec (@sql)
			FETCH NEXT FROM MYDEVICE INTO @DeviceId
			end

			close MYDEVICE
			deallocate MYDEVICE

	set @sql=''delete from Money_LS ''
	exec(@sql)

	if  @@error<>0 
	begin
		rollback  tran   
	end
	else
	begin
		commit  tran
	end	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteDeviceDateZuoYe]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		YangJun
-- Create date: 2011.12.24
-- Description:	定期删除数据作业
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDeviceDateZuoYe]
AS
BEGIN

	begin tran
	declare @SaveDate INT,@NewDate datetime,@aa varchar(30)
	,@DeviceId varchar(20),@sql varchar(1000)
	set @SaveDate=(select  SaveDate from SaveDateList )
	
	set @NewDate=(select dateadd(dd,-@SaveDate,getdate()))
	set @aa=Convert(varchar(11),@NewDate,20)
	print @aa
	DECLARE MYDEVICE CURSOR FOR SELECT DEVID FROM DeviceList
			OPEN MYDEVICE
			fetch next from MYDEVICE into @DeviceId
			WHILE @@FETCH_STATUS =0
			begin
			print @aa
			set @sql=''delete from Money_''+@DeviceId+'' where fdate<''''''+@aa+''''''''
			print @sql
				exec (@sql)
			FETCH NEXT FROM MYDEVICE INTO @DeviceId
			end

			close MYDEVICE
			deallocate MYDEVICE

	set @sql=''delete from Money_LS where fdate<''''''+@aa+''''''''
	exec(@sql)

	if  @@error<>0 
	begin
		rollback  tran   
	end
	else
	begin
		commit  tran
	end	
	
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertSaveDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		YangJun
-- Create date:2011.12.24
-- Description:	保存数据保存天数
-- =============================================
CREATE PROCEDURE [dbo].[InsertSaveDate]
	
	@DateSaveTime		INT		= NULL
AS
BEGIN
			declare @iscz int
			set @iscz=(select count(*) from SaveDateList)
			if @iscz>0
			begin
				update SaveDateList set SaveDate=@DateSaveTime,CreateDate=getdate()
			end
			else
			begin
			INSERT INTO SaveDateList values (@DateSaveTime,getdate())
			end
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchProgramList1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SearchProgramList1]
	@RoleID								INT						= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT	
AS
BEGIN
	DECLARE @STRSQL NVARCHAR(4000)

	DECLARE @ProgramID VARCHAR(20),@ProgramName VARCHAR(50)
	
	IF @RoleID=''''	SET		@RoleID=NULL	

	set @STRSQL=NULL
			DECLARE MYDEVICE CURSOR FOR SELECT programID,programName FROM dbo.ProgramList WHERE parentProgramID=1
			OPEN MYDEVICE
			fetch next from MYDEVICE into @ProgramID,@ProgramName
			WHILE @@FETCH_STATUS =0
			begin
				IF @STRSQL IS NULL
					BEGIN
						SET @STRSQL=''SELECT *,''''''+@ProgramName+'''''' as name from dbo.ProgramList where parentProgramID=''+@ProgramID 
						print @STRSQL
					END
				ELSE
					BEGIN
						SET @STRSQL=@STRSQL+''  UNION ALL  SELECT *,''''''+@ProgramName+'''''' as name from dbo.ProgramList where parentProgramID=''+@ProgramID
						print @STRSQL
					END	
				FETCH NEXT FROM MYDEVICE INTO @ProgramID,@ProgramName
			end
			close MYDEVICE
			deallocate MYDEVICE
	
			IF @RoleID IS NOT NULL SET @STRSQL=''select * from (''+@STRSQL+
			'') as a where programID in (select programID from RoleProgramList where roleID=N''''''+CONVERT(VARCHAR,ISNULL(@RoleID,''''))+'''''')''
	
			print @STRSQL
			EXEC dbo.PageSplit @STRSQL,'' programID,name '',@PageIndex,@PageSize,@RecordCount OUTPUT

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchProgramList2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SearchProgramList2]
	@RoleID								Varchar(10)						= NULL
AS
BEGIN
	DECLARE @STRSQL NVARCHAR(4000)

	DECLARE @ProgramID VARCHAR(20),@ProgramName VARCHAR(50)
	
	IF @RoleID=''''	SET		@RoleID=NULL	

	set @STRSQL=NULL
			DECLARE MYDEVICE CURSOR FOR SELECT programID,programName FROM dbo.ProgramList WHERE parentProgramID=1 
			OPEN MYDEVICE
			fetch next from MYDEVICE into @ProgramID,@ProgramName
			WHILE @@FETCH_STATUS =0
			begin
				IF @STRSQL IS NULL
					BEGIN
						SET @STRSQL=''(select ''''''+@ProgramID+'''''' as pid,''''''+@ProgramName+'''''' as pname,''''父菜单'''' as cd, (select count(*) from ProgramList where parentProgramID=''+@ProgramID+'') as countcd from dbo.ProgramList
									 union select programID as pid,programName as pname,''''''+@ProgramName+'''''' as cd,0 as countcd from ProgramList
									 where parentProgramID=''+@ProgramID +'')''
						print @STRSQL
					END
				ELSE
					BEGIN
						SET @STRSQL=@STRSQL+''  UNION ALL (select ''''''+@ProgramID+'''''' as pid,''''''+@ProgramName+'''''' as pname,''''父菜单'''' as cd, (select count(*) from ProgramList where parentProgramID=''+@ProgramID+'') as countcd from dbo.ProgramList
									 union select programID as pid,programName as pname,''''''+@ProgramName+'''''' as cd,0 as countcd from ProgramList
									 where parentProgramID=''+@ProgramID +'')''
						print @STRSQL
					END	
				FETCH NEXT FROM MYDEVICE INTO @ProgramID,@ProgramName
			end
			close MYDEVICE
			deallocate MYDEVICE
	
	
			print @STRSQL
			
			SET @STRSQL=''select *,(case when (select count(*) from dbo.RoleProgramList where roleID=''+@RoleID+'' and programID=pg.pid) 
						=1 then 1 else 0 end) as isxz from ( '' +@STRSQL +'' ) as pg''
			print @STRSQL
			exec (@STRSQL)
			--EXEC dbo.PageSplit @STRSQL,'' programID '',@PageIndex,@PageSize,@RecordCount OUTPUT

END









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchNoDevicePage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchNoDevicePage]
	@DevId							varchar(20)					= null
,	@PageIndex						INT							= NULL
,	@PageSize						INT							= NULL
,	@RecordCount					INT							= NULL	OUTPUT
AS
BEGIN
	declare @sql nvarchar(4000)

	if @Devid ='''' set @DevId=null

	set @sql='' select id,DeviceId,state,date from NoticeInfo where 1=1 ''

	if @DevId is not null
		begin
			set @sql=@sql+'' and DeviceId like ''''%''+@Devid+''%''''''
		end

	print @sql

	EXEC dbo.PageSplit @sql,'' date desc '',@PageIndex,@PageSize,@RecordCount OUTPUT
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchHeiMingDanPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SearchHeiMingDanPage]
	@Code					varchar(50)				= null
,	@PageIndex				INT						= NULL
,	@PageSize				INT						= NULL
,	@RecordCount			INT						= NULL	OUTPUT
AS
BEGIN
	if @Code='''' set @Code=null

	declare @sql nvarchar(4000)

	set @sql=''select id,code,date,createuserid from HeiMingDanList where 1=1 ''

	if @Code is not null
		begin
			set @sql=@sql+'' and code like ''''%''+@Code+''%''''''
		end
	

	print @sql

	EXEC dbo.PageSplit @sql,'' id desc '',@PageIndex,@PageSize,@RecordCount OUTPUT
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchDeviceModelPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchDeviceModelPage]
	@DeviceType				varchar(30)				= null
,	@ModelName				varchar(50)				= null
,	@PageIndex				INT						= NULL
,	@PageSize				INT						= NULL
,	@RecordCount			INT						= NULL	OUTPUT
AS
BEGIN
	if @ModelName='''' set @ModelName=null
	if @DeviceType='''' set @DeviceType=null

	declare @sql nvarchar(4000)

	set @sql=''select a.id,a.name,a.cck,a.tck,a.type
				,(select name from DeviceTypeList where code=a.type) as typename
				,(select count(*) from DeviceList where devmodel=a.id) as count
				from DeviceModelList as a where 1=1 ''

	if @ModelName is not null
		begin
			set @sql=@sql+'' and name like ''''%''+@ModelName+''%''''''
		end
	if @DeviceType is not null
		begin
			set @sql=@sql+'' and type =''''''+@DeviceType+''''''''
		end

	print @sql

	EXEC dbo.PageSplit @sql,'' id desc '',@PageIndex,@PageSize,@RecordCount OUTPUT
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchDeviceLogRecordPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchDeviceLogRecordPage]
	@OrgId			varchar(1000)				= null
,	@StartDate		varchar(30)					= null
,	@EndDate		varchar(30)					= null
,	@devid			varchar(80)					= null
,	@PageIndex		INT							= NULL
,	@PageSize		INT							= NULL
,	@RecordCount	INT							= NULL	OUTPUT
AS
BEGIN
	if @OrgId='''' set @OrgId=null
	if @StartDate='''' set @StartDate=null
	if @EndDate='''' set @EndDate=null
	if @devid='''' set @devid=null

	declare @sql nvarchar(4000)

	set @sql=''SELECT [id],[deviceid],[devicename],[tablename] ,[orgId] ,[fdatestart],[fdateend]
				FROM [DeviceLogRecordList] where 1=1 ''
	if @OrgId is not null
		begin
			set @sql=@sql+'' and orgId in (''+@OrgId+'')''
		end
	if @StartDate is not null 
		begin
			set @sql=@sql+'' and fdateend>=''''''+@StartDate+''''''''
		end
	if  @EndDate is not null
		begin
			set @sql=@sql+'' and fdatestart<=''''''+@EndDate+''''''''
		end
	if @devid is not null
		begin
			set @sql=@sql+'' and deviceid=''''''+@devid+''''''''
		end
--	if @EndDate is not null
--		begin
--			set @sql=@sql+'' or fdatestart<=''''''+@EndDate+'''''')''
--		end

	print @sql

	EXEC dbo.PageSplit @sql,'' id '',@PageIndex,@PageSize,@RecordCount OUTPUT
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEveryOrgStandMoneyTJ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[GetEveryOrgStandMoneyTJ]
	@StartDate						varchar(30)					= NULL
,	@EndDate						varchar(30)					= NULL
,	@DeviceId						varchar(50)					= NULL
,	@OrgId							varchar(1000)				= NULL
,	@UserName						varchar(50)					= NULL
,	@PageIndex						INT							= NULL
,	@PageSize						INT							= NULL
,	@RecordCount					INT							= NULL	OUTPUT
AS
BEGIN

	IF @StartDate = '''' set @StartDate = NULL
	IF @EndDate = '''' set @EndDate = NULL
	IF @DeviceId='''' set @DeviceId = NULL
	IF @OrgId='''' set @OrgId =null

	declare @sql nvarchar(max),@TableName varchar(50)
	
	set @TableName=''VIEW_''+@UserName

--	set @sql='' select bz,bankid,bankname,Convert(numeric(18, 0),sum(Convert(INT,me)))/10000 as total,Convert(numeric(18, 0),sum(case when Convert(INT,me)=100 then 100 else 0 end))/10000 as ybtotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=50 then 50 else 0 end))/10000 as wstotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=20 then 20 else 0 end))/10000 as estotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=10 then 10 else 0 end))/10000 as ystotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=5 then 5 else 0 end))/10000 as wktotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=1 then 1 else 0 end))/10000 as yktotal
--				from (select * from ''+@TableName +'' where 1=1 and outport like ''''%出钞口%''''''




set @sql='' select bankid,bankname,bz,me,total into ##Report from (
			select bankid,bz,me,bankname,count(distinct serialno) as total from 
			( select bankid,bz,me,bankname,serialno from ''+@TableName +'' where 1=1 and outport like ''''%出钞口%''''''

	IF @StartDate IS NOT NULL
		begin
			set @sql=@sql+'' and fdate >=''''''+@StartDate + ''''''''
		end	
	IF @EndDate IS NOT NULL
		begin
			set @sql=@sql+'' and fdate <=''''''+@EndDate + ''''''''
		end
	IF @OrgId Is NOT NULL
		begin
			set @sql=@sql+'' and bankid in (''+@OrgId+'')''
		end

	IF @DeviceId IS NOT NULL
		begin
			set @sql=@sql+'' and devid=''''''+@DeviceId+''''''''
		end


	
--		set @sql=@sql+'' )  as aa group by bankid,bankname,bz having bz is not null and bankid is not null''

		set @sql=@sql+'' ) as aa  group by bankid,bz,me,bankname) as cc''

		exec(@sql)
	declare @sql1 nvarchar(4000)

	set @sql1=''select bankid,bz,bankname
		,ISNULL(Convert(numeric(18, 0),(select total from ##Report where me=100))*100/10000,0) as ybtotal
		,ISNULL(Convert(numeric(18, 0),(select total from ##Report where me=50))*50/10000,0) as wstotal
		,ISNULL(Convert(numeric(18, 0),(select total from ##Report where me=20))*20/10000,0) as estotal
		,ISNULL(Convert(numeric(18, 0),(select total from ##Report where me=10))*10/10000,0) as ystotal
		,ISNULL(Convert(numeric(18, 0),(select total from ##Report where me=5))*5/10000,0) as wktotal
		,ISNULL(Convert(numeric(18, 0),(select total from ##Report where me=1))*1/10000,0) as yktotal
		,Convert(numeric(18, 0),
		(Convert(int,ISNULL((select total from ##Report where me=100),0)*100)
		+Convert(int,ISNULL((select total from ##Report where me=50),0)*50)
		+Convert(int,ISNULL((select total from ##Report where me=20),0)*20)
		+Convert(int,ISNULL((select total from ##Report where me=10),0)*10)
		+Convert(int,ISNULL((select total from ##Report where me=5),0)*5)
		+Convert(int,ISNULL((select total from ##Report where me=1),0))
		))/10000 as total
		from ##Report
		group by bankid,bz,bankname having bz is not null ''

	
	PRINT @sql
	print @sql1
	IF @PageIndex=0 and @PageSize=0
		begin
			exec(@sql1)
		end
	ELSE
		begin
			EXEC dbo.PageSplit @sql1,'' bankid '',@PageIndex,@PageSize,@RecordCount OUTPUT
		end

drop table ##Report
	
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KaCaoReasonSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		YangJun
-- Create date: 2012.3.1
-- Description:	查看卡钞原因
-- =============================================
CREATE PROCEDURE [dbo].[KaCaoReasonSearch]
	@DeviceCode							varchar(20)				= NULL
,	@BatchNo							varchar(20)				= NULL
,	@DeviceId							varchar(30)				= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT
AS
BEGIN
	declare @sql nvarchar(4000)
	set @sql='' select a.ID,a.batchNo,a.errid,(a.errdate+'''' ''''+errtime) as errdatetime,a.devid
				,(select errormsg from ErrorMsgList where errorno=a.errid) as ErrorMsg
				from MachineError as a where a.batchNo=''''''+@BatchNo+'''''' and devid=''''''+@DeviceId+''''''''
	print @sql
		EXEC dbo.PageSplit @sql,'' ID '',@PageIndex,@PageSize,@RecordCount OUTPUT	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchDayCollection]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[SearchDayCollection]
	@SearchDate							Varchar(20)				= NULL
,	@SearchDateEnd						varchar(20)				= NULL
,	@DeviceID							VARCHAR(20)				= NULL
,	@Serialno							Varchar(50)				= NULL
,	@UserName							varchar(30)				= NULL
,	@CollectionTime						varchar(30)				= NULL	
,	@CollectionTimeEnd					varchar(30)				= NULL				
,	@OrderByStrs						varchar(100)			= NULL
,	@GZ									varchar(500)			= NULL
,	@OrgId								varchar(2000)				= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT
AS
BEGIN
	
	DECLARE @STRSQL NVARCHAR(4000)
	
	IF @SearchDate=''''	SET		@SearchDate=NULL
	IF @SearchDateEnd ='''' SET   @SearchDateEnd = NULL
	IF @DeviceID =''''	SET		@DeviceID=NULL
	IF @Serialno=''''		SET		@Serialno=NULL
	IF @CollectionTime='''' SET @CollectionTime = NULL
	IF @OrderByStrs  = '''' SET @OrderByStrs = NULL
	IF @CollectionTimeEnd = '''' SET @CollectionTimeEnd = NULL
	IF @GZ = '''' SET @GZ = NULL
	IF @OrgId='''' SET @OrgId=NULL
	
	SET @STRSQL=NULL	

	set @STRSQL=''select a.moneyid,a.devname,a.devid,a.bankid,a.bankname
				,a.batchno,a.fdate,a.ftime,a.serialno,a.flowno
			    ,a.bzbh,a.facedirect,a.refusereason,a.outport,a.photo
			    ,a.fullphoto,a.me,(a.bz+a.bb) as MoneyBzBb from VIEW_''+@UserName+'' as a 
				where 1=1''


	IF @DeviceID IS NOT NULL 
		begin
			
			set @STRSQL=''select a.moneyid,a.devname,a.devid,a.bankid,a.bankname
		    ,a.batchno,a.fdate,a.ftime,a.serialno,a.flowno
			,a.bzbh,a.facedirect,a.refusereason,a.outport,a.photo
			,a.fullphoto,a.me,(a.bz+a.bb) as MoneyBzBb from vtable_''+@DeviceID+'' as a  where 1=1''
				
		end

	IF @OrgId IS NOT NULL  
		begin
			SET @STRSQL=@STRSQL+''	AND a.bankid in (''+@OrgId+'') ''
		End

	
	IF @SearchDate IS NOT NULL
		begin 
			 set @STRSQL=@STRSQL+N''  AND a.fdate>=''''''+@SearchDate+''''''''
		end
	IF @SearchDateEnd IS NOT NULL	
		begin
			
			  SET @STRSQL=@STRSQL+N''  AND a.fdate<=''''''+@SearchDateEnd+''''''''
		end
			
	IF @CollectionTime IS NOT NULL
		begin
			set @STRSQL=@STRSQL+'' and a.ftime >= ''''''+@CollectionTime+''''''''
		end
	IF @CollectionTimeEnd IS NOT NULL
		begin
			set @STRSQL=@STRSQL+'' and a.ftime <= ''''''+@CollectionTimeEnd+''''''''
		end

	declare @sqlls nvarchar(4000)

	set @sqlls=''select moneyid,serialno into ##LSReport from (''+@STRSQL+'') as bb ''

	exec (@sqlls)
	

	IF @Serialno IS NOT NULL 
		begin
		declare @serialnosum int
		set @serialnosum=0;
		IF 	@serialnosum=(select count(*) from ##LSReport where serialno like ''''+@Serialno+''%'''''')
		print ''tests''
		print @serialnosum
		
		IF @serialnosum=0
			begin

			declare @prestr varchar(10),@endstr varchar(10),@strlen int,@prilen int,@endlen int
			set @strlen=len(@Serialno);
			set @prilen=@strlen/2;
			set @endlen=@prilen;
			if @strlen%2!=0
				begin
					set @prilen=@prilen+1;
				end
			set @prestr=substring(@Serialno,1,@prilen);
			set @endstr=substring(@Serialno,@prilen+1,@endlen);
			SET @STRSQL=@STRSQL+N''	AND (a.serialno like N''''''+ISNULL(@prestr,'''')+''%''''
			or a.serialno like N''''''+ISNULL(@endstr,'''')+''%''''
			)''

			print ''a''
			end 
			
		else
			begin
				SET @STRSQL=@STRSQL+N''	AND a.serialno like N''''''+ISNULL(@Serialno,'''')+''%''''''
				print ''b''
			end
		print @prestr
		print @endstr
		end

					
	IF @GZ IS NOT NULL
		begin
			set @STRSQL=@STRSQL+'' and a.outport in (''+@GZ+'')''
		end	

		
print @STRSQL
	IF @PageIndex!=0 AND @PageSize!=0
		begin
			print @OrderByStrs
			IF @OrderByStrs IS NOT NULL
				begin
					EXEC dbo.PageSplit @STRSQL,@OrderByStrs,@PageIndex,@PageSize,@RecordCount OUTPUT
				end
			else
				begin
					EXEC dbo.PageSplit @STRSQL,''ftime desc'',@PageIndex,@PageSize,@RecordCount OUTPUT
				end
		end
	ELSE
		begin
			IF @OrderByStrs IS NOT NULL
				begin
					set @STRSQL=@STRSQL+'' order by ''+@OrderByStrs
				end
			else
				begin
					set @STRSQL=@STRSQL+'' order by fdate desc''
				end
			exec (@STRSQL)
		end

print @STRSQL
	drop table ##LSReport
	
END







































' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchCollectionTJ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SearchCollectionTJ]
	@SearchDate							Varchar(10)				= NULL
,	@SearchPara							Varchar(10)				= NULL
,	@UserName							varchar(30)				= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT
AS
BEGIN
	
	DECLARE @STRSQL NVARCHAR(4000)
	
	IF @SearchDate='''' or @SearchDate=''null''	SET		@SearchDate=NULL	
	IF @SearchPara='''' or @SearchPara=''null''	SET		@SearchPara=NULL
	
			
	set @STRSQL=''select fakes,devid,devname,count(*) as total from VIEW_''+@UserName+'' where 1=1 group by devid,devname,fakes''

		IF @SearchPara=''年''
			begin
				IF @SearchDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND datepart(year,fdate)=''+@SearchDate
			end
			ElSE IF @SearchPara=''月''
			begin
				IF @SearchDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND substring(fdate,0,8)=N''''''+CONVERT(VARCHAR,ISNULL(@SearchDate,''''))+''''''''
			end
			ELSE
			begin
				IF @SearchDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND fdate=N''''''+CONVERT(VARCHAR,ISNULL(@SearchDate,''''))+''''''''
			end

--	SET @STRSQL=''select a.devid,a.devname,count(*) as total,sum(case when a.fakes=0 then 1 else 0 end) as zbsl
--				,(count(*)-sum(case when a.fakes=0 then 1 else 0 end)) as jbsl from (''+@STRSQL
--				+'') as a group by a.devid,a.devname''

	IF @PageIndex!=0 AND @PageSize!=0

		begin
			EXEC dbo.PageSplit @STRSQL,'' devid '',@PageIndex,@PageSize,@RecordCount OUTPUT
		end
	ELSE
		begin
			exec (@STRSQL)
		end
	
	print @STRSQL
END













' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchRecvListPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		YangJun
-- Create date: 2012.3.22
-- Description:	查询错误故障信息列表分页
-- =============================================
CREATE PROCEDURE [dbo].[SearchRecvListPage]
	@StartDate			varchar(30)				= NULL
,	@EndDate			varchar(30)				= NULL
,	@PageIndex				INT						= NULL
,	@PageSize				INT						= NULL
,	@RecordCount			INT						= NULL	OUTPUT
AS
BEGIN
	declare @sql nvarchar(max)
	set @sql='' select a.ID,a.fdatetime,a.recvtext from RecvList as a where 1=1''

	IF @StartDate = '''' SET @StartDate = NULL
	IF @EndDate = '''' SET @EndDate = NULL

	IF @StartDate IS NOT NULL
		begin
			set @sql=@sql+'' and a.fdatetime >=''''''+@StartDate+''''''''
		end
	IF @EndDate IS NOT NULL
		begin
			set @sql=@sql+'' and a.fdatetime <=''''''+@EndDate+''''''''
		end
	IF @PageIndex=0 and @PageSize=0
		begin
			exec(@sql)
		end
	ELSE
		begin
			EXEC dbo.PageSplit @sql,'' ID '',@PageIndex,@PageSize,@RecordCount OUTPUT
		end
	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchGuiZePageList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		YangJun
-- Create date: 2012.3.10
-- Description:	查询出钞口查询规则列表分页
-- =============================================
CREATE PROCEDURE [dbo].[SearchGuiZePageList]
	@GZName			varchar(20)					= NULL
,	@PageIndex		INT							= NULL
,	@PageSize		INT							= NULL
,	@RecordCount	INT							= NULL	OUTPUT
AS
BEGIN
	declare @sql nvarchar(4000)
	set @sql='' select a.id,a.code,a.name,a.portname,a.ischeck from portSearchGuiZeList 
				as a where 1=1 ''
	IF @GZName = '''' set @GZName = NULL
	IF @GZName IS NOT NULL
		begin
			set @sql=@sql+'' and a.name like ''''%''+@GZName+''%''''''
		end
	EXEC dbo.PageSplit @sql,'' id '',@PageIndex,@PageSize,@RecordCount OUTPUT
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchConfigList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		YangJun
-- Create date: 2012.3.2
-- Description:	查询配置列表分页
-- =============================================
CREATE PROCEDURE [dbo].[SearchConfigList]
	@ConfigValue			varchar(20)				= NULL
,	@UserName				varchar(20)				= NULL
,	@PageIndex				INT						= NULL
,	@PageSize				INT						= NULL
,	@RecordCount			INT						= NULL	OUTPUT
AS
BEGIN
	declare @sql nvarchar(4000),@ViewTable varchar(50)
	IF @ConfigValue = '''' set @ConfigValue = NULL
	set @ViewTable=(''VIEW_''+@UserName)
	set @sql='' select a.groupname,a.[keys],a.[values]
				,(select count(*) from ''+@ViewTable+'' where facedirect=a.[values]) as cs
				 from KeyList as a where 1=1 ''
	
	IF @ConfigValue IS NOT NULL
		begin
			set @sql=@sql+'' and a.[values] like ''''%''+@ConfigValue+''''''''
		end

	EXEC dbo.PageSplit @sql,'' groupname '',@PageIndex,@PageSize,@RecordCount OUTPUT
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchMoneyStandPageList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		YangJun
-- Create date: 2012.3.1
-- Description:	纸币类别列表分页查询
-- =============================================
CREATE PROCEDURE [dbo].[SearchMoneyStandPageList]
	@BZ									varchar(20)				= NULL
,	@DW									varchar(20)				= NULL
,	@MZ									varchar(20)				= NULL
,	@UserName							varchar(20)				= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT
AS
BEGIN
	declare @sql nvarchar(4000),@ViewTable varchar(50)
	set @ViewTable=(''VIEW_''+@UserName)
	IF @BZ = '''' set @BZ = NULL
	IF @DW = '''' set @DW = NULL
	IF @MZ = '''' set @MZ = NULL

	set @sql='' select a.bzbh,a.bz,a.bb,a.me,a.dw,a.fxdw,a.CreateDate
				,(select count(*) from ''+@ViewTable+'' where bzbh=a.bzbh) as cs
				 from 
				StandMoneyList as a where 1=1 ''

	IF @BZ IS NOT NULL
		begin
			set @sql=@sql+'' and a.bz like ''''%''+@BZ+''%''''''
		end
	IF @DW IS NOT NULL
		begin
			set @sql=@sql+'' and a.dw like ''''%''+@DW+''%''''''
		end

	IF @MZ IS NOT NULL
		begin
			set @sql=@sql+'' and a.me=''''''+@MZ+''''''''
		end
	IF @PageIndex=0 and @PageSize=0
		begin
			exec(@sql)
		end
	else
		begin
			EXEC dbo.PageSplit @sql,'' bzbh '',@PageIndex,@PageSize,@RecordCount OUTPUT
		end
	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchOrganizationList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[SearchOrganizationList]
	@OrgId							varchar(1000)				= NULL
,	@OrgName						Varchar(50)					= NULL
,	@PageIndex						INT							= NULL
,	@PageSize						INT							= NULL
,	@RecordCount					INT							= NULL	OUTPUT
AS
BEGIN
	
	DECLARE @STRSQL NVARCHAR(4000)
	IF @OrgName=''''     SET     @OrgName=NULL
	IF @OrgId='''' set @OrgId=NULL

	SET @STRSQL=N'' select a.OrgId,a.OrgName,a.Address,a.CreateUserId,a.CreateDate
				,(select count(*) from DeviceList where OrgId=a.OrgId and del=0 ) as count,a.ParentId	
				,(select OrgName from OrganizationList where OrgId=a.ParentId) as PName	
				,(select count(*) from OrganizationList where ParentId=a.OrgId) as pcount
			 from OrganizationList as a
			where 1=1 ''
	print @STRSQL
	IF @OrgName is not null
		begin
			set @STRSQL=@STRSQL+'' and a.OrgName like ''''%''+@OrgName+''%''''''
		end
  print @STRSQL
	print @OrgId
	IF @OrgId IS NOT NULL
		begin
			set @STRSQL=@STRSQL+'' and (a.OrgId in (''+@OrgId+'') or ParentId in (''+@OrgId+''))''
		end
	
	print @STRSQL
	IF @PageIndex=0 and @PageSize=0
		begin
			exec(@STRSQL)
		end
	else
		begin
			EXEC dbo.PageSplit @STRSQL,'' CreateDate desc '',@PageIndex,@PageSize,@RecordCount OUTPUT
		end
	
	
END











' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchProgramListPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[SearchProgramListPage]
	@ProgramParentName				Varchar(30)					= NULL
,	@ProgramName					Varchar(30)					= NULL
,	@PageIndex						INT							= NULL
,	@PageSize						INT							= NULL
,	@RecordCount					INT							= NULL	OUTPUT
AS
BEGIN
	
	DECLARE @STRSQL NVARCHAR(4000)
	
	IF @ProgramParentName=''''	SET		@ProgramParentName=NULL
	IF @ProgramName =''''			SET		@ProgramName=NULL

	SET @STRSQL=N''
         select * from (SELECT a.programID,a.programName,a.parentProgramID,
		(select programName from dbo.ProgramList where programID=a.parentProgramID) as parentName,
		(select count(*) from dbo.RoleProgramList where programID=a.programID) as isdel
		 from dbo.ProgramList a
		 WHERE 1=1 and a.parentProgramID!=0 ) as b where 1=1''

	 IF @ProgramParentName IS NOT NULL SET @STRSQL=@STRSQL+N''	AND b.parentName like N''''%''+ISNULL(@ProgramParentName,'''')+''%''''''
	 IF @ProgramName IS NOT NULL SET @STRSQL=@STRSQL+N''  AND b.programName like N''''%''+ISNULL(@ProgramName,'''')+''%''''''

	EXEC dbo.PageSplit @STRSQL,'' parentProgramID '',@PageIndex,@PageSize,@RecordCount OUTPUT
	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchLogsPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[SearchLogsPage]
	@UserName							Varchar(20)				= NULL
,	@StartDate							Varchar(30)				= NULL
,	@EndDate							Varchar(30)				= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT	
AS
BEGIN 
	DECLARE @STRSQL NVARCHAR(4000)
	IF @UserName=''''     SET     @UserName=NULL
	IF @StartDate=''''	SET		@StartDate=NULL
	IF @EndDate =''''		SET		@EndDate=NULL

	SET @STRSQL=N''select * from dbo.LogsList
				   WHERE 1=1 ''
	 IF @UserName IS NOT NULL SET @STRSQL=@STRSQL+N''	AND logID like N''''%''+ISNULL(@UserName,'''')+''%''''''
	 IF @StartDate IS NOT NULL AND @EndDate IS NOT NULL
		BEGIN
			SET @STRSQL=@STRSQL+N''  AND logsTime >= N''''''+CONVERT(VARCHAR,ISNULL(@StartDate,''''))+'''''' and logsTime <= N''''''+CONVERT(VARCHAR,ISNULL(dateadd(d,1,@EndDate),''''))+''''''''
		END
	ELSE
		BEGIN
			IF @StartDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND logsTime>=N''''''+CONVERT(VARCHAR,ISNULL(@StartDate,''''))+''''''''
			IF @EndDate IS NOT NULL SET @STRSQL=@STRSQL+N''  AND logsTime<=N''''''+CONVERT(VARCHAR,ISNULL(dateadd(d,1,@EndDate),''''))+''''''''
		END
	EXEC dbo.PageSplit @STRSQL,'' logsTime desc '',@PageIndex,@PageSize,@RecordCount OUTPUT

END











' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchUserList1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[SearchUserList1]
	@RoleID							INT							= NULL
,	@LogID							VARCHAR(100)				= NULL
,	@LogName						Varchar(100)				= NULL
,	@OrgId							varchar(2000)				= NULL
,	@PageIndex						INT							= NULL
,	@PageSize						INT							= NULL
,	@RecordCount					INT							= NULL	OUTPUT
AS
BEGIN
	
	DECLARE @STRSQL NVARCHAR(4000)
	
	IF @RoleID=''''	SET		@RoleID=NULL
	IF @LogID =''''	SET		@LogID=NULL
	IF @LogName=''''	SET		@LogName=NULL
	IF @OrgId = '''' SET @OrgId = NULL

	SET @STRSQL=N''
        SELECT a.logID,a.password,a.logname,a.level,a.roleID
		,(select roleName from RoleList where roleID=a.roleID) as roleName
		,a.email,a.phone,a.birthday,a.isCheck,a.OrgId
		,(select OrgName from OrganizationList where OrgId=a.OrgId) as OrgName
		 from UserList a
		 WHERE 1=1 and a.isCheck=1''
	 IF @OrgId IS NOT NULL SET @STRSQL=@STRSQL+N''  AND a.OrgId in (''+@OrgId+'') ''
	 IF @RoleID IS NOT NULL SET @STRSQL=@STRSQL+N''  AND a.roleID=N''''''+CONVERT(VARCHAR,ISNULL(@RoleID,''''))+''''''''
	 IF @LogID IS NOT NULL SET @STRSQL=@STRSQL+N''	AND a.logID like N''''%''+ISNULL(@LogID,'''')+''%''''''
	 IF @LogName IS NOT NULL SET @STRSQL=@STRSQL+N''  AND a.logname like N''''%''+ISNULL(@LogName,'''')+''%''''''

	EXEC dbo.PageSplit @STRSQL,'' logID '',@PageIndex,@PageSize,@RecordCount OUTPUT
	
END




' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchUserRoleList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[SearchUserRoleList]
	@LogID							VARCHAR(100)				= NULL
,	@PageIndex						INT							= NULL
,	@PageSize						INT							= NULL
,	@RecordCount					INT							= NULL	OUTPUT
AS
BEGIN
	
	DECLARE @STRSQL NVARCHAR(4000)
	
	IF @LogID =''''	SET		@LogID=NULL

	SET @STRSQL=N''
        select a.roleid,a.ischeck,a.rolename
		,(select count(*) from UserList b where b.roleID=a.roleid and b.isCheck=1) as rolecount
		,(select count(*) from dbo.RoleProgramList c where c.roleID=a.roleid ) as programcount
		from  RoleList a
		 WHERE 1=1 and a.isCheck=1''

	EXEC dbo.PageSplit @STRSQL,'' roleid '',@PageIndex,@PageSize,@RecordCount OUTPUT
	
END






' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchDeviceList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[SearchDeviceList]
	@DeviceID						Varchar(20)					= NULL
,	@DeviceName						Varchar(30)					= NULL
,	@CreateTime						varchar(30)					= NULL
,	@OrgId							varchar(2000)				= NULL
,	@PageIndex						INT							= NULL
,	@PageSize						INT							= NULL
,	@RecordCount					INT							= NULL	OUTPUT
AS
BEGIN
	
	DECLARE @STRSQL NVARCHAR(4000)
	IF @DeviceID=''''     SET     @DeviceID=NULL
	IF @DeviceName=''''	SET		@DeviceName=NULL
	IF @CreateTime =''''	SET		@CreateTime=NULL
	IF @OrgId = '''' SET @OrgId = NULL

	SET @STRSQL=N''
				   SELECT a.DEVID,a.DEVNAME,a.FIRMWARE_VERSION,a.SOFTWARE_VERSION,a.PHOTOWARE_VERSION
		           ,a.DEV_STATE,a.MOUDEL_NUM,a.COMM_TYPE,a.COMM_STRING,a.UPDATETIME,a.CHECKDATE,a.LISTENPORT
					,a.OrgId,(select OrgName from OrganizationList where OrgId=a.OrgId ) as OrgName
					,(case when a.dev_state=1 then ''''正常'''' else ''''故障'''' end) as StateName,a.ReportCount
					,a.devtype
					,a.devmodel
					,b.name as devmodelname
					,b.type
					,(select name from DeviceTypeList where code=b.type) as devtypename
					,a.ipaddress,a.WL__version,a.CH_version
		           FROM DeviceList as a
				   left join DeviceModelList as b on (a.devmodel=b.id)
				   WHERE 1=1 and del=0 ''
	 IF @OrgId IS NOT NULL SET @STRSQL=@STRSQL+N''	AND a.OrgId in (''+@OrgId+'')''
	 IF @DeviceID IS NOT NULL SET @STRSQL=@STRSQL+N''	AND a.DEVID like N''''%''+ISNULL(@DeviceID,'''')+''%''''''
	 IF @DeviceName IS NOT NULL SET @STRSQL=@STRSQL+N''	AND a.DEVNAME like N''''%''+ISNULL(@DeviceName,'''')+''%''''''
	 IF @CreateTime IS NOT NULL SET @STRSQL=@STRSQL+N''  AND a.UPDATETIME>=N''''''+CONVERT(VARCHAR,ISNULL(@CreateTime,''''))+''''''''

	IF @PageIndex=0 and @PageSize=0
		begin
			exec(@STRSQL)
		end
	else
		begin
			EXEC dbo.PageSplit @STRSQL,'' UPDATETIME desc '',@PageIndex,@PageSize,@RecordCount OUTPUT
		end
	
	
END











' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDataTJ1]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[GetDataTJ1] 
	@DeviceID		Varchar(30)			= NULL
,	@BatchNo		Varchar(20)			= NULL
,	@StartDate		Varchar(20)			= NULL
,	@EndDate		Varchar(20)			= NULL
,	@UserName		varchar(20)			= NULL
,	@PageIndex						INT							= NULL
,	@PageSize						INT							= NULL
,	@RecordCount					INT							= NULL	OUTPUT

	
AS
BEGIN
	IF @DeviceID ='''' SET @DeviceID = NULL
	IF @BatchNo ='''' SEt @BatchNo = NULL
	IF @StartDate='''' SET @StartDate=NULL
	IF @EndDate='''' SET @EndDate = NULL	

	declare @sql4 nvarchar(4000)
	set @sql4=''''

		SET @sql4=''SELECT * FROM dbo.VIEW_''+@UserName +'' where 1=1 ''

	 IF @DeviceID IS NOT NULL SET @sql4=@sql4+N''  AND devid=N''''''+CONVERT(VARCHAR,ISNULL(@DeviceID,''''))+''''''''
	IF @BatchNo IS NOT NULL SET @sql4=@sql4+N''  AND batchno=N''''''+CONVERT(VARCHAR,ISNULL(@BatchNo,''''))+''''''''	
	IF @StartDate IS NOT NULL SET @sql4=@sql4+N''  AND fdate>=N''''''+CONVERT(VARCHAR,ISNULL(@StartDate,''''))+''''''''	
	IF @EndDate IS NOT NULL SET @sql4=@sql4+N''  AND fdate<=N''''''+CONVERT(VARCHAR,ISNULL(@EndDate,''''))+''''''''	

	set @sql4='' select a.devid,a.devname,count(*) as total,sum(case when a.serialno like ''''%?%'''' or 
				a.serialno like ''''%#%'''' or a.serialno like ''''%*%'''' then 1 else 0 end) as bnsbs
				, sum(case when a.refusereason='''' then 0 else 1 end) as tcs from (''
					+  @sql4 + '' ) as a group by a.devid,a.devname''

	print @sql4
	IF @PageIndex=0 and @PageSize=0
		begin
			exec (@sql4)
		end
	else
		begin
			EXEC dbo.PageSplit @sql4,'' devid '',@PageIndex,@PageSize,@RecordCount OUTPUT
		end
	
END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchRefuseReasonPage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		YangJun
-- Create date: 2012.3.5
-- Description:	查询退钞原因分页列表
-- =============================================
CREATE PROCEDURE [dbo].[SearchRefuseReasonPage]
	@ErrorMsg			varchar(20)					= NULL
,	@UserName			varchar(20)					= NULL
,	@PageIndex			INT							= NULL
,	@PageSize			INT							= NULL
,	@RecordCount		INT							= NULL	OUTPUT
AS
BEGIN
	declare @sql nvarchar(4000),@ViewTable varchar(50)
	IF @ErrorMsg='''' set @ErrorMsg = NULL
	IF @UserName = '''' set @UserName = NULL
	IF @UserName IS NOT NULL
		begin
			set @ViewTable=(''VIEW_''+@UserName)
			set @sql='' select a.errno,a.errmsg
						,(select count(*) from ''+@ViewTable+'' where refusereason=a.errmsg) as cs
						from RefuseReason as a where 1=1 ''
			
			IF @ErrorMsg IS NOT NULL
				begin
					set @sql=@sql+'' and a.errmsg like ''''%''+@ErrorMsg+''%''''''
				end
			
			IF @PageIndex=0 and @PageSize=0
				begin 
					exec(@sql)
				end
			else
				begin
					EXEC dbo.PageSplit @sql,''errno'',@PageIndex,@PageSize,@RecordCount OUTPUT
				end
			
		end
	

	
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchRefuseReasonTJ]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[SearchRefuseReasonTJ]
	@DeviceID							Varchar(20)				= NULL
,	@StartDate							Varchar(20)				= NULL
,	@EndDate							Varchar(20)				= NULL
,	@UserName							Varchar(30)				= NULL
,	@OrgId								varchar(2000)			= NULL
,	@Mes								varchar(500)			= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT
AS
BEGIN
	
	DECLARE @STRSQL NVARCHAR(4000)
	
	IF @DeviceID=''''		SET		@DeviceID=NULL	
	IF @StartDate=''''	SET		@StartDate=NULL
	IF @EndDate=''''		SET		@EndDate=NULL
	IF @OrgId=''''        SET		@OrgId= NULL
	IF @Mes	='''' set @Mes = NULL

	set @STRSQL=''select  * from VIEW_''+@UserName+'' where 1=1''	
print @STRSQL

	 IF @DeviceID IS NOT NULL 
		begin
			SET @STRSQL=@STRSQL+N''  AND devid=N''''''+CONVERT(VARCHAR,ISNULL(@DeviceID,''''))+''''''''
		end
		

	IF @StartDate IS NOT NULL 
		begin
			SET @STRSQL=@STRSQL+N''  AND fdate>=N''''''+CONVERT(VARCHAR,ISNULL(@StartDate,''''))+''''''''
		end

	IF @EndDate IS NOT NULL 
		begin
			SET @STRSQL=@STRSQL+N''  AND fdate<=N''''''+CONVERT(VARCHAR,ISNULL(@EndDate,''''))+''''''''
		end
		

	IF @OrgId IS NOT NULL

		begin
			SET @STRSQL=@STRSQL+N''  AND bankid in (''+@OrgId+'') ''
		end

	IF @Mes is not null
		begin
			set @STRSQL=@STRSQL+'' and me in (''+@Mes+'')''
		end

	print 	@STRSQL

	declare @zs int,@sql varchar(2000)
	set @sql=''(select count(*) from (''+@STRSQL+'') as aa where aa.refusereason is not null and aa.refusereason!='''''''')''
	
	set @STRSQL=''(select  a.refusereason
				,Convert(varchar,Convert(numeric(9,2),(Convert(numeric(18,0),count(*))/Convert(numeric(18, 0),(select count(*) from (''+@STRSQL+'') as aa where aa.refusereason is not null and aa.refusereason!='''''''')))*100))+''''%'''' as bl
				,count(*) as total from ('' +@STRSQL
				+ '')as a left join dbo.RefuseReason b on (a.refusereason=b.errmsg)''+
				''group by a.refusereason having a.refusereason IS NOT NULL and a.refusereason!='''''''')
				
			 ''
print @STRSQL
--UNION ALL 
--				(select ''''合计'''' as refusereason,NULL as bl,''+@sql+'' as total)
print @STRSQL
	IF @PageIndex!=0 AND @PageSize!=0
		begin
			EXEC dbo.PageSplit @STRSQL,''total desc'',@PageIndex,@PageSize,@RecordCount OUTPUT
		end
	ELSE
		begin
			set @STRSQL=@STRSQL+'' order by total desc''
			exec (@STRSQL)
		end	
END




















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOrgDeviceTJTU]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		YangJun
-- Create date: 2012.5.7
-- Description:	网点设备统计图
-- =============================================
CREATE PROCEDURE [dbo].[GetOrgDeviceTJTU]
	@StartDate							varchar(30)				= NULL
,	@EndDate							varchar(30)				= NULL
,	@UserName							varchar(30)				= NULL
,	@OrgId								varchar(1000)			= NULL
,	@DeviceId							varchar(50)				= NULL
,	@PageIndex						    INT						= NULL
,	@PageSize							INT						= NULL
,	@RecordCount						INT						= NULL	OUTPUT
AS
BEGIN
	IF @StartDate = '''' set @StartDate = NULL
	IF @EndDate = '''' set @EndDate = NULL
	IF @OrgId = '''' set @OrgId = NULL
	IF @DeviceId = '''' set @DeviceId = NULL
	declare @sql nvarchar(4000),@ViewName varchar(50)
	set @ViewName = NULL
	set @ViewName=''VIEW_''+@UserName;
	print @VIewName
	
			print @VIewName
--			set @sql='' select bz,devid,devname,Convert(numeric(18, 0),sum(Convert(INT,me)))/10000 as total
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=100 then 100 else 0 end))/10000 as ybtotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=50 then 50 else 0 end))/10000 as wstotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=20 then 20 else 0 end))/10000 as estotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=10 then 10 else 0 end))/10000 as ystotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=5 then 5 else 0 end))/10000 as wktotal
--				,Convert(numeric(18, 0),sum(case when Convert(INT,me)=1 then 1 else 0 end))/10000 as yktotal
--				from (select * from ''+@ViewName +'' where 1=1 and outport like ''''%出钞口%''''''

			set @sql=''select devid,sum(total) as totals,devname into ##DevTJ from 
(
	select devid,devname,Convert(numeric(18, 0),count(distinct serialno))*me/10000 as total,me
from (select me,serialno,devid,devname,bankid from ''+@ViewName +'' where 1=1  
and bankid is not null and outport like ''''%出钞口%''''''


			IF @DeviceId IS NOT NULL
				begin
					set @sql=''select devid,sum(total) as totals,devname into ##DevTJ from 
(
	select devid,devname,Convert(numeric(18, 0),count(distinct serialno))*me/10000 as total,me
from (select me,serialno,devid,devname,bankid from vtable_''+@DeviceId +'' where 1=1  
and bankid is not null and outport like ''''%出钞口%''''''
					---set @sql=@sql+'' and devid=''''''+@DeviceId+''''''''
				end
		
			IF @StartDate IS NOT NULL
			begin
				set @sql=@sql+'' and fdate >=''''''+@StartDate + ''''''''
			end	
			IF @EndDate IS NOT NULL
				begin
					set @sql=@sql+'' and fdate <=''''''+@EndDate + ''''''''
				end
			IF @OrgId Is NOT NULL
				begin
					set @sql=@sql+'' and bankid in (''+@OrgId+'')''
				end

			

			--set @sql=@sql+'' )  as aa group by devid,devname,bz having bz is not null and devid is not null''

			set @sql=@sql+''  ) as aa  group by devid,devname,me
					having me in(1,10,20,50,100)
					) as cc group by devid,devname''

			print @sql

			exec(@sql)

			declare @sql1 nvarchar(4000)
			set @sql1='' select devid,totals as total,devname from ##DevTJ''
			IF @PageIndex=0 and @PageSize=0
				begin
					set @sql=@sql1+'' order by total desc''
					exec(@sql)
				end
			ELSE
				begin
					EXEC dbo.PageSplit @sql1,'' total desc '',@PageIndex,@PageSize,@RecordCount OUTPUT
				end

		

	drop table ##DevTJ

	
END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchDeviceTypeList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		YangJun
-- Create date: 2012-7-3
-- Description:	查询设备类型列表
-- =============================================
CREATE PROCEDURE [dbo].[SearchDeviceTypeList]
	@TypeName				varchar(50)					= NULL
,	@PageIndex				INT							= NULL
,	@PageSize				INT							= NULL
,	@RecordCount			INT							= NULL	OUTPUT
AS
BEGIN
	IF @TypeName = '''' set @TypeName = null
	declare @sql nvarchar(4000)
	set @sql='' select code,name,ischeck,createdate,SaveDate
				,(select count(*) from DeviceList where devtype=code) as isdel
				 from devicetypelist where 1=1 ''

	if @TypeName is not null
		begin
			set @sql=@sql+'' and name like ''''%''+@TypeName+''%''''''
		end

	EXEC dbo.PageSplit @sql,'' createdate desc '',@PageIndex,@PageSize,@RecordCount OUTPUT
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchSerialNoList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





-- =============================================
-- Author:		YangJun
-- Create date: 2012-7-17
-- Description:	冠字号查询
-- =============================================
CREATE PROCEDURE [dbo].[SearchSerialNoList]
	@fdatestar			varchar(30)					= null
,	@fdateend			varchar(30)					= null
,	@orgid				varchar(1000)				= null
,	@deviceid			varchar(30)					= null
,	@ftimestar			varchar(30)					= null
,	@ftimeend			varchar(30)					= null
,	@serialno			varchar(30)					= null
,	@portgz				varchar(500)				= null
,	@orderbystrs		varchar(100)				= NULL
,	@PageIndex			INT							= NULL
,	@PageSize			INT							= NULL
,	@RecordCount		INT							= NULL	OUTPUT
,	@msg				varchar(100)				= null  output
AS
BEGIN
	declare @sql nvarchar(4000)

	if @fdatestar = '''' set @fdatestar=null
	if @fdateend='''' set @fdateend=null
	if @orgid ='''' set @orgid = null
	if @deviceid='''' set @deviceid=null
	if @ftimestar='''' set @ftimestar=null
	if @ftimeend='''' set @ftimeend=null
	if @serialno='''' set @serialno=null
	if @portgz='''' set @portgz=null
	if @orderbystrs='''' set @orderbystrs=null

	declare @tablename nvarchar(100),@devicecode varchar(100)

	create table #moneydata   ---创建临时表
	(
		[moneyid] [uniqueidentifier] NOT NULL,
		[bankid] [varchar](100)  NULL,
		[bankname] [varchar](100)  NULL,
		[devid] [varchar](20)  NULL,
		[devname] [varchar](30)  NULL,
		[fdate] [varchar](10)  NULL,
		[ftime] [varchar](10)  NULL,
		[flowno] [int] NULL,
		[batchno] [varchar](30)  NULL,
		[serialno] [varchar](30)  NULL,
		[photo] [image] NULL,
		[fullphoto] [image] NULL,
		[bzbh] [varchar](5)   NULL,
		[facedirect] [varchar](50)   NULL,
		[refusereason] [varchar](100)   NULL,
		[outport] [varchar](50)   NULL,
		[MoneyBzBb] [varchar](100) null,
		[me][varchar](30) null,
		[tablename][varchar](500) null
	)
	set @msg='''';
	begin try
	if @orgid is null
		begin
			set @msg=''网点为空'';
		end    ----orgid is null end
	else
		begin
			if @deviceid is null and @serialno is null
				begin
					set @msg=''必选一项'';
				end
			else
				begin
					declare @fewsql nvarchar(4000),@orgsql nvarchar(4000);
					set @fewsql=null;
					set @orgsql=''select deviceid,devicename,orgid,fdatestart,fdateend,tablename into ##DevTables from 
								DeviceLogRecordList where orgid in (''+@orgid+'')''
					
					if @fdatestar is not null
						begin
							set @orgsql=@orgsql+'' and fdatestart>=''''''+@fdatestar+''''''''
						end
					if @fdateend is not null
						begin
							set @orgsql=@orgsql+'' and fdatestart<=''''''+@fdateend+''''''''
						end
					print @orgsql
					exec (@orgsql)  --生成临时表##DevTables

		
					declare mytables cursor for select tablename,deviceid from ##DevTables 
					
					open mytables  --打开游标
					fetch next from mytables into @tablename,@devicecode  --指针
					while @@fetch_status=0
						begin
							set @fewsql=null;
							if @deviceid is null
								begin
									set @fewsql=''select a.moneyid,a.bankid,a.bankname,a.devid,a.devname
										,a.batchno,a.fdate,a.ftime,a.serialno,a.flowno,a.bzbh,a.facedirect
										,a.refusereason,a.outport,a.photo,a.fullphoto,b.me,(b.bz+b.bb) as MoneyBzBb from ''+@tablename
										+'' as a left join StandMoneyList as b on (a.bzbh=b.bzbh) where 1=1 '';
								end   ----deviceid is null end
							else
								begin
									if @deviceid=@devicecode
										begin
											set @fewsql=''select a.moneyid,a.bankid,a.bankname,a.devid,a.devname
											,a.batchno,a.fdate,a.ftime,a.serialno,a.flowno,a.bzbh,a.facedirect
											,a.refusereason,a.outport,a.photo,a.fullphoto,b.me,(b.bz+b.bb) as MoneyBzBb from ''+@tablename
											+'' as a left join StandMoneyList as b on (a.bzbh=b.bzbh) where 1=1 '';
										end  ----deviceid=@devicecode end
								end	 --- deviceid is not null end
								
							if @fewsql is not null
								begin
									print ''111''
									print @serialno
									--print @fewsql
									if @fdatestar is not null
										begin
											set @fewsql=@fewsql+'' and a.fdate >=''''''+@fdatestar+''''''''
										end
									if @fdateend is not null
										begin
											set @fewsql=@fewsql+'' and a.fdate<=''''''+@fdateend+''''''''
										end
									if @ftimestar is not null
										begin
											set @fewsql=@fewsql+'' and ftime >=''''''+@ftimestar+''''''''
										end
									if @ftimeend is not null
										begin
											set @fewsql=@fewsql+'' and ftime <=''''''+@ftimestar+'''''''' 
										end
									print ''aaa''
									if @serialno is not null
										begin
											print ''@serialno''
											set @fewsql=@fewsql+'' and serialno like''''''+@serialno+''%'''''' 
											print @fewsql
										end
									if @portgz is not null
										begin
											set @fewsql=@fewsql+'' and outport in (''+@portgz+'')''
										end
									
									

									set @fewsql=''insert into #moneydata select moneyid,bankid,bankname
												,devid,devname,fdate,ftime,flowno,batchno,serialno
												,photo,fullphoto,bzbh,facedirect,refusereason,outport,MoneyBzBb,me,''''''+@tablename+'''''' as tablename from (''+@fewsql+'') as aa'' 
									
									print @fewsql

									exec (@fewsql)

									
									
									--select * from #moneydata

								end  ----@fewsql is not null

								fetch next from mytables into @tablename,@devicecode
						end  ---
					
					close mytables  --关闭游标
					deallocate mytables  ---销毁游标
					drop table ##DevTables
				end
			
			
		
		
		set @sql=''select a.moneyid,a.bankid,a.bankname,a.devid,a.devname
				,a.batchno,a.fdate,a.ftime,a.serialno,a.flowno,a.bzbh,a.facedirect
				,a.refusereason,a.outport,a.photo,a.fullphoto,a.me,a.MoneyBzBb,tablename from #moneydata as a'';
		
		if @orderbystrs is not null
			begin
				EXEC dbo.PageSplit @sql,@orderbystrs,@PageIndex,@PageSize,@RecordCount OUTPUT
			end
		else
			begin
				EXEC dbo.PageSplit @sql,''ftime desc'',@PageIndex,@PageSize,@RecordCount OUTPUT
				--select @RecordCount as [@RecordCount]
			end
		

		
	end   ---orgid is not null end
	end try
	begin catch
		drop table ##DevTables
	end catch
END










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CreateMoneyTable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



















CREATE PROCEDURE [dbo].[CreateMoneyTable]
	(
		@DeviceId varchar(20)
,		@DeviceName varchar(100)
,		@OrgId		varchar(50)
	)
AS
	/* SET NOCOUNT ON */
	DECLARE @tablename varchar(100);
	DECLARE @sql varchar(4000);
	DECLARE @indexname varchar(100);
	DECLARE @viewname varchar(20);

	SET @tablename=''Money_''+@DeviceId;
	SET @indexname=''PK_MONEY_''+@DeviceId;

	IF OBJECT_ID(@tablename,''U'') IS NULL
	BEGIN
		/*创建终端数据表*/
		SET @sql=''CREATE TABLE [''+@tablename+''](
	[moneyid] [uniqueidentifier] NOT NULL,
	[bankid] [varchar](100) NULL,
	[bankname] [varchar](100) NULL,
	[fdate] [varchar](10) NULL,
	[ftime] [varchar](10) NULL,
	[flowno] [int] NULL,
	[batchno] [varchar](30) NULL,
	[serialno] [varchar](30) NULL,
	[price] [varchar](10) NULL,
	[kindno] [varchar](5) NULL,
	[fakes] [bit] NULL,
	[photo] [image] NULL,
	[fullphoto] [image] NULL,
	[photoname] [varchar](300) NULL,
	[devid] [varchar](20) NULL,
	[devname] [varchar](30) NULL,
	[recognitioninfo] [varchar](50) NULL,
	[mrecognitioninfo] [varchar](100) NULL,
	[bzbh] [varchar](5) NULL,
	[photowidth] [int] NULL,
	[photoheight] [int] NULL,
	[facedirect][varchar](50) NULL,
	[refusereason][varchar](100) NULL,
	[outport][varchar](50) NULL,
	[JobNum] [varchar](20) NULL,
[remark] [int] NULL CONSTRAINT [DF_MoenyList_FqYj''+@tablename+'']  DEFAULT (datepart(month,getdate())%(4))

) ON [MoneyListScheme] (remark) 


CREATE CLUSTERED INDEX [bankid/fdate/ftime]  ON ''+@tablename+''
(
	[bankid] ASC,
	[fdate] ASC,
	[ftime] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]


CREATE NONCLUSTERED INDEX [bankid/fdate/serialno]  ON ''+@tablename+''
(
	[bankid] ASC,
	[fdate] ASC,
	[serialno] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]



CREATE NONCLUSTERED INDEX [bankid/fdate] ON ''+@tablename+''
(
	[bankid] ASC,
	[fdate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [bankid/devid] ON ''+@tablename+''
(
	[bankid] ASC,
	[devid] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [bankid/fdate/ftime/serialno/devid/outport] ON ''+@tablename+''
(
	[bankid] ASC,
	[fdate] ASC,
	[ftime] ASC,
	[serialno] ASC,
	[devid] ASC,
	[outport] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [bankid/ftime] ON ''+@tablename+''
(
	[bankid] ASC,
	[ftime] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [bankid/outport] ON ''+@tablename+''
(
	[bankid] ASC,
	[outport] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [bankid/serialno] ON ''+@tablename+''
(
	[bankid] ASC,
	[serialno] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]  


''
	print @sql
		EXEC(@sql);

		--EXEC CreateTableView @DeviceId,@DeviceName,@OrgId;
		EXEC MoveMoney_LSData @deviceid,@DeviceName,@OrgId;

	END


	RETURN

























' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CreateTableView]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'







CREATE PROCEDURE [dbo].[CreateTableView]
	(
	@deviceid varchar(30)
,	@DeviceName	varchar(100)
,	@OrgId		varchar(50)
	)
AS
	/* 创建可视别信息图,类型为01 */
	DECLARE @sql varchar(1000);
	SET @sql=''create view vtable_''+@deviceid+'' as select  list.moneyid, b.OrgId as bankid, c.OrgName as bankname, list.fdate, list.ftime, list.serialno, list.price, list.kindno, list.fakes, b.devid, 
                list.devname, list.recognitioninfo, list.bzbh, list.photowidth, list.photoheight, stand.bz, stand.me, stand.dw,list.flowno,list.batchno,list.outport,list.facedirect,list.refusereason,list.mrecognitioninfo,
                stand.fxdw,stand.bb,list.photo,list.fullphoto,list.photoname,list.JobNum
 from money_''+@deviceid+'' list left join StandMoneyList stand on list.bzbh=stand.bzbh 
 left join DeviceList as b on (list.devid=b.devid) left join OrganizationList as c on (b.OrgId=c.OrgId)''
	print @sql
	EXEC(@sql)

	EXEC MoveMoney_LSData @deviceid,@DeviceName,@OrgId
	RETURN















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClearALL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ClearALL]
	@Type		varchar(20)			= NULL
AS
BEGIN
	begin tran
		IF @Type=''ALL''
			begin
				EXEC ClearData
				EXEC DeleteDeviceZUOYE
				
			end
		ELSE IF @Type=''Device''
			begin
				EXEC DeleteDeviceZUOYE
			end
		ELSE IF @Type=''Data''
			begin
				EXEC ClearData
			end
		if  @@error<>0 
		begin
			rollback   tran   
		end
		else
		begin
			commit  tran
		end	
END

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertDeviceSJD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		YangJun
-- Create date: 2012.07.20
-- Description:	新增设备
-- =============================================
CREATE PROCEDURE [dbo].[InsertDeviceSJD]
	@deviceid					varchar(50)				= null
,	@fdate						varchar(30)				= null
,	@msg						nvarchar(500)			= null output
,	@devicetablename			nvarchar(100)			= null output
AS
BEGIN
	declare @isdevid int,@iscz int,@devicetype varchar(50),@savedate int,@startdate datetime,@enddate datetime,@devmodel int;
	
	set @isdevid=(select count(*) from devicelist where devid=@deviceid);

	declare @tablename varchar(100);
	declare @startmonth varchar(10),@endmonth varchar(10),@startday varchar(10),@endday varchar(10);

	declare @devname varchar(100),@orgid varchar(100);

	if @isdevid>0
		begin
			print ''>0''
			set @iscz=(select count(*) from devicelogrecordlist where deviceid=@deviceid and fdatestart<=@fdate)
			print @iscz
			
			set @devmodel=(select devmodel from devicelist where devid=@deviceid);
			set @devicetype=(select [type] from DeviceModelList where id=@devmodel);
			set @savedate=(select savedate from devicetypelist where code=@devicetype);
			
			declare @bb varchar(30)
			set @bb=(select dateadd(dd,1,@fdate))

			declare @cc varchar(30)
			set @cc=(select dateadd(dd,-1,@fdate))

			print @bb

			declare @a int
			set @a=(select count(*) from DeviceLogRecordList where deviceid=@deviceid and fdatestart<=@bb and fdateend>=@bb)

			print @a
			if @a<=0
				begin
			
			
			set @startdate=(select top 1 fdateend from DeviceLogRecordList where deviceid=@deviceid and fdateend>=@fdate and fdatestart<=@fdate order by fdateend desc);
			
			print ''startdate''	
			print @startdate
			if @startdate='''' or @startdate is null
				begin
					set @startdate=@fdate;
				end
			else
				begin
					set @startdate=(select dateadd(dd,1,@startdate));
				end
			set @enddate=(select dateadd(dd,@savedate,@startdate));

			print ''aaa''
			print @startdate
			print @enddate
			
			set @startmonth=(select month(@startdate));
			if len(@startmonth) <2
				begin
					set @startmonth=''0''+@startmonth
				end
			set @startday=(select day(@startdate));
			if len(@startday)<2
				begin
					set @startday=''0''+@startday;
				end

			set @endmonth=(select month(@enddate));
			if len(@endmonth)<2
				begin
					set @endmonth=''0''+@endmonth;
				end
			set @endday=(select day(@enddate));
			if len(@endday)<2
				begin
					set @endday=''0''+@endday;
				end
		
			set @tablename=''Money_''+@deviceid+''_''+@startmonth+@startday+@endmonth+@endday;

			declare @tablename1 varchar(200)
			set @tablename1=@deviceid+''_''+@startmonth+@startday+@endmonth+@endday;
			
			print @tablename
			set @orgid=(select orgid from devicelist where devid=@deviceid);
			set @devname=(select devname from devicelist where devid=@deviceid)

			declare @tableiscz int
			set @tableiscz=(select count(*) from DeviceLogRecordList where tablename=@tablename)
			
			

			exec CreateMoneyTable @tablename1,@devname,@orgid
			if @tableiscz=0
				begin
	
					INSERT INTO DeviceLogRecordList
							([deviceid]
							,[devicename]
							,[tablename]
							,[orgId]
							,fdatestart
							,fdateend)
							VALUES
							(@deviceid
							,@devname
							,@tablename
							,@orgid
							,@startdate
							,@enddate)
				end
				set @msg=''0''; ---新增成功
				print ''0''
				set @devicetablename=@tablename
			end
		else
			begin
				set @msg=''2''  ---设备表已存在
				print ''2''
				set @devicetablename=(select tablename from DeviceLogRecordList where deviceid=@deviceid and fdatestart<=@fdate and fdateend>=@fdate)
			end
			
		end

	else
		begin
			print ''<0''
			print ''此设备不存在！''
			set @msg=''1'';

		end
	
	
END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertDevice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





CREATE PROCEDURE [dbo].[InsertDevice]
	@DeviceID			Varchar(30)					= NULL
,	@DeviceName			Varchar(30)					= NULL
,	@Listenport			INT							= NULL
,	@FirmwareVersion	Varchar(20)					= NULL
,	@SoftwareVersion	Varchar(20)					= NULL
,	@PhotowareVersion	Varchar(20)					= NULL
,	@ReportCount		INT							= NULL
,	@SearchGZ			Varchar(30)					= NULL
,	@OrgId				varchar(80)					= NULL
,	@devModel			varchar(50)					= NULL
,	@DevType			varchar(20)					= NULL
,	@DevPort			varchar(20)					= NULL
,	@IpAddress			varchar(30)					= NULL		
AS
BEGIN
	begin   tran  

	INSERT INTO DeviceList
	               (	devid
		            ,	devname
		            ,	firmware_version
		            ,	software_version
                    ,   photoware_version
		            ,	dev_state
                    ,   updatetime
					,	listenport
                    ,   portcount
					,	del
					,	reportcount
					,	defaultgz
					,	OrgId
					,	devtype
					,	devmodel
					,	port
					,	ipaddress)
	                 VALUES
	              (	@DeviceID
		            ,	@DeviceName
		            ,	@FirmwareVersion
		            ,	@SoftwareVersion
                    ,   @PhotowareVersion
                    ,   1
                    ,   getdate()
                    ,   @Listenport
					,	@Listenport
					,	0
					,	@ReportCount
					,	@SearchGZ
					,	@OrgId
					,	@DevType
					,	@devModel
					,	@DevPort
					,	@IpAddress)



	Exec dbo.CreateMoneyTable @DeviceID,@DeviceName,@OrgId

	update UpdateInfo set date=getdate() where type=''SB''

	if  @@error<>0 
	begin
		rollback   tran   
	end
	else
	begin
		commit  tran
	end
 
END















' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertMoneyInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[InsertMoneyInfo] 
	@moneyid			varchar(100)			= null
,	@bankid				varchar(100)			= null
,	@bankname			varchar(100)			= null
,	@fdate				varchar(10)				= null
,	@ftime				varchar(10)				= null
,	@flowno				varchar(20)				= null
,	@batchno			varchar(30)				= null
,	@serialno			varchar(30)				= null
,	@price				varchar(10)				= null
,	@kindno				varchar(5)				= null
,	@fakes				varchar(10)				= null
,	@photo				image					= null
,	@fullphoto			image					= null
,	@photoname			varchar(300)			= null
,	@devid				varchar(50)				= null
,	@devname			varchar(30)				= null
,	@recognitioninfo	varchar(50)				= null
,	@mrecognitioninfo	varchar(100)			= null
,	@bzbh				varchar(5)				= null
,	@photowidth			int						= null
,	@photoheight		int						= null
,	@facedirect			varchar(50)				= null
,	@refusereason		varchar(100)			= null
,	@outport			varchar(50)				= null
,	@jobnum				varchar(20)				= null
AS
BEGIN

	if @moneyid='''' set @moneyid=null
	if @bankid='''' set @bankid=null
	if @bankname='''' set @bankname=null
	if @fdate='''' set @fdate=null
	if @ftime='''' set @ftime=null
	if @flowno='''' set @flowno=null
	if @batchno='''' set @batchno=null
	if @serialno='''' set @serialno=null
	if @price='''' set @price=null
	if @kindno='''' set @kindno=null
	if @fakes='''' set @fakes=null
--	if @photo='''' set @photo=null
--	if @fullphoto='''' set @fullphoto=null
	if @photoname='''' set @photoname=null
	if @devid='''' set @devid=null
	if @devname='''' set @devname=null
	if @recognitioninfo='''' set @recognitioninfo=null
	if @mrecognitioninfo='''' set @mrecognitioninfo=null
	if @bzbh='''' set @bzbh=null
	if @photowidth='''' set @photowidth=null
	if @photoheight='''' set @photoheight=null
	if @facedirect='''' set @facedirect=null
	if @refusereason='''' set @refusereason=null
	if @outport='''' set @outport=null
	if @JobNum='''' set @JobNum=null

	declare @tablename nvarchar(100),@msg nvarchar(500),@coldate varchar(30)

	update eval(@tablename) set photo=@photo

	set @msg='''';
	set @tablename='''';
	set @coldate=getdate();

	exec InsertDeviceSJD @devid,@coldate,@msg output,@tablename output

	print ''表名：''
	PRINT @tablename

	if @msg=''0'' or @msg=''2''
		begin
			print ''表合理''

			print @tablename

			if @tablename=''''
				begin
					declare @bb varchar(30)
					set @bb=(select dateadd(dd,1,@fdate))
					set @tablename=(select tablename from DeviceLogRecordList where deviceid=@devid and fdatestart<=@bb and fdateend>=@bb )
				end

			print @tablename

			declare @sql nvarchar(4000)

			set @sql=''INSERT INTO ''+@tablename+''([moneyid],[bankid],[bankname],[fdate],[ftime]
						,[flowno],[batchno],[serialno],[price],[kindno],[fakes]
						,[photoname],[devid],[devname],[recognitioninfo],[mrecognitioninfo],[bzbh]
						,photowidth,photoheight
						 ,[facedirect],[refusereason] ,[outport],[JobNum])
					 VALUES
						(''''''+@moneyid+'''''' ,''''''+@bankid+'''''',''''''+@bankname+'''''',''''''+@fdate+'''''',''''''+@ftime+'''''',''''''+@flowno+'''''',''''''
						+@batchno+'''''',''''''+@serialno+'''''' ,''''''+@price+'''''',''''''+@kindno+'''''',''''''+@fakes+'''''',''''''+@photoname+'''''' ,''''''+@devid+'''''',''''''
						+@devname+'''''' ,''''''+@recognitioninfo+'''''',''''''
						+@mrecognitioninfo+'''''',''''''+@bzbh+'''''',''+convert(varchar,@photowidth)+'',''+convert(varchar,@photoheight)+'',''''''
						+@facedirect+'''''',''''''+@refusereason+'''''',''''''+@outport+'''''',''''''+@jobnum+'''''')''

			print @sql
			print ''sql''
			exec(@sql)

			declare @photosql nvarchar(4000)

			if @photo is not null
				begin
					set @photosql=''update ''+@tablename +'' set photo=''+convert(varchar,convert(varbinary,@photo))+'' where moneyid=''''''+@moneyid+''''''''
					print @photosql
					exec (@photosql)
				end

			if @fullphoto is not null
				begin
					set @photosql=''update ''+@tablename +'' set fullphoto=''+convert(varchar,convert(varbinary,@fullphoto))+'' where moneyid=''''''+@moneyid+''''''''
					print @photosql
					exec (@photosql)

				end
			
		end
	else
		begin
			print ''表不存在！''
		end

END



' 
END


------------创建存储过程---------------------------------------

---------------------必备数据----------------------------------

------------PageList Insert start-----------------------------------------------------

INSERT INTO pagelist VALUES (1001, 'DiveceList.aspx', 'ASP.divecelist_aspx ', NULL, '设备管理');
INSERT INTO pagelist VALUES (1002, 'UserList.aspx', 'ASP.userlist_aspx', NULL, '用户管理');
INSERT INTO pagelist VALUES (1003, 'ProgramList.aspx', 'ASP.programlist_aspx', NULL, '权限管理');
INSERT INTO pagelist VALUES (1004, 'RoleList.aspx', 'ASP.rolelist_aspx', NULL, '角色管理');
INSERT INTO pagelist VALUES (1005, 'LoginList.aspx', 'ASP.loginlist_aspx', NULL, '登录记录管理');
INSERT INTO pagelist VALUES (1006, 'CollectionDaySearch.aspx', 'ASP.collectiondaysearch_aspx', NULL, '采集信息日显示');
INSERT INTO pagelist VALUES (1007, 'CollectionDayTJ.aspx', 'ASP.collectiondaytj_aspx', NULL, '采集信息日统计');
INSERT INTO pagelist VALUES (1008, 'CollectionMothSearch.aspx', 'ASP.collectionmothsearch_aspx', NULL, '采集信息月显示');
INSERT INTO pagelist VALUES (1009, 'CollectionYearSearch.aspx', 'ASP.collectionyearsearch_aspx', NULL, '采集信息年显示');
INSERT INTO pagelist VALUES (10010, 'CollectionMothTJ.aspx', 'ASP.collectionmothtj_aspx', NULL, '采集信息月统计');
INSERT INTO pagelist VALUES (10011, 'CollectionYearTJ.aspx', 'ASP.collectionyeartj_aspx', NULL, '采集信息年统计');
INSERT INTO pagelist VALUES (10012, 'DataSearchTj.aspx', 'ASP.datasearchtj_aspx', NULL, '数据统计');
INSERT INTO pagelist VALUES (10013, 'RefuseReasonTJ.aspx', 'ASP.refusereasontj_aspx ', NULL, '退钞原因统计');
INSERT INTO pagelist VALUES (10014, 'SearchDataTJ.aspx', 'ASP.searchdatatj_aspx ', NULL, '数据统计1');
INSERT INTO pagelist VALUES (10015, 'SaveDateEdit.aspx', 'ASP.savedateedit_aspx', NULL, '数据保存天数设置');
INSERT INTO pagelist VALUES (10016, 'KaChaoReasonTJ.aspx', 'ASP.kachaoreasontj_aspx', NULL, '卡钞原因统计');
INSERT INTO pagelist VALUES (10017, 'ConfigList.aspx', 'ASP.configlist_aspx', NULL, '配置管理');
INSERT INTO pagelist VALUES (10018, 'StandMoneyList.aspx', 'ASP.standmoneylist_aspx ', NULL, '纸币类别管理');
INSERT INTO pagelist VALUES (10019, 'RefuseReasonList.aspx', 'ASP.refusereasonlist_aspx ', NULL, '退钞原因管理');
INSERT INTO pagelist VALUES (10020, 'PortSearchGuiZeList.aspx', 'ASP.portsearchguizelist_aspx', NULL, '出钞口查询规则配置');
INSERT INTO pagelist VALUES (10021, 'RecvList.aspx', 'ASP.recvlist_aspx', NULL, '错误故障信息');
INSERT INTO pagelist VALUES (10022, 'OrganizationList.aspx', 'ASP.organizationlist_aspx  ', NULL, '网点管理');
INSERT INTO pagelist VALUES (10023, 'StandMoneyTJ.aspx', 'ASP.standmoneytj_aspx', NULL, '纸币分类统计');
INSERT INTO pagelist VALUES (10024, 'OrgTjTu.aspx', 'ASP.orgtjtu_aspx', NULL, '网点统计图');
INSERT INTO pagelist VALUES (10025, 'TuiChaoYYTjTu.aspx', 'ASP.tuichaoyytjtu_aspx ', NULL, '退钞原因统计图');
INSERT INTO pagelist VALUES (10026, 'EveryOrgStandTjTu.aspx', 'ASP.everyorgstandtjtu_aspx', NULL, '网点面额统计图');
INSERT INTO pagelist VALUES (10027, 'OrgDeviceTJTu.aspx', 'ASP.orgdevicetjtu_aspx', NULL, '网点设备统计图');
INSERT INTO pagelist VALUES (10028, 'SDDeleteData.aspx', 'ASP_sddeletedata_aspx', NULL, '冗余数据清理');
INSERT INTO pagelist VALUES (10029, 'DeviceTypeList.aspx', 'ASP_devicetypelist_aspx', NULL, '设备类型管理');
INSERT INTO pagelist VALUES (10030, 'DeviceModelList.aspx', 'ASP_devicemodellist_aspx', NULL, '设备型号管理');
INSERT INTO pagelist VALUES (10031, 'HeiMingDanList.aspx', 'ASP_heimingdanlist_aspx', NULL, '黑名单管理');
INSERT INTO pagelist VALUES (10032, 'NoticeInfoList.aspx', 'ASP_noticeinfolist_aspx', NULL, '未注册设备信息');


------------PageList Insert end-----------------------------------------------------

-------------------ProgramList insert start------------------------------------------

INSERT INTO programlist VALUES ( '纸币信息采集系统', 0, NULL, '_load', NULL, NULL, 0);
INSERT INTO programlist VALUES ( '采集信息管理', 1, NULL, '_load', NULL, NULL, 0);
INSERT INTO programlist VALUES ( '采集统计管理', 1, NULL, '_load', NULL, NULL, 0);
INSERT INTO programlist VALUES ( '系统配置', 1, NULL, '_load', NULL, NULL, 0);
INSERT INTO programlist VALUES ( '用户管理', 4, NULL, '_load', NULL, '1002', 2);
INSERT INTO programlist VALUES ( '角色管理', 4, NULL, '_load', NULL, '1004', 3);
INSERT INTO programlist VALUES ( '权限管理', 4, NULL, '_load', NULL, '1003', 4);
INSERT INTO programlist VALUES ( '设备管理', 4, NULL, '_load', NULL, '1001', 5);
INSERT INTO programlist VALUES ( '登录记录管理', 4, NULL, '_load', NULL, '1005', 16);
INSERT INTO programlist VALUES ( '采集信息明细', 2, NULL, '_load', NULL, '1006', 1);
INSERT INTO programlist VALUES ( '退钞原因统计', 3, NULL, '_load', NULL, '10013', 2);
INSERT INTO programlist VALUES ( '数据保存天数设置', 4, NULL, '_load', NULL, '10015', 15);
INSERT INTO programlist VALUES ( '卡钞原因统计', 3, NULL, '_load', NULL, '10016', 3);
INSERT INTO programlist VALUES ( '配置管理', 4, NULL, '_load', NULL, '10017', 10);
INSERT INTO programlist VALUES ( '纸币类别管理', 4, NULL, '_load', NULL, '10018', 11);
INSERT INTO programlist VALUES ( '退钞原因管理', 4, NULL, '_load', NULL, '10019', 12);
INSERT INTO programlist VALUES ( '出钞口查询规则配置', 4, NULL, '_load', NULL, '10020', 13);
INSERT INTO programlist VALUES ( '错误故障信息', 4, NULL, '_load', NULL, '10021', 14);
INSERT INTO programlist VALUES ( '网点管理', 4, NULL, '_load', NULL, '10022', 1);
INSERT INTO programlist VALUES ( '网点分类统计', 3, NULL, '_load', NULL, '10023', 1);
INSERT INTO programlist VALUES ( '网点统计图', 3, NULL, '_load', NULL, '10024', 4);
INSERT INTO programlist VALUES ( '退钞原因统计图', 3, NULL, '_load', NULL, '10025', 5);
INSERT INTO programlist VALUES ( '网点面额统计图', 3, NULL, '_load', NULL, '10026', 6);
INSERT INTO programlist VALUES ( '网点设备统计图', 3, NULL, '_load', NULL, '10027', 7);
INSERT INTO programlist VALUES ( '冗余数据清理', 4, NULL, '_load', NULL, '10028', 17);
INSERT INTO programlist VALUES ( '设备类型管理', 4, NULL, '_load', NULL, '10029', 6);
INSERT INTO programlist VALUES ( '设备型号管理', 3, NULL, '_load', NULL, '10030', 7);
INSERT INTO programlist VALUES ( '黑名单管理', 4, NULL, '_load', NULL, '10031', 8);
INSERT INTO programlist VALUES ( '未注册设备信息', 4, NULL, '_load', NULL, '10032', 9);

-------------------ProgramList insert end------------------------------------------

--------------------------Role insert start-----------------------------------------

Insert into RoleList values ('超级管理员',1)
insert into RoleList values ('系统管理员',1)

--------------------------Role insert end-------------------------------------------


---------------------------RoleProgramList insert start-----------------------------



INSERT INTO roleprogramlist VALUES ( 1, 1);
INSERT INTO roleprogramlist VALUES ( 1, 2);
INSERT INTO roleprogramlist VALUES ( 1, 3);
INSERT INTO roleprogramlist VALUES ( 1, 4);
INSERT INTO roleprogramlist VALUES ( 1, 5);
INSERT INTO roleprogramlist VALUES ( 1, 6);
INSERT INTO roleprogramlist VALUES ( 1, 7);
INSERT INTO roleprogramlist VALUES ( 1, 8);
INSERT INTO roleprogramlist VALUES ( 1, 9);
INSERT INTO roleprogramlist VALUES ( 1, 10);
INSERT INTO roleprogramlist VALUES ( 1, 11);
INSERT INTO roleprogramlist VALUES ( 1, 12);
INSERT INTO roleprogramlist VALUES ( 1, 13);
INSERT INTO roleprogramlist VALUES ( 1, 14);
INSERT INTO roleprogramlist VALUES ( 1, 15);
INSERT INTO roleprogramlist VALUES ( 1, 16);
INSERT INTO roleprogramlist VALUES ( 1, 17);
INSERT INTO roleprogramlist VALUES ( 1, 18);
INSERT INTO roleprogramlist VALUES ( 1, 19);
INSERT INTO roleprogramlist VALUES ( 1, 20);
INSERT INTO roleprogramlist VALUES ( 1, 21);
INSERT INTO roleprogramlist VALUES ( 1, 22);
INSERT INTO roleprogramlist VALUES ( 1, 23);
INSERT INTO roleprogramlist VALUES ( 1, 24);
INSERT INTO roleprogramlist VALUES ( 1, 25);
INSERT INTO roleprogramlist VALUES ( 1, 26);


---------------------------RoleProgramList insert start-----------------------------

insert into UserList values('admin','admin','tracy',1,1,'tracy@qq.com','12188888888','2000-08-08',1,'')


insert into UpdateInfo values('HMD',NULL)
insert into UpdateInfo values('SB',NULL)



---------------------必备数据----------------------------------


------------------------创建视图 start--------------------------------


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vtable_LS]
AS
SELECT     list.moneyid, b.OrgId AS bankid, c.OrgName AS bankname, list.fdate, list.ftime, list.serialno, list.price, list.kindno, list.fakes, list.devid, b.devname, list.recognitioninfo, 
                      list.bzbh, list.photowidth, list.photoheight, stand.bz, stand.me, stand.dw, list.flowno, list.batchno, list.outport, list.facedirect, list.refusereason, list.mrecognitioninfo, 
                      stand.fxdw, stand.bb, list.photo, list.fullphoto, list.photoname, list.JobNum
FROM         dbo.Money_LS AS list LEFT OUTER JOIN
                      dbo.StandMoneyList AS stand ON list.bzbh = stand.bzbh LEFT OUTER JOIN
                      dbo.DeviceList AS b ON list.devid = b.devid LEFT OUTER JOIN
                      dbo.OrganizationList AS c ON b.OrgId = c.OrgId

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "list"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 206
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "stand"
            Begin Extent = 
               Top = 6
               Left = 244
               Bottom = 125
               Right = 389
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 427
               Bottom = 125
               Right = 609
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 647
               Bottom = 125
               Right = 801
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
     ' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'vtable_LS'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Or = 1350
      End
   End
End
' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'vtable_LS'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'VIEW', @level1name=N'vtable_LS'


------------------------------创建视图 end-------------------------------------------------------------------







