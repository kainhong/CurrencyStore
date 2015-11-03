# SQL Manager 2010 for MySQL 4.5.0.9
# ---------------------------------------
# Host     : localhost
# Port     : 3306
# Database : currencystore


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

SET FOREIGN_KEY_CHECKS=0;

DROP DATABASE IF EXISTS `currencystore`;

CREATE DATABASE `currencystore`
    CHARACTER SET 'utf8'
    COLLATE 'utf8_general_ci';

USE `currencystore`;

#
# Structure for the `tbl_basic_dictionary` table : 
#

DROP TABLE IF EXISTS `tbl_basic_dictionary`;

CREATE TABLE `tbl_basic_dictionary` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `DictKind` tinyint(4) unsigned NOT NULL COMMENT '字典数据类别，1-设备类型，2-设备型号，3-纸币种类，4-纸币类型，5-业务类型，6-钞口号码',
  `DictKey` tinyint(4) unsigned NOT NULL COMMENT '字典数据键',
  `DictValue` varchar(32) NOT NULL COMMENT '字典数据值',
  `IsSystem` tinyint(4) unsigned NOT NULL COMMENT '是否系统字典，0-非系统参数，1-系统参数',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_basic_organization` table : 
#

DROP TABLE IF EXISTS `tbl_basic_organization`;

CREATE TABLE `tbl_basic_organization` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `OrgNumber` varchar(16) NOT NULL COMMENT '网点机构号码',
  `OrgName` varchar(32) NOT NULL COMMENT '网点机构名称',
  `OrgAddress` varchar(64) NOT NULL COMMENT '网点机构地址',
  `OrgParentId` int(11) unsigned NOT NULL COMMENT '上级网点机构Id，人工创建，引用PkId',
  `OrgFullPath` varchar(256) NOT NULL COMMENT '网点机构路径',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_basic_parameter` table : 
#

DROP TABLE IF EXISTS `tbl_basic_parameter`;

CREATE TABLE `tbl_basic_parameter` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `ParamKey` varchar(32) NOT NULL COMMENT '参数键',
  `ParamName` varchar(32) NOT NULL COMMENT '参数名',
  `ParamValue` varchar(256) NOT NULL COMMENT '参数值',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_currency_blacklist` table : 
#

DROP TABLE IF EXISTS `tbl_currency_blacklist`;

CREATE TABLE `tbl_currency_blacklist` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `CurrencyKindCode` tinyint(4) unsigned NOT NULL COMMENT '纸币种类代码，机器发送，引用字典Key',
  `FaceAmount` smallint(6) unsigned NOT NULL COMMENT '纸币面额',
  `CurrencyVersion` smallint(6) unsigned NOT NULL COMMENT '纸币版本',
  `CurrencyNumber` varchar(16) NOT NULL COMMENT '纸币号码',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_currency_export` table : 
#

DROP TABLE IF EXISTS `tbl_currency_export`;

CREATE TABLE `tbl_currency_export` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `OrgId` int(11) unsigned NOT NULL COMMENT '网点机构Id，人工创建，引用PkId',
  `DeviceNumber` varchar(32) NOT NULL COMMENT '设备号码',
  `OperateStartTime` varchar(10) NOT NULL COMMENT '操作开始时间',
  `OperateEndTime` varchar(10) NOT NULL COMMENT '操作结束时间',
  `CurrencyNumber` varchar(16) NOT NULL COMMENT '纸币号码',
  `ExportStatus` tinyint(4) unsigned NOT NULL COMMENT '导出状态，0-未开始，1-进行中，2-已完成',
  `DataCount` int(11) unsigned NOT NULL COMMENT '数据量',
  `FileName` varchar(64) NOT NULL COMMENT '文件名称',
  `FileSize` varchar(32) NOT NULL COMMENT '文件大小',
  `CreateUserId` int(11) unsigned NOT NULL COMMENT '创建用户Id，人工创建，引用PkId',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_currency_info` table : 
#

DROP TABLE IF EXISTS `tbl_currency_info`;

CREATE TABLE `tbl_currency_info` (
  `OrgId` int(11) unsigned NOT NULL COMMENT '网点机构Id，人工创建，引用PkId',
  `DeviceNumber` varchar(32) NOT NULL COMMENT '设备号码',
  `DeviceKindCode` tinyint(4) unsigned NOT NULL COMMENT '设备类别代码，机器发送，引用字典Key',
  `DeviceModelCode` tinyint(4) unsigned NOT NULL COMMENT '设备型号代码，机器发送，引用字典Key',
  `OperatorNumber` tinyint(4) unsigned NOT NULL COMMENT '操作员号码',
  `OperateTime` datetime NOT NULL COMMENT '操作时间',
  `BusinessType` tinyint(4) unsigned NOT NULL COMMENT '业务类型，0-未知，1-存款，2-取款，3-复点，4-清分，5-ATM配钞，机器发送，引用字典Key',
  `ClientCardNumber` varchar(32) NOT NULL COMMENT '客户卡号',
  `BatchNumber` char(8) NOT NULL COMMENT '批次号码',
  `OrderNumber` int(11) unsigned NOT NULL COMMENT '纸币顺序号',
  `CurrencyKindCode` tinyint(4) unsigned NOT NULL COMMENT '纸币种类代码，机器发送，引用字典Key',
  `FaceAmount` smallint(6) unsigned NOT NULL COMMENT '纸币面额',
  `CurrencyVersion` smallint(6) unsigned NOT NULL COMMENT '纸币版本',
  `CurrencyType` tinyint(4) unsigned NOT NULL COMMENT '纸币类型，4-ATM券，5-流通券，6-残损券，7-退钞券，机器发送，引用字典Key',
  `PortNumber` tinyint(4) unsigned NOT NULL COMMENT '钞口号码，0-退钞口，1-1号钞口，2-2号钞口，3-3号钞口，4-4号钞口',
  `IsSuspicious` tinyint(4) NOT NULL COMMENT '是否可疑，0-真钞，非0-可疑钞',
  `CurrencyNumber` varchar(16) NOT NULL COMMENT '纸币号码',
  `CurrencyImageType` tinyint(4) unsigned NOT NULL COMMENT '纸币图像类型，0-无图像，1-360字节，2-240字节，3-120字节',
  `CurrencyImage` varbinary(360) NOT NULL COMMENT '纸币图像',
  `IsDuplicate` tinyint(4) NOT NULL COMMENT '是否重复，0-不重复，1-重复',
  `IsUpload` tinyint(4) NOT NULL COMMENT '是否已上传，0-未上传，1-已上传'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_device_connection` table : 
#

DROP TABLE IF EXISTS `tbl_device_connection`;

CREATE TABLE `tbl_device_connection` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `DeviceNumber` varchar(32) NOT NULL COMMENT '设备号码',
  `DeviceIp` varchar(16) NOT NULL COMMENT '设备地址',
  `OrgId` int(11) unsigned NOT NULL COMMENT '网点机构Id，人工创建，引用PkId',
  `CollectorName` varchar(16) NOT NULL COMMENT '采集系统名称',
  `CollectorIp` varchar(16) NOT NULL COMMENT '采集系统地址',
  `ConnectionStatus` tinyint(4) unsigned NOT NULL COMMENT '连接状态，1-已连接，2-未连接',
  `ConnectTime` datetime NOT NULL COMMENT '连接时间',
  `DisconnectTime` datetime NOT NULL COMMENT '断开时间',
  `UploadCount` int(11) unsigned NOT NULL COMMENT '上传张数',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_device_info` table : 
#

DROP TABLE IF EXISTS `tbl_device_info`;

CREATE TABLE `tbl_device_info` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `DeviceNumber` varchar(32) NOT NULL COMMENT '设备号码',
  `SoftwareVersion` char(8) NOT NULL COMMENT '软件版本',
  `RegisterIp` varchar(16) NOT NULL COMMENT '注册地址',
  `KindCode` tinyint(4) unsigned NOT NULL COMMENT '设备类别代码，机器发送，引用字典Key',
  `ModelCode` tinyint(4) unsigned NOT NULL COMMENT '设备型号代码，机器发送，引用字典Key',
  `OrgId` int(11) unsigned NOT NULL COMMENT '网点机构Id，人工创建，引用PkId',
  `OnLineTime` datetime NOT NULL COMMENT '上线时间',
  `DeviceStatus` tinyint(4) unsigned NOT NULL COMMENT '设备状态，0-禁用，1-启用',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_user_info` table : 
