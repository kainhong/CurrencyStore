namespace CurrencyStore.Client
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.lblClientCount = new System.Windows.Forms.Label();
            this.txtClientCount = new System.Windows.Forms.TextBox();
            this.txtSendInterval = new System.Windows.Forms.TextBox();
            this.lblSendInterval = new System.Windows.Forms.Label();
            this.lblSendIntervalUnit = new System.Windows.Forms.Label();
            this.lblRealClientCount = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lvClientList = new System.Windows.Forms.ListView();
            this.chDeviceNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chConnectCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDeviceStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTimeOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHeartbeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBlacklistCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCurrencyCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chConnectMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelStatus = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrencyCount = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.lblTimeOutUnit = new System.Windows.Forms.Label();
            this.rbHeartbeat = new System.Windows.Forms.RadioButton();
            this.rbLogin = new System.Windows.Forms.RadioButton();
            this.rbBlacklist = new System.Windows.Forms.RadioButton();
            this.rbCurrency = new System.Windows.Forms.RadioButton();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnCreateDevice = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.timerMemoryClear = new System.Windows.Forms.Timer(this.components);
            this.cbAutoRefresh = new System.Windows.Forms.CheckBox();
            this.lblCurrencyCountMultiply = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.lblTotalHeartbeatCount = new System.Windows.Forms.Label();
            this.lblTotalLoginCount = new System.Windows.Forms.Label();
            this.lblTotalBlacklistCount = new System.Windows.Forms.Label();
            this.lblTotalCurrencyCount = new System.Windows.Forms.Label();
            this.lblCostTime = new System.Windows.Forms.Label();
            this.timerTotalCount = new System.Windows.Forms.Timer(this.components);
            this.lblPerSecondAvgCount = new System.Windows.Forms.Label();
            this.lblTotalConnectedCount = new System.Windows.Forms.Label();
            this.lblDeviceNumberRule = new System.Windows.Forms.Label();
            this.cbbDeviceNumberRule = new System.Windows.Forms.ComboBox();
            this.lblReconnectCount = new System.Windows.Forms.Label();
            this.txtReconnectCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerAddress.Location = new System.Drawing.Point(8, 8);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(80, 23);
            this.lblServerAddress.TabIndex = 1;
            this.lblServerAddress.Text = "服务器地址：";
            this.lblServerAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblServerPort
            // 
            this.lblServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerPort.Location = new System.Drawing.Point(208, 8);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(80, 23);
            this.lblServerPort.TabIndex = 2;
            this.lblServerPort.Text = "服务器端口：";
            this.lblServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerAddress.Location = new System.Drawing.Point(96, 8);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(96, 21);
            this.txtServerAddress.TabIndex = 4;
            this.txtServerAddress.Text = "127.0.0.1";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerPort.Location = new System.Drawing.Point(296, 8);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(96, 21);
            this.txtServerPort.TabIndex = 5;
            this.txtServerPort.Text = "8234";
            // 
            // lblClientCount
            // 
            this.lblClientCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientCount.Location = new System.Drawing.Point(8, 40);
            this.lblClientCount.Name = "lblClientCount";
            this.lblClientCount.Size = new System.Drawing.Size(80, 23);
            this.lblClientCount.TabIndex = 6;
            this.lblClientCount.Text = "点钞机数量：";
            this.lblClientCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientCount
            // 
            this.txtClientCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientCount.Location = new System.Drawing.Point(96, 40);
            this.txtClientCount.Name = "txtClientCount";
            this.txtClientCount.Size = new System.Drawing.Size(40, 21);
            this.txtClientCount.TabIndex = 7;
            this.txtClientCount.Text = "1000";
            // 
            // txtSendInterval
            // 
            this.txtSendInterval.Location = new System.Drawing.Point(96, 72);
            this.txtSendInterval.MaxLength = 5;
            this.txtSendInterval.Name = "txtSendInterval";
            this.txtSendInterval.Size = new System.Drawing.Size(40, 21);
            this.txtSendInterval.TabIndex = 9;
            this.txtSendInterval.Text = "50";
            // 
            // lblSendInterval
            // 
            this.lblSendInterval.Location = new System.Drawing.Point(8, 72);
            this.lblSendInterval.Name = "lblSendInterval";
            this.lblSendInterval.Size = new System.Drawing.Size(80, 23);
            this.lblSendInterval.TabIndex = 8;
            this.lblSendInterval.Text = "数据包间隔：";
            this.lblSendInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSendIntervalUnit
            // 
            this.lblSendIntervalUnit.Location = new System.Drawing.Point(144, 72);
            this.lblSendIntervalUnit.Name = "lblSendIntervalUnit";
            this.lblSendIntervalUnit.Size = new System.Drawing.Size(48, 23);
            this.lblSendIntervalUnit.TabIndex = 10;
            this.lblSendIntervalUnit.Text = "(毫秒)";
            this.lblSendIntervalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRealClientCount
            // 
            this.lblRealClientCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRealClientCount.ForeColor = System.Drawing.Color.Blue;
            this.lblRealClientCount.Location = new System.Drawing.Point(144, 40);
            this.lblRealClientCount.Name = "lblRealClientCount";
            this.lblRealClientCount.Size = new System.Drawing.Size(48, 23);
            this.lblRealClientCount.TabIndex = 11;
            this.lblRealClientCount.Text = "0";
            this.lblRealClientCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(400, 40);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "开始连接";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(400, 104);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "刷新视图";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lvClientList
            // 
            this.lvClientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDeviceNumber,
            this.chConnectCount,
            this.chDeviceStatus,
            this.chTimeOut,
            this.chHeartbeat,
            this.chLogin,
            this.chBlacklistCount,
            this.chCurrencyCount,
            this.chConnectMessage});
            this.lvClientList.FullRowSelect = true;
            this.lvClientList.GridLines = true;
            this.lvClientList.Location = new System.Drawing.Point(488, 40);
            this.lvClientList.MultiSelect = false;
            this.lvClientList.Name = "lvClientList";
            this.lvClientList.Size = new System.Drawing.Size(560, 432);
            this.lvClientList.TabIndex = 19;
            this.lvClientList.UseCompatibleStateImageBehavior = false;
            this.lvClientList.View = System.Windows.Forms.View.Details;
            // 
            // chDeviceNumber
            // 
            this.chDeviceNumber.Text = "设备编号";
            this.chDeviceNumber.Width = 100;
            // 
            // chConnectCount
            // 
            this.chConnectCount.Text = "连接次数";
            this.chConnectCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chDeviceStatus
            // 
            this.chDeviceStatus.Text = "状态";
            this.chDeviceStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chDeviceStatus.Width = 50;
            // 
            // chTimeOut
            // 
            this.chTimeOut.Text = "超时";
            this.chTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTimeOut.Width = 50;
            // 
            // chHeartbeat
            // 
            this.chHeartbeat.Text = "心跳";
            this.chHeartbeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chHeartbeat.Width = 50;
            // 
            // chLogin
            // 
            this.chLogin.Text = "登录";
            this.chLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chLogin.Width = 50;
            // 
            // chBlacklistCount
            // 
            this.chBlacklistCount.Text = "黑名单";
            this.chBlacklistCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chBlacklistCount.Width = 50;
            // 
            // chCurrencyCount
            // 
            this.chCurrencyCount.Text = "纸币";
            this.chCurrencyCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCurrencyCount.Width = 50;
            // 
            // chConnectMessage
            // 
            this.chConnectMessage.Text = "连接信息";
            this.chConnectMessage.Width = 400;
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.AutoScroll = true;
            this.panelStatus.Location = new System.Drawing.Point(8, 200);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(464, 272);
            this.panelStatus.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(208, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "单机点钞量：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrencyCount
            // 
            this.txtCurrencyCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrencyCount.Location = new System.Drawing.Point(296, 40);
            this.txtCurrencyCount.Name = "txtCurrencyCount";
            this.txtCurrencyCount.Size = new System.Drawing.Size(40, 21);
            this.txtCurrencyCount.TabIndex = 22;
            this.txtCurrencyCount.Text = "20000";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(400, 72);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "结束连接";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.Location = new System.Drawing.Point(208, 72);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(80, 23);
            this.lblTimeOut.TabIndex = 24;
            this.lblTimeOut.Text = "数据包超时：";
            this.lblTimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(296, 72);
            this.txtTimeOut.MaxLength = 5;
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(40, 21);
            this.txtTimeOut.TabIndex = 25;
            this.txtTimeOut.Text = "350";
            // 
            // lblTimeOutUnit
            // 
            this.lblTimeOutUnit.Location = new System.Drawing.Point(344, 72);
            this.lblTimeOutUnit.Name = "lblTimeOutUnit";
            this.lblTimeOutUnit.Size = new System.Drawing.Size(48, 23);
            this.lblTimeOutUnit.TabIndex = 26;
            this.lblTimeOutUnit.Text = "(毫秒)";
            this.lblTimeOutUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbHeartbeat
            // 
            this.rbHeartbeat.Location = new System.Drawing.Point(8, 104);
            this.rbHeartbeat.Name = "rbHeartbeat";
            this.rbHeartbeat.Size = new System.Drawing.Size(48, 24);
            this.rbHeartbeat.TabIndex = 27;
            this.rbHeartbeat.TabStop = true;
            this.rbHeartbeat.Text = "心跳";
            this.rbHeartbeat.UseVisualStyleBackColor = true;
            // 
            // rbLogin
            // 
            this.rbLogin.Location = new System.Drawing.Point(64, 104);
            this.rbLogin.Name = "rbLogin";
            this.rbLogin.Size = new System.Drawing.Size(48, 24);
            this.rbLogin.TabIndex = 28;
            this.rbLogin.TabStop = true;
            this.rbLogin.Text = "登录";
            this.rbLogin.UseVisualStyleBackColor = true;
            // 
            // rbBlacklist
            // 
            this.rbBlacklist.Location = new System.Drawing.Point(120, 104);
            this.rbBlacklist.Name = "rbBlacklist";
            this.rbBlacklist.Size = new System.Drawing.Size(64, 24);
            this.rbBlacklist.TabIndex = 29;
            this.rbBlacklist.TabStop = true;
            this.rbBlacklist.Text = "黑名单";
            this.rbBlacklist.UseVisualStyleBackColor = true;
            // 
            // rbCurrency
            // 
            this.rbCurrency.Location = new System.Drawing.Point(192, 104);
            this.rbCurrency.Name = "rbCurrency";
            this.rbCurrency.Size = new System.Drawing.Size(48, 24);
            this.rbCurrency.TabIndex = 30;
            this.rbCurrency.TabStop = true;
            this.rbCurrency.Text = "纸币";
            this.rbCurrency.UseVisualStyleBackColor = true;
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(248, 104);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(72, 23);
            this.btnSendData.TabIndex = 31;
            this.btnSendData.Text = "发送数据";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnCreateDevice
            // 
            this.btnCreateDevice.Location = new System.Drawing.Point(400, 8);
            this.btnCreateDevice.Name = "btnCreateDevice";
            this.btnCreateDevice.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDevice.TabIndex = 32;
            this.btnCreateDevice.Text = "创建设备";
            this.btnCreateDevice.UseVisualStyleBackColor = true;
            this.btnCreateDevice.Click += new System.EventHandler(this.btnCreateDevice_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // timerMemoryClear
            // 
            this.timerMemoryClear.Enabled = true;
            this.timerMemoryClear.Interval = 30000;
            this.timerMemoryClear.Tick += new System.EventHandler(this.timerMemoryClear_Tick);
            // 
            // cbAutoRefresh
            // 
            this.cbAutoRefresh.Location = new System.Drawing.Point(328, 104);
            this.cbAutoRefresh.Name = "cbAutoRefresh";
            this.cbAutoRefresh.Size = new System.Drawing.Size(72, 24);
            this.cbAutoRefresh.TabIndex = 34;
            this.cbAutoRefresh.Text = "自动刷新";
            this.cbAutoRefresh.UseVisualStyleBackColor = true;
            this.cbAutoRefresh.CheckedChanged += new System.EventHandler(this.cbAutoRefresh_CheckedChanged);
            // 
            // lblCurrencyCountMultiply
            // 
            this.lblCurrencyCountMultiply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrencyCountMultiply.Location = new System.Drawing.Point(344, 40);
            this.lblCurrencyCountMultiply.Name = "lblCurrencyCountMultiply";
            this.lblCurrencyCountMultiply.Size = new System.Drawing.Size(8, 23);
            this.lblCurrencyCountMultiply.TabIndex = 35;
            this.lblCurrencyCountMultiply.Text = "*";
            this.lblCurrencyCountMultiply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDay
            // 
            this.txtDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDay.Location = new System.Drawing.Point(360, 40);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(32, 21);
            this.txtDay.TabIndex = 36;
            this.txtDay.Text = "1";
            // 
            // lblTotalHeartbeatCount
            // 
            this.lblTotalHeartbeatCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalHeartbeatCount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalHeartbeatCount.Location = new System.Drawing.Point(8, 136);
            this.lblTotalHeartbeatCount.Name = "lblTotalHeartbeatCount";
            this.lblTotalHeartbeatCount.Size = new System.Drawing.Size(48, 23);
            this.lblTotalHeartbeatCount.TabIndex = 37;
            this.lblTotalHeartbeatCount.Text = "0";
            this.lblTotalHeartbeatCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalLoginCount
            // 
            this.lblTotalLoginCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalLoginCount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalLoginCount.Location = new System.Drawing.Point(64, 136);
            this.lblTotalLoginCount.Name = "lblTotalLoginCount";
            this.lblTotalLoginCount.Size = new System.Drawing.Size(48, 23);
            this.lblTotalLoginCount.TabIndex = 38;
            this.lblTotalLoginCount.Text = "0";
            this.lblTotalLoginCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalBlacklistCount
            // 
            this.lblTotalBlacklistCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalBlacklistCount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalBlacklistCount.Location = new System.Drawing.Point(120, 136);
            this.lblTotalBlacklistCount.Name = "lblTotalBlacklistCount";
            this.lblTotalBlacklistCount.Size = new System.Drawing.Size(64, 23);
            this.lblTotalBlacklistCount.TabIndex = 39;
            this.lblTotalBlacklistCount.Text = "0";
            this.lblTotalBlacklistCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCurrencyCount
            // 
            this.lblTotalCurrencyCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCurrencyCount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalCurrencyCount.Location = new System.Drawing.Point(192, 136);
            this.lblTotalCurrencyCount.Name = "lblTotalCurrencyCount";
            this.lblTotalCurrencyCount.Size = new System.Drawing.Size(128, 23);
            this.lblTotalCurrencyCount.TabIndex = 40;
            this.lblTotalCurrencyCount.Text = "0";
            this.lblTotalCurrencyCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCostTime
            // 
            this.lblCostTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCostTime.ForeColor = System.Drawing.Color.Blue;
            this.lblCostTime.Location = new System.Drawing.Point(328, 136);
            this.lblCostTime.Name = "lblCostTime";
            this.lblCostTime.Size = new System.Drawing.Size(144, 23);
            this.lblCostTime.TabIndex = 41;
            this.lblCostTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerTotalCount
            // 
            this.timerTotalCount.Enabled = true;
            this.timerTotalCount.Interval = 1000;
            this.timerTotalCount.Tick += new System.EventHandler(this.timerTotalCount_Tick);
            // 
            // lblPerSecondAvgCount
            // 
            this.lblPerSecondAvgCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPerSecondAvgCount.ForeColor = System.Drawing.Color.Blue;
            this.lblPerSecondAvgCount.Location = new System.Drawing.Point(8, 168);
            this.lblPerSecondAvgCount.Name = "lblPerSecondAvgCount";
            this.lblPerSecondAvgCount.Size = new System.Drawing.Size(464, 23);
            this.lblPerSecondAvgCount.TabIndex = 42;
            this.lblPerSecondAvgCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalConnectedCount
            // 
            this.lblTotalConnectedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalConnectedCount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalConnectedCount.Location = new System.Drawing.Point(856, 8);
            this.lblTotalConnectedCount.Name = "lblTotalConnectedCount";
            this.lblTotalConnectedCount.Size = new System.Drawing.Size(192, 23);
            this.lblTotalConnectedCount.TabIndex = 43;
            this.lblTotalConnectedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeviceNumberRule
            // 
            this.lblDeviceNumberRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeviceNumberRule.Location = new System.Drawing.Point(488, 8);
            this.lblDeviceNumberRule.Name = "lblDeviceNumberRule";
            this.lblDeviceNumberRule.Size = new System.Drawing.Size(96, 23);
            this.lblDeviceNumberRule.TabIndex = 44;
            this.lblDeviceNumberRule.Text = "设备编号规则：";
            this.lblDeviceNumberRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbDeviceNumberRule
            // 
            this.cbbDeviceNumberRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDeviceNumberRule.FormattingEnabled = true;
            this.cbbDeviceNumberRule.Items.AddRange(new object[] {
            "规律",
            "随机"});
            this.cbbDeviceNumberRule.Location = new System.Drawing.Point(592, 8);
            this.cbbDeviceNumberRule.Name = "cbbDeviceNumberRule";
            this.cbbDeviceNumberRule.Size = new System.Drawing.Size(64, 20);
            this.cbbDeviceNumberRule.TabIndex = 45;
            // 
            // lblReconnectCount
            // 
            this.lblReconnectCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReconnectCount.Location = new System.Drawing.Point(672, 8);
            this.lblReconnectCount.Name = "lblReconnectCount";
            this.lblReconnectCount.Size = new System.Drawing.Size(120, 23);
            this.lblReconnectCount.TabIndex = 46;
            this.lblReconnectCount.Text = "连接失败重连次数：";
            this.lblReconnectCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReconnectCount
            // 
            this.txtReconnectCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReconnectCount.Location = new System.Drawing.Point(800, 8);
            this.txtReconnectCount.Name = "txtReconnectCount";
            this.txtReconnectCount.Size = new System.Drawing.Size(40, 21);
            this.txtReconnectCount.TabIndex = 47;
            this.txtReconnectCount.Text = "5";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 482);
            this.Controls.Add(this.txtReconnectCount);
            this.Controls.Add(this.lblReconnectCount);
            this.Controls.Add(this.cbbDeviceNumberRule);
            this.Controls.Add(this.lblDeviceNumberRule);
            this.Controls.Add(this.lblTotalConnectedCount);
            this.Controls.Add(this.lblPerSecondAvgCount);
            this.Controls.Add(this.lblCostTime);
            this.Controls.Add(this.lblTotalCurrencyCount);
            this.Controls.Add(this.lblTotalBlacklistCount);
            this.Controls.Add(this.lblTotalLoginCount);
            this.Controls.Add(this.lblTotalHeartbeatCount);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.lblCurrencyCountMultiply);
            this.Controls.Add(this.cbAutoRefresh);
            this.Controls.Add(this.btnCreateDevice);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.rbCurrency);
            this.Controls.Add(this.rbBlacklist);
            this.Controls.Add(this.rbLogin);
            this.Controls.Add(this.rbHeartbeat);
            this.Controls.Add(this.lblTimeOutUnit);
            this.Controls.Add(this.txtTimeOut);
            this.Controls.Add(this.lblTimeOut);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtCurrencyCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.lvClientList);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblRealClientCount);
            this.Controls.Add(this.lblSendIntervalUnit);
            this.Controls.Add(this.txtSendInterval);
            this.Controls.Add(this.lblSendInterval);
            this.Controls.Add(this.txtClientCount);
            this.Controls.Add(this.lblClientCount);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "纸币流通管理系统-终端模拟工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label lblClientCount;
        private System.Windows.Forms.TextBox txtClientCount;
        private System.Windows.Forms.TextBox txtSendInterval;
        private System.Windows.Forms.Label lblSendInterval;
        private System.Windows.Forms.Label lblSendIntervalUnit;
        private System.Windows.Forms.Label lblRealClientCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvClientList;
        private System.Windows.Forms.ColumnHeader chDeviceNumber;
        private System.Windows.Forms.ColumnHeader chDeviceStatus;
        private System.Windows.Forms.ColumnHeader chBlacklistCount;
        private System.Windows.Forms.ColumnHeader chCurrencyCount;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrencyCount;
        private System.Windows.Forms.ColumnHeader chConnectMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.TextBox txtTimeOut;
        private System.Windows.Forms.Label lblTimeOutUnit;
        private System.Windows.Forms.RadioButton rbHeartbeat;
        private System.Windows.Forms.RadioButton rbLogin;
        private System.Windows.Forms.RadioButton rbBlacklist;
        private System.Windows.Forms.RadioButton rbCurrency;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.ColumnHeader chHeartbeat;
        private System.Windows.Forms.ColumnHeader chLogin;
        private System.Windows.Forms.ColumnHeader chTimeOut;
        private System.Windows.Forms.Button btnCreateDevice;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Timer timerMemoryClear;
        private System.Windows.Forms.CheckBox cbAutoRefresh;
        private System.Windows.Forms.Label lblCurrencyCountMultiply;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label lblTotalHeartbeatCount;
        private System.Windows.Forms.Label lblTotalLoginCount;
        private System.Windows.Forms.Label lblTotalBlacklistCount;
        private System.Windows.Forms.Label lblTotalCurrencyCount;
        private System.Windows.Forms.Label lblCostTime;
        private System.Windows.Forms.Timer timerTotalCount;
        private System.Windows.Forms.Label lblPerSecondAvgCount;
        private System.Windows.Forms.Label lblTotalConnectedCount;
        private System.Windows.Forms.Label lblDeviceNumberRule;
        private System.Windows.Forms.ComboBox cbbDeviceNumberRule;
        private System.Windows.Forms.Label lblReconnectCount;
        private System.Windows.Forms.TextBox txtReconnectCount;
        private System.Windows.Forms.ColumnHeader chConnectCount;
    }
}