
prompt Created on 2013年5月31日 by guojia
set feedback off
set define off
prompt Dropping TBL_BASIC_DICTIONARY...
drop table TBL_BASIC_DICTIONARY cascade constraints;
prompt Dropping TBL_BASIC_ORGANIZATION...
drop table TBL_BASIC_ORGANIZATION cascade constraints;
prompt Dropping TBL_BASIC_PARAMETER...
drop table TBL_BASIC_PARAMETER cascade constraints;
prompt Dropping TBL_CURRENCY_BLACKLIST...
drop table TBL_CURRENCY_BLACKLIST cascade constraints;
prompt Dropping TBL_CURRENCY_EXPORT...
drop table TBL_CURRENCY_EXPORT cascade constraints;
prompt Dropping TBL_CURRENCY_INFO...
drop table TBL_CURRENCY_INFO cascade constraints;
prompt Dropping TBL_DEVICE_CONNECTION...
drop table TBL_DEVICE_CONNECTION cascade constraints;
prompt Dropping TBL_DEVICE_INFO...
drop table TBL_DEVICE_INFO cascade constraints;
prompt Dropping TBL_USER_INFO...
drop table TBL_USER_INFO cascade constraints;
prompt Dropping TBL_USER_LOGIN...
drop table TBL_USER_LOGIN cascade constraints;
prompt Dropping TBL_USER_PERMISSION...
drop table TBL_USER_PERMISSION cascade constraints;
prompt Dropping TBL_USER_ROLE...
drop table TBL_USER_ROLE cascade constraints;
prompt Dropping TBL_USER_ROLEPERMISSION...
drop table TBL_USER_ROLEPERMISSION cascade constraints;
prompt Creating TBL_BASIC_DICTIONARY...
create table TBL_BASIC_DICTIONARY
(
  pkid      NUMBER(11) not null,
  dictkind  NUMBER(4),
  dictkey   NUMBER(4),
  dictvalue VARCHAR2(32 CHAR),
  issystem  NUMBER(4)
)
;
create unique index PKTBL_BASIC_DICTIONARY on TBL_BASIC_DICTIONARY (PKID);
alter table TBL_BASIC_DICTIONARY
  add constraint PRIMARYTBL_BASIC_DICTIONARY1 primary key (PKID);

prompt Creating TBL_BASIC_ORGANIZATION...
create table TBL_BASIC_ORGANIZATION
(
  pkid        NUMBER(11) not null,
  orgnumber   VARCHAR2(16 CHAR),
  orgname     VARCHAR2(32 CHAR),
  orgaddress  VARCHAR2(64 CHAR),
  orgparentid NUMBER(11),
  orgfullpath VARCHAR2(256 CHAR)
)
;
create unique index PKTBL_BASIC_ORGANIZATION on TBL_BASIC_ORGANIZATION (PKID);
alter table TBL_BASIC_ORGANIZATION
  add constraint PRIMARYTBL_BASIC_ORGANIZATION1 primary key (PKID);

prompt Creating TBL_BASIC_PARAMETER...
create table TBL_BASIC_PARAMETER
(
  pkid       NUMBER(11) not null,
  paramkey   VARCHAR2(32 CHAR),
  paramname  VARCHAR2(32 CHAR),
  paramvalue VARCHAR2(256 CHAR)
)
;
create unique index PKTBL_BASIC_PARAMETER1 on TBL_BASIC_PARAMETER (PKID);
alter table TBL_BASIC_PARAMETER
  add constraint PRIMARYTBL_BASIC_PARAMETER1 primary key (PKID);

prompt Creating TBL_CURRENCY_BLACKLIST...
create table TBL_CURRENCY_BLACKLIST
(
  pkid             NUMBER(11) not null,
  currencykindcode NUMBER(4),
  faceamount       NUMBER(6),
  currencyversion  NUMBER(6),
  currencynumber   VARCHAR2(16 CHAR)
)
;
create unique index PKTBL_CURRENCY_BLACKLIST on TBL_CURRENCY_BLACKLIST (PKID);
alter table TBL_CURRENCY_BLACKLIST
  add constraint PRIMARYTBL_CURRENCY_BLACKLIST1 primary key (PKID);

prompt Creating TBL_CURRENCY_EXPORT...
create table TBL_CURRENCY_EXPORT
(
  pkid             NUMBER(11) not null,
  orgid            NUMBER(11),
  devicenumber     VARCHAR2(32 CHAR),
  operatestarttime VARCHAR2(10 CHAR),
  operateendtime   VARCHAR2(10 CHAR),
  currencynumber   VARCHAR2(16 CHAR),
  exportstatus     NUMBER(4),
  datacount        NUMBER(11),
  filename         VARCHAR2(64 CHAR),
  filesize         VARCHAR2(32 CHAR),
  createuserid     NUMBER(11),
  createtime       DATE
)
;
create unique index PKTBL_CURRENCY_EXPORT on TBL_CURRENCY_EXPORT (PKID);
alter table TBL_CURRENCY_EXPORT
  add constraint PRIMARYTBL_CURRENCY_EXPORT1 primary key (PKID);

prompt Creating TBL_CURRENCY_INFO...
create table TBL_CURRENCY_INFO
(
  pkid              NUMBER(20) not null,
  orgid             NUMBER(11),
  devicenumber      VARCHAR2(32 CHAR),
  devicekindcode    NUMBER(4),
  devicemodelcode   NUMBER(4),
  operatornumber    NUMBER(4),
  operatetime       DATE,
  businesstype      NUMBER(4),
  clientcardnumber  VARCHAR2(32 CHAR),
  batchnumber       CHAR(8 CHAR),
  ordernumber       NUMBER(11),
  currencykindcode  NUMBER(4),
  faceamount        NUMBER(6),
  currencyversion   NUMBER(6),
  currencytype      NUMBER(4),
  portnumber        NUMBER(4),
  issuspicious      NUMBER(4),
  currencynumber    VARCHAR2(16 CHAR),
  currencyimagetype NUMBER(4),
  currencyimage     VARCHAR2(600),
  isduplicate       NUMBER(4),
  isupload          NUMBER(4)
)
;
create unique index PKTBL_CURRENCY_INFO on TBL_CURRENCY_INFO (PKID);
alter table TBL_CURRENCY_INFO
  add primary key (PKID);

prompt Creating TBL_DEVICE_CONNECTION...
create table TBL_DEVICE_CONNECTION
(
  pkid             NUMBER(11) not null,
  devicenumber     VARCHAR2(32 CHAR),
  deviceip         VARCHAR2(16 CHAR),
  orgid            NUMBER(11),
  collectorname    VARCHAR2(16 CHAR),
  collectorip      VARCHAR2(16 CHAR),
  connectionstatus NUMBER(4),
  connecttime      DATE,
  disconnecttime   DATE,
  uploadcount      NUMBER(11)
)
;
create unique index PKTBL_DEVICE_CONNECTION on TBL_DEVICE_CONNECTION (PKID);
alter table TBL_DEVICE_CONNECTION
  add constraint PRIMARYTBL_DEVICE_CONNECTION1 primary key (PKID);

prompt Creating TBL_DEVICE_INFO...
create table TBL_DEVICE_INFO
(
  pkid            NUMBER(11) not null,
  devicenumber    VARCHAR2(32 CHAR),
  softwareversion VARCHAR2(8 CHAR),
  registerip      VARCHAR2(16 CHAR),
  kindcode        NUMBER(4),
  modelcode       NUMBER(4),
  orgid           NUMBER(11),
  onlinetime      DATE,
  devicestatus    NUMBER(4)
)
;
create unique index PKTBL_DEVICE_INFO on TBL_DEVICE_INFO (PKID);
alter table TBL_DEVICE_INFO
  add constraint PRIMARYTBL_DEVICE_INFO1 primary key (PKID);

prompt Creating TBL_USER_INFO...
create table TBL_USER_INFO
(
  pkid         NUMBER not null,
  useraccount  VARCHAR2(16 CHAR),
  userpwd      VARCHAR2(64 CHAR),
  usernickname VARCHAR2(16 CHAR),
  useremail    VARCHAR2(32 CHAR),
  userphone    VARCHAR2(16 CHAR),
  userstatus   NUMBER(4),
  roleid       NUMBER(11),
  orgid        NUMBER(11)
)
;
create unique index PKTBL_USER_INFO on TBL_USER_INFO (PKID);
alter table TBL_USER_INFO
  add constraint PRIMARYTBL_USER_INFO1 primary key (PKID);

prompt Creating TBL_USER_LOGIN...
create table TBL_USER_LOGIN
(
  pkid      NUMBER(11) not null,
  userid    NUMBER(11),
  logintime DATE,
  loginip   VARCHAR2(16 CHAR)
)
;
create unique index PKTBL_USER_LOGIN on TBL_USER_LOGIN (PKID);
alter table TBL_USER_LOGIN
  add primary key (PKID);

prompt Creating TBL_USER_PERMISSION...
create table TBL_USER_PERMISSION
(
  pkid         NUMBER(11) not null,
  permcode     VARCHAR2(8 CHAR),
  permname     VARCHAR2(32 CHAR),
  permlevel    NUMBER(4),
  permcontent  VARCHAR2(128 CHAR),
  permparentid NUMBER(11)
)
;
create unique index PKTBL_USER_PERMISSION on TBL_USER_PERMISSION (PKID);
alter table TBL_USER_PERMISSION
  add constraint PRIMARYTBL_USER_PERMISSION1 primary key (PKID);

prompt Creating TBL_USER_ROLE...
create table TBL_USER_ROLE
(
  pkid       NUMBER(11) not null,
  rolename   VARCHAR2(16 CHAR),
  datafilter NUMBER(4),
  rolestatus NUMBER(4)
)
;
create unique index PKTBL_USER_ROLE on TBL_USER_ROLE (PKID);
alter table TBL_USER_ROLE
  add constraint PRIMARYTBL_USER_ROLE1 primary key (PKID);

prompt Creating TBL_USER_ROLEPERMISSION...
create table TBL_USER_ROLEPERMISSION
(
  pkid     NUMBER(11) not null,
  roleid   NUMBER(11),
  permcode VARCHAR2(8 CHAR)
)
;
create unique index PKTBL_USER_ROLEPERMISSION on TBL_USER_ROLEPERMISSION (PKID);
alter table TBL_USER_ROLEPERMISSION
  add constraint PRIMARYTBL_USER_ROLEPERMISSION primary key (PKID);


INSERT INTO tbl_basic_dictionary (PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (1,1,1,'ATM机',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (2,1,2,'点钞机',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (3,1,3,'验钞机',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (4,2,1,'型号A',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (5,2,2,'型号B',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (6,2,3,'型号C',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (7,6,1,'出钞口A',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (8,6,2,'出钞口B',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (9,6,3,'出钞口C',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (10,4,1,'ATM券',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (11,4,2,'流通券',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (12,4,3,'残损券',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (13,4,4,'退钞券',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (14,5,1,'存款',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (15,5,2,'取款',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (16,5,3,'复点',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (17,5,4,'清分',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (18,5,5,'配钞',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (19,3,0,'[CNY]人民币',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (20,3,1,'[USD]美元',0);
INSERT INTO  tbl_basic_dictionary  ( PkId ,  DictKind ,  DictKey ,  DictValue ,  IsSystem ) VALUES 
  (21,3,2,'[EUR]欧元',0);


INSERT INTO  tbl_basic_organization  ( PkId ,  OrgNumber ,  OrgName ,  OrgAddress ,  OrgParentId ,  OrgFullPath ) VALUES 
  (1,'000000','000000','xxxxxxxxxx',0,'[0][1]');


INSERT INTO  tbl_basic_parameter  ( PkId ,  ParamKey ,  ParamName ,  ParamValue ) VALUES 
  (1,'BlacklistVersion','黑名单版本号','20130110');
INSERT INTO  tbl_basic_parameter  ( PkId ,  ParamKey ,  ParamName ,  ParamValue ) VALUES 
  (2,'DataStorageDays','数据保存天数','30');
INSERT INTO  tbl_basic_parameter  ( PkId ,  ParamKey ,  ParamName ,  ParamValue ) VALUES 
  (3,'DataClearTime','数据清理时间','00:00:00');
INSERT INTO  tbl_basic_parameter  ( PkId ,  ParamKey ,  ParamName ,  ParamValue ) VALUES 
  (4,'FileStorageCount','文件保存数量','20');
INSERT INTO  tbl_basic_parameter  ( PkId ,  ParamKey ,  ParamName ,  ParamValue ) VALUES 
  (5,'CurrencyInfoColumn','纸币信息字段','[1][2][3][4][5][6][7][8][9][10][11][12][13][14][15][16][17][18]');
INSERT INTO  tbl_basic_parameter  ( PkId ,  ParamKey ,  ParamName ,  ParamValue ) VALUES 
  (6,'CollectSystemName','采集系统名称','纸币流通管理系统');
INSERT INTO  tbl_basic_parameter  ( PkId ,  ParamKey ,  ParamName ,  ParamValue ) VALUES 
  (7,'SystemLogoPicture','系统标志图片','');

INSERT INTO  tbl_user_info  ( PkId ,  UserAccount ,  UserPwd ,  UserNickName ,  UserEmail ,  UserPhone ,  UserStatus ,  RoleId ,  OrgId ) VALUES 
  (1,'mast','Q3Rj7wCqHA0=','mast',' ',' ',1,1,0);
INSERT INTO  tbl_user_info  ( PkId ,  UserAccount ,  UserPwd ,  UserNickName ,  UserEmail ,  UserPhone ,  UserStatus ,  RoleId ,  OrgId ) VALUES 
  (2,'22','egUXv5pjEgQ=','22',' ',' ',1,2,0);
INSERT INTO  tbl_user_info  ( PkId ,  UserAccount ,  UserPwd ,  UserNickName ,  UserEmail ,  UserPhone ,  UserStatus ,  RoleId ,  OrgId ) VALUES 
  (3,'333','2UL0sCVE4jM=','333',' ',' ',1,3,0);
INSERT INTO  tbl_user_info  ( PkId ,  UserAccount ,  UserPwd ,  UserNickName ,  UserEmail ,  UserPhone ,  UserStatus ,  RoleId ,  OrgId ) VALUES 
  (4,'4444','Izk7s/xHyiU=','4444',' ',' ',1,4,0);
INSERT INTO  tbl_user_info  ( PkId ,  UserAccount ,  UserPwd ,  UserNickName ,  UserEmail ,  UserPhone ,  UserStatus ,  RoleId ,  OrgId ) VALUES 
  (5,'55555','4gyRMpxFHnY=','55555',' ',' ',1,5,0);



INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (1,'M01','纸币采集',1, ' ',0);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (2,'M02','数据统计',1, ' ',0);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (3,'M03','系统设备',1, ' ',0);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (4,'M04','基本配置',1, ' ',0);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (5,'M0101','纸币信息',2,'Currency_Info_List.aspx?UserId={UserId}&UnknowOrg=0',1);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (6,'M0102','未知采集',2,'Currency_Info_List.aspx?UserId={UserId}&UnknowOrg=1',1);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (7,'M0103','数据导入',2,'Currency_Info_Import.aspx?UserId={UserId}',1);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (8,'M0104','数据导出',2,'Currency_Export_List.aspx?UserId={UserId}',1);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (9,'M0105','纸币种类',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=3',1);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (10,'M0106','纸币类型',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=4',1);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (11,'M0107','业务类型',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=5',1);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (12,'M0108','黑名单',2,'Currency_Blacklist_List.aspx?UserId={UserId}',1);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (13,'M0201','网点设备统计',2,'Stat_Device_List.aspx?UserId={UserId}',2);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (14,'M0202','网点纸币统计',2,'Stat_Currency_List.aspx?UserId={UserId}',2);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (15,'M0203','网点明细统计',2,'Stat_Org_List.aspx?UserId={UserId}',2);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (16,'M0204','卡钞原因统计',2,'-',2);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (17,'M0205','网点面额统计',2,'-',2);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (18,'M0206','钞券类型统计',2,'-',2);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (19,'M0301','设备信息',2,'Device_Info_List.aspx?UserId={UserId}&UnknowOrg=0',3);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (20,'M0302','未知设备',2,'Device_Info_List.aspx?UserId={UserId}&UnknowOrg=1',3);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (21,'M0303','设备在线',2,'Device_Online_List.aspx?UserId={UserId}',3);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (22,'M0304','设备变动',2,'Device_Change_List.aspx?UserId={UserId}',3);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (23,'M0305','设备类别',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=1',3);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (24,'M0306','设备型号',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=2',3);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (25,'M0307','设备端口',2,'Basic_Dict_List.aspx?UserId={UserId}&Kind=6',3);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (26,'M0401','网点机构',2,'Basic_Org_List.aspx?UserId={UserId}',4);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (27,'M0402','角色信息',2,'User_Role_List.aspx?UserId={UserId}',4);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (28,'M0403','用户信息',2,'User_Info_List.aspx?UserId={UserId}',4);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (29,'M0404','登录日志',2,'User_Login_List.aspx?UserId={UserId}',4);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (30,'M0405','数据清理',2,'Data_Clear.aspx?UserId={UserId}',4);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (31,'M0406','业务参数',2,'Basic_Parameter.aspx?UserId={UserId}',4);
INSERT INTO  tbl_user_permission  ( PkId ,  PermCode ,  PermName ,  PermLevel ,  PermContent ,  PermParentId ) VALUES 
  (32,'M0407','系统标志',2,'Basic_Logo.aspx?UserId={UserId}',4);

INSERT INTO  tbl_user_role  ( PkId ,  RoleName ,  DataFilter ,  RoleStatus  ) VALUES 
  (1,'超级管理员',0,1);
INSERT INTO  tbl_user_role  ( PkId ,  RoleName ,  DataFilter ,  RoleStatus  ) VALUES 
  (2,'系统管理员',0,1);
INSERT INTO  tbl_user_role  ( PkId ,  RoleName ,  DataFilter ,  RoleStatus  ) VALUES 
  (3,'网点管理员',1,1);
INSERT INTO  tbl_user_role  ( PkId ,  RoleName ,  DataFilter ,  RoleStatus ) VALUES 
  (4,'网点柜员',1,1);
INSERT INTO  tbl_user_role  ( PkId ,  RoleName ,  DataFilter ,  RoleStatus  ) VALUES 
  (5,'行外用户',0,1);














INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (1,1,'M0101');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (2,1,'M0102');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (3,1,'M0103');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (4,1,'M0104');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (5,1,'M0105');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (6,1,'M0106');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (7,1,'M0107');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (8,1,'M0108');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (9,1,'M0201');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (10,1,'M0202');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (11,1,'M0203');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (12,1,'M0301');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (13,1,'M0302');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (14,1,'M0303');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (15,1,'M0304');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (16,1,'M0305');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (17,1,'M0306');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (18,1,'M0307');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (19,1,'M0401');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (20,1,'M0402');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (21,1,'M0403');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (22,1,'M0404');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (23,1,'M0405');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (24,1,'M0406');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (25,1,'M0407');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (26,2,'M0101');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (27,2,'M0102');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (28,2,'M0103');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES   
(29,2,'M0104');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES   (30,2,'M0105');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (31,2,'M0106');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (32,2,'M0107');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (33,2,'M0108');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (34,2,'M0201');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (35,2,'M0202');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (36,2,'M0203');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (37,2,'M0301');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (38,2,'M0302');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (39,2,'M0303');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (40,2,'M0304');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (41,2,'M0305');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (42,2,'M0306');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (43,2,'M0307');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (44,2,'M0401');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (45,2,'M0402');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (46,2,'M0403');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (47,2,'M0404');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (48,2,'M0405');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (49,2,'M0406');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (50,2,'M0407');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (51,3,'M0101');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (52,3,'M0102');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (53,3,'M0103');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (54,3,'M0104');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (55,3,'M0201');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (56,3,'M0202');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (57,3,'M0203');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (58,3,'M0301');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (59,3,'M0302');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (60,3,'M0303');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (61,3,'M0304');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (62,4,'M0101');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (63,4,'M0102');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES
  (64,4,'M0103');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (65,4,'M0104');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (66,4,'M0301');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (67,4,'M0302');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (68,4,'M0303');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (69,4,'M0304');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (70,5,'M0101');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (71,5,'M0102');
INSERT INTO  tbl_user_rolepermission  ( PkId ,  RoleId ,  PermCode ) VALUES 
  (72,5,'M0104');


create sequence TBD_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;

create sequence TBO_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TBP_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TCB_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TCE_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TCI_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TDC_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TDI_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TUI_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TUL_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TUP_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;


create sequence TURP_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;

create sequence TUR_PKID
minvalue 1
maxvalue 9999999999999999999999999999
start with 100
increment by 1
nocache;



commit;

set feedback on
set define on
prompt Done.