#

DROP TABLE IF EXISTS `tbl_user_info`;

CREATE TABLE `tbl_user_info` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `UserAccount` varchar(16) NOT NULL COMMENT '用户账户',
  `UserPwd` varchar(64) NOT NULL COMMENT '用户密码',
  `UserNickName` varchar(16) NOT NULL COMMENT '用户昵称',
  `UserEmail` varchar(32) NOT NULL COMMENT '电子邮件',
  `UserPhone` varchar(16) NOT NULL COMMENT '联系电话',
  `UserStatus` tinyint(4) unsigned NOT NULL COMMENT '用户状态，0-禁用，1-启用',
  `RoleId` int(11) unsigned NOT NULL COMMENT '角色Id，人工创建，引用PkId',
  `OrgId` int(11) unsigned NOT NULL COMMENT '网点机构Id，人工创建，引用PkId',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_user_login` table : 
#

DROP TABLE IF EXISTS `tbl_user_login`;

CREATE TABLE `tbl_user_login` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `UserId` int(11) unsigned NOT NULL COMMENT '用户Id，人工创建，引用PkId',
  `LoginTime` datetime NOT NULL COMMENT '登录时间',
  `LoginIp` varchar(16) NOT NULL COMMENT '登录IP地址',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_user_permission` table : 
#

DROP TABLE IF EXISTS `tbl_user_permission`;

CREATE TABLE `tbl_user_permission` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `PermCode` varchar(8) NOT NULL COMMENT '权限代码',
  `PermName` varchar(32) NOT NULL COMMENT '权限名称',
  `PermLevel` tinyint(4) unsigned NOT NULL COMMENT '权限级别，1-1级菜单，2-2级菜单',
  `PermContent` varchar(128) NOT NULL COMMENT '权限内容',
  `PermParentId` int(11) unsigned NOT NULL COMMENT '上级权限Id，人工创建，引用PkId',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_user_role` table : 
#

DROP TABLE IF EXISTS `tbl_user_role`;

CREATE TABLE `tbl_user_role` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `RoleName` varchar(16) NOT NULL COMMENT '角色名称',
  `DataFilter` tinyint(4) unsigned NOT NULL COMMENT '数据过滤，0-不过滤，1-过滤',
  `RoleStatus` tinyint(4) unsigned NOT NULL COMMENT '角色状态，0-禁用，1-启用',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_user_rolepermission` table : 
#

DROP TABLE IF EXISTS `tbl_user_rolepermission`;

CREATE TABLE `tbl_user_rolepermission` (
  `PkId` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `RoleId` int(11) unsigned NOT NULL COMMENT '角色Id，人工创建，引用PkId',
  `PermCode` varchar(8) NOT NULL COMMENT '权限代码',
  PRIMARY KEY (`PkId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

#
# Data for the `tbl_basic_dictionary` table  (LIMIT 0,500)
#

INSERT INTO `tbl_basic_dictionary` (`PkId`, `DictKind`, `DictKey`, `DictValue`, `IsSystem`) VALUES 
  (1,1,1,'ATM机',0),
  (2,1,2,'点钞机',0),
  (3,1,3,'验钞机',0),
  (4,2,1,'型号A',0),
  (5,2,2,'型号B',0),
  (6,2,3,'型号C',0),
  (7,6,1,'出钞口A',0),
  (8,6,2,'出钞口B',0),
  (9,6,3,'出钞口C',0),
  (10,4,1,'ATM券',0),
  (11,4,2,'流通券',0),
  (12,4,3,'残损券',0),
  (13,4,4,'退钞券',0),
  (14,5,1,'存款',0),
  (15,5,2,'取款',0),
  (16,5,3,'复点',0),
  (17,5,4,'清分',0),
  (18,5,5,'配钞',0),
  (19,3,0,'[CNY]人民币',0),
  (20,3,1,'[USD]美元',0),
  (21,3,2,'[EUR]欧元',0);
COMMIT;

#
# Data for the `tbl_basic_parameter` table  (LIMIT 0,500)
#

INSERT INTO `tbl_basic_parameter` (`PkId`, `ParamKey`, `ParamName`, `ParamValue`) VALUES 
  (1,'BlacklistVersion','黑名单版本号','20130116'),
  (2,'DataStorageDays','数据保存天数','30'),
  (3,'DataClearTime','数据清理时间','00:00:00'),
  (4,'FileStorageCount','文件保存数量','20'),
  (5,'CurrencyInfoColumn','纸币信息字段','[1][2][3][4][5][6][7][8][9][10][11][12][13][14][15][16][17][18]'),
  (6,'CollectSystemName','采集系统名称','纸币流通管理系统'),
  (7,'SystemLogoPicture','系统标志图片','');
COMMIT;

#
# Data for the `tbl_user_info` table  (LIMIT 0,500)
#

INSERT INTO `tbl_user_info` (`PkId`, `UserAccount`, `UserPwd`, `UserNickName`, `UserEmail`, `UserPhone`, `UserStatus`, `RoleId`, `OrgId`) VALUES 
  (1,'mast','Q3Rj7wCqHA0=','mast','','',1,1,0),
  (2,'22','egUXv5pjEgQ=','22','','',1,2,0),
  (3,'333','2UL0sCVE4jM=','333','','',1,3,0),
  (4,'4444','Izk7s/xHyiU=','4444','','',1,4,0),
  (5,'55555','4gyRMpxFHnY=','55555','','',1,5,0);
COMMIT;

#
# Data for the `tbl_user_permission` table  (LIMIT 0,500)
#

INSERT INTO `tbl_user_permission` (`PkId`, `PermCode`, `PermName`, `PermLevel`, `PermContent`, `PermParentId`) VALUES 
  (1,'M01','纸币采集',1,'',0),
  (2,'M02','数据统计',1,'',0),
  (3,'M03','系统设备',1,'',0),
  (4,'M04','基本配置',1,'',0),
  (5,'M0101','纸币信息',2,'Currency_Info_List.aspx?UserId={UserId}&UnknowOrg=0',1),
  (6,'M0102','未知采集',2,'Currency_Info_List.aspx?UserId={UserId}&UnknowOrg=1',1),
  (7,'M0103','数据导入',2,'Currency_Info_Import.aspx?UserId={UserId}',1),
  (8,'M0104','数据导出',2,'Currency_Export_List.aspx?UserId={UserId}',1),
  (9,'M0105','纸币种类',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=3',1),
  (10,'M0106','纸币类型',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=4',1),
  (11,'M0107','业务类型',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=5',1),
  (12,'M0108','黑名单',2,'Currency_Blacklist_List.aspx?UserId={UserId}',1),
  (13,'M0201','网点设备统计',2,'Stat_Device_List.aspx?UserId={UserId}',2),
  (14,'M0202','网点纸币统计',2,'Stat_Currency_List.aspx?UserId={UserId}',2),
  (15,'M0203','网点明细统计',2,'Stat_Org_List.aspx?UserId={UserId}',2),
  (16,'M0204','卡钞原因统计',2,'-',2),
  (17,'M0205','网点面额统计',2,'-',2),
  (18,'M0206','钞券类型统计',2,'-',2),
  (19,'M0301','设备信息',2,'Device_Info_List.aspx?UserId={UserId}&UnknowOrg=0',3),
  (20,'M0302','未知设备',2,'Device_Info_List.aspx?UserId={UserId}&UnknowOrg=1',3),
  (21,'M0303','设备在线',2,'Device_Online_List.aspx?UserId={UserId}',3),
  (22,'M0304','设备变动',2,'Device_Change_List.aspx?UserId={UserId}',3),
  (23,'M0305','设备类别',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=1',3),
  (24,'M0306','设备型号',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=2',3),
  (25,'M0307','设备端口',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=6',3),
  (26,'M0401','网点机构',2,'Basic_Org_List.aspx?UserId={UserId}',4),
  (27,'M0402','角色信息',2,'User_Role_List.aspx?UserId={UserId}',4),
  (28,'M0403','用户信息',2,'User_Info_List.aspx?UserId={UserId}',4),
  (29,'M0404','登录日志',2,'User_Login_List.aspx?UserId={UserId}',4),
  (30,'M0405','数据清理',2,'Data_Clear.aspx?UserId={UserId}',4),
  (31,'M0406','业务参数',2,'Basic_Parameter.aspx?UserId={UserId}',4),
  (32,'M0407','系统标志',2,'Basic_Logo.aspx?UserId={UserId}',4);
COMMIT;

#
# Data for the `tbl_user_role` table  (LIMIT 0,500)
#

INSERT INTO `tbl_user_role` (`PkId`, `RoleName`, `DataFilter`, `RoleStatus`) VALUES 
  (1,'超级管理员',0,1),
  (2,'系统管理员',0,1),
  (3,'网点管理员',1,1),
  (4,'网点柜员',1,1),
  (5,'行外用户',0,1);
COMMIT;

#
# Data for the `tbl_user_rolepermission` table  (LIMIT 0,500)
#

INSERT INTO `tbl_user_rolepermission` (`PkId`, `RoleId`, `PermCode`) VALUES 
  (1,1,'M0101'),
  (2,1,'M0102'),
  (3,1,'M0103'),
  (4,1,'M0104'),
  (5,1,'M0105'),
  (6,1,'M0106'),
  (7,1,'M0107'),
  (8,1,'M0108'),
  (9,1,'M0201'),
  (10,1,'M0202'),
  (11,1,'M0203'),
  (12,1,'M0301'),
  (13,1,'M0302'),
  (14,1,'M0303'),
  (15,1,'M0304'),
  (16,1,'M0305'),
  (17,1,'M0306'),
  (18,1,'M0307'),
  (19,1,'M0401'),
  (20,1,'M0402'),
  (21,1,'M0403'),
  (22,1,'M0404'),
  (23,1,'M0405'),
  (24,1,'M0406'),
  (25,1,'M0407'),
  (26,2,'M0101'),
  (27,2,'M0102'),
  (28,2,'M0103'),
  (29,2,'M0104'),
  (30,2,'M0105'),
  (31,2,'M0106'),
  (32,2,'M0107'),
  (33,2,'M0108'),
  (34,2,'M0201'),
  (35,2,'M0202'),
  (36,2,'M0203'),
  (37,2,'M0301'),
  (38,2,'M0302'),
  (39,2,'M0303'),
  (40,2,'M0304'),
  (41,2,'M0305'),
  (42,2,'M0306'),
  (43,2,'M0307'),
  (44,2,'M0401'),
  (45,2,'M0402'),
  (46,2,'M0403'),
  (47,2,'M0404'),
  (48,2,'M0405'),
  (49,2,'M0406'),
  (50,2,'M0407'),
  (51,3,'M0101'),
  (52,3,'M0102'),
  (53,3,'M0103'),
  (54,3,'M0104'),
  (55,3,'M0201'),
  (56,3,'M0202'),
  (57,3,'M0203'),
  (58,3,'M0301'),
  (59,3,'M0302'),
  (60,3,'M0303'),
  (61,3,'M0304'),
  (62,4,'M0101'),
  (63,4,'M0102'),
  (64,4,'M0103'),
  (65,4,'M0104'),
  (66,4,'M0301'),
  (67,4,'M0302'),
  (68,4,'M0303'),
  (69,4,'M0304'),
  (70,5,'M0101'),
  (71,5,'M0102'),
  (72,5,'M0104');
COMMIT;



/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;