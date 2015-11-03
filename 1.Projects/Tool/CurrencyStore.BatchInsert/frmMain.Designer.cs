namespace CurrencyStore.BatchInsert
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
            this.lblDataTotalCount = new System.Windows.Forms.Label();
            this.txtClientCount = new System.Windows.Forms.TextBox();
            this.lblBatchCount = new System.Windows.Forms.Label();
            this.txtBatchCount = new System.Windows.Forms.TextBox();
            this.txtCurrencyCount = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.lblClientCountUnit = new System.Windows.Forms.Label();
            this.lblCurrencyCountUnit = new System.Windows.Forms.Label();
            this.lblDayUnit = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.lblBatchCountUnit = new System.Windows.Forms.Label();
            this.lblTotalCostTime = new System.Windows.Forms.Label();
            this.lblRealInsertDataCount = new System.Windows.Forms.Label();
            this.lblTotalCostTimeValue = new System.Windows.Forms.Label();
            this.lblRealInsertDataCountValue = new System.Windows.Forms.Label();
            this.cbInsertCurrencyImage = new System.Windows.Forms.CheckBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.lblAvgPerSecondInsertCount = new System.Windows.Forms.Label();
            this.lblAvgPerSecondInsertCountValue = new System.Windows.Forms.Label();
            this.lblRealClientCount = new System.Windows.Forms.Label();
            this.lblMaxPerSecondInsertCount = new System.Windows.Forms.Label();
            this.lblMaxPerSecondInsertCountValue = new System.Windows.Forms.Label();
            this.btnStartInsert = new System.Windows.Forms.Button();
            this.lblCurrentSecondInsertCount = new System.Windows.Forms.Label();
            this.lblCurrentSecondInsertCountValue = new System.Windows.Forms.Label();
            this.timerMemoryClear = new System.Windows.Forms.Timer(this.components);
            this.btnChart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDataTotalCount
            // 
            this.lblDataTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataTotalCount.Location = new System.Drawing.Point(16, 16);
            this.lblDataTotalCount.Name = "lblDataTotalCount";
            this.lblDataTotalCount.Size = new System.Drawing.Size(72, 23);
            this.lblDataTotalCount.TabIndex = 2;
            this.lblDataTotalCount.Text = "数据总量：";
            this.lblDataTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClientCount
            // 
            this.txtClientCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientCount.Location = new System.Drawing.Point(96, 16);
            this.txtClientCount.Name = "txtClientCount";
            this.txtClientCount.Size = new System.Drawing.Size(48, 21);
            this.txtClientCount.TabIndex = 8;
            this.txtClientCount.Text = "100";
            // 
            // lblBatchCount
            // 
            this.lblBatchCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBatchCount.Location = new System.Drawing.Point(16, 48);
            this.lblBatchCount.Name = "lblBatchCount";
            this.lblBatchCount.Size = new System.Drawing.Size(72, 23);
            this.lblBatchCount.TabIndex = 9;
            this.lblBatchCount.Text = "单批数量：";
            this.lblBatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBatchCount
            // 
            this.txtBatchCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchCount.Location = new System.Drawing.Point(96, 48);
            this.txtBatchCount.Name = "txtBatchCount";
            this.txtBatchCount.Size = new System.Drawing.Size(48, 21);
            this.txtBatchCount.TabIndex = 10;
            this.txtBatchCount.Text = "1000";
            // 
            // txtCurrencyCount
            // 
            this.txtCurrencyCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrencyCount.Location = new System.Drawing.Point(176, 16);
            this.txtCurrencyCount.Name = "txtCurrencyCount";
            this.txtCurrencyCount.Size = new System.Drawing.Size(48, 21);
            this.txtCurrencyCount.TabIndex = 11;
            this.txtCurrencyCount.Text = "20000";
            // 
            // txtDay
            // 
            this.txtDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDay.Location = new System.Drawing.Point(256, 16);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(48, 21);
            this.txtDay.TabIndex = 12;
            this.txtDay.Text = "1";
            // 
            // lblClientCountUnit
            // 
            this.lblClientCountUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientCountUnit.Location = new System.Drawing.Point(152, 16);
            this.lblClientCountUnit.Name = "lblClientCountUnit";
            this.lblClientCountUnit.Size = new System.Drawing.Size(16, 23);
            this.lblClientCountUnit.TabIndex = 13;
            this.lblClientCountUnit.Text = "台";
            this.lblClientCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrencyCountUnit
            // 
            this.lblCurrencyCountUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrencyCountUnit.Location = new System.Drawing.Point(232, 16);
            this.lblCurrencyCountUnit.Name = "lblCurrencyCountUnit";
            this.lblCurrencyCountUnit.Size = new System.Drawing.Size(16, 23);
            this.lblCurrencyCountUnit.TabIndex = 14;
            this.lblCurrencyCountUnit.Text = "张";
            this.lblCurrencyCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayUnit
            // 
            this.lblDayUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDayUnit.Location = new System.Drawing.Point(312, 16);
            this.lblDayUnit.Name = "lblDayUnit";
            this.lblDayUnit.Size = new System.Drawing.Size(16, 23);
            this.lblDayUnit.TabIndex = 15;
            this.lblDayUnit.Text = "天";
            this.lblDayUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(312, 48);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(72, 23);
            this.btnInit.TabIndex = 32;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // lblBatchCountUnit
            // 
            this.lblBatchCountUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBatchCountUnit.Location = new System.Drawing.Point(152, 48);
            this.lblBatchCountUnit.Name = "lblBatchCountUnit";
            this.lblBatchCountUnit.Size = new System.Drawing.Size(16, 23);
            this.lblBatchCountUnit.TabIndex = 34;
            this.lblBatchCountUnit.Text = "张";
            this.lblBatchCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCostTime
            // 
            this.lblTotalCostTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCostTime.Location = new System.Drawing.Point(16, 80);
            this.lblTotalCostTime.Name = "lblTotalCostTime";
            this.lblTotalCostTime.Size = new System.Drawing.Size(96, 23);
            this.lblTotalCostTime.TabIndex = 35;
            this.lblTotalCostTime.Text = "总耗时：";
            this.lblTotalCostTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRealInsertDataCount
            // 
            this.lblRealInsertDataCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRealInsertDataCount.Location = new System.Drawing.Point(16, 112);
            this.lblRealInsertDataCount.Name = "lblRealInsertDataCount";
            this.lblRealInsertDataCount.Size = new System.Drawing.Size(96, 23);
            this.lblRealInsertDataCount.TabIndex = 38;
            this.lblRealInsertDataCount.Text = "已插入数据量：";
            this.lblRealInsertDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCostTimeValue
            // 
            this.lblTotalCostTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCostTimeValue.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalCostTimeValue.Location = new System.Drawing.Point(120, 80);
            this.lblTotalCostTimeValue.Name = "lblTotalCostTimeValue";
            this.lblTotalCostTimeValue.Size = new System.Drawing.Size(120, 24);
            this.lblTotalCostTimeValue.TabIndex = 39;
            this.lblTotalCostTimeValue.Text = "00:00:00";
            this.lblTotalCostTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRealInsertDataCountValue
            // 
            this.lblRealInsertDataCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRealInsertDataCountValue.ForeColor = System.Drawing.Color.Blue;
            this.lblRealInsertDataCountValue.Location = new System.Drawing.Point(120, 112);
            this.lblRealInsertDataCountValue.Name = "lblRealInsertDataCountValue";
            this.lblRealInsertDataCountValue.Size = new System.Drawing.Size(120, 23);
            this.lblRealInsertDataCountValue.TabIndex = 42;
            this.lblRealInsertDataCountValue.Text = "0";
            this.lblRealInsertDataCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbInsertCurrencyImage
            // 
            this.cbInsertCurrencyImage.Checked = true;
            this.cbInsertCurrencyImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbInsertCurrencyImage.Location = new System.Drawing.Point(176, 48);
            this.cbInsertCurrencyImage.Name = "cbInsertCurrencyImage";
            this.cbInsertCurrencyImage.Size = new System.Drawing.Size(96, 24);
            this.cbInsertCurrencyImage.TabIndex = 43;
            this.cbInsertCurrencyImage.Text = "插入纸币图像";
            this.cbInsertCurrencyImage.UseVisualStyleBackColor = true;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 1000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // lblAvgPerSecondInsertCount
            // 
            this.lblAvgPerSecondInsertCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvgPerSecondInsertCount.Location = new System.Drawing.Point(16, 176);
            this.lblAvgPerSecondInsertCount.Name = "lblAvgPerSecondInsertCount";
            this.lblAvgPerSecondInsertCount.Size = new System.Drawing.Size(96, 23);
            this.lblAvgPerSecondInsertCount.TabIndex = 44;
            this.lblAvgPerSecondInsertCount.Text = "平均每秒插入：";
            this.lblAvgPerSecondInsertCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAvgPerSecondInsertCountValue
            // 
            this.lblAvgPerSecondInsertCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvgPerSecondInsertCountValue.ForeColor = System.Drawing.Color.Blue;
            this.lblAvgPerSecondInsertCountValue.Location = new System.Drawing.Point(120, 176);
            this.lblAvgPerSecondInsertCountValue.Name = "lblAvgPerSecondInsertCountValue";
            this.lblAvgPerSecondInsertCountValue.Size = new System.Drawing.Size(120, 23);
            this.lblAvgPerSecondInsertCountValue.TabIndex = 45;
            this.lblAvgPerSecondInsertCountValue.Text = "0";
            this.lblAvgPerSecondInsertCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRealClientCount
            // 
            this.lblRealClientCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRealClientCount.ForeColor = System.Drawing.Color.Blue;
            this.lblRealClientCount.Location = new System.Drawing.Point(336, 16);
            this.lblRealClientCount.Name = "lblRealClientCount";
            this.lblRealClientCount.Size = new System.Drawing.Size(48, 23);
            this.lblRealClientCount.TabIndex = 46;
            this.lblRealClientCount.Text = "0";
            this.lblRealClientCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaxPerSecondInsertCount
            // 
            this.lblMaxPerSecondInsertCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxPerSecondInsertCount.Location = new System.Drawing.Point(16, 208);
            this.lblMaxPerSecondInsertCount.Name = "lblMaxPerSecondInsertCount";
            this.lblMaxPerSecondInsertCount.Size = new System.Drawing.Size(96, 23);
            this.lblMaxPerSecondInsertCount.TabIndex = 47;
            this.lblMaxPerSecondInsertCount.Text = "最大每秒插入：";
            this.lblMaxPerSecondInsertCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaxPerSecondInsertCountValue
            // 
            this.lblMaxPerSecondInsertCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxPerSecondInsertCountValue.ForeColor = System.Drawing.Color.Blue;
            this.lblMaxPerSecondInsertCountValue.Location = new System.Drawing.Point(120, 208);
            this.lblMaxPerSecondInsertCountValue.Name = "lblMaxPerSecondInsertCountValue";
            this.lblMaxPerSecondInsertCountValue.Size = new System.Drawing.Size(120, 23);
            this.lblMaxPerSecondInsertCountValue.TabIndex = 48;
            this.lblMaxPerSecondInsertCountValue.Text = "0";
            this.lblMaxPerSecondInsertCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStartInsert
            // 
            this.btnStartInsert.Location = new System.Drawing.Point(312, 80);
            this.btnStartInsert.Name = "btnStartInsert";
            this.btnStartInsert.Size = new System.Drawing.Size(72, 23);
            this.btnStartInsert.TabIndex = 49;
            this.btnStartInsert.Text = "开始插入";
            this.btnStartInsert.UseVisualStyleBackColor = true;
            this.btnStartInsert.Click += new System.EventHandler(this.btnStartInsert_Click);
            // 
            // lblCurrentSecondInsertCount
            // 
            this.lblCurrentSecondInsertCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentSecondInsertCount.Location = new System.Drawing.Point(16, 144);
            this.lblCurrentSecondInsertCount.Name = "lblCurrentSecondInsertCount";
            this.lblCurrentSecondInsertCount.Size = new System.Drawing.Size(96, 23);
            this.lblCurrentSecondInsertCount.TabIndex = 50;
            this.lblCurrentSecondInsertCount.Text = "当前每秒插入：";
            this.lblCurrentSecondInsertCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentSecondInsertCountValue
            // 
            this.lblCurrentSecondInsertCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentSecondInsertCountValue.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentSecondInsertCountValue.Location = new System.Drawing.Point(120, 144);
            this.lblCurrentSecondInsertCountValue.Name = "lblCurrentSecondInsertCountValue";
            this.lblCurrentSecondInsertCountValue.Size = new System.Drawing.Size(120, 23);
            this.lblCurrentSecondInsertCountValue.TabIndex = 51;
            this.lblCurrentSecondInsertCountValue.Text = "0";
            this.lblCurrentSecondInsertCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerMemoryClear
            // 
            this.timerMemoryClear.Enabled = true;
            this.timerMemoryClear.Interval = 5000;
            this.timerMemoryClear.Tick += new System.EventHandler(this.timerMemoryClear_Tick);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(312, 112);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(72, 23);
            this.btnChart.TabIndex = 52;
            this.btnChart.Text = "图表分析";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 238);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.lblCurrentSecondInsertCountValue);
            this.Controls.Add(this.lblCurrentSecondInsertCount);
            this.Controls.Add(this.btnStartInsert);
            this.Controls.Add(this.lblMaxPerSecondInsertCountValue);
            this.Controls.Add(this.lblMaxPerSecondInsertCount);
            this.Controls.Add(this.lblRealClientCount);
            this.Controls.Add(this.lblAvgPerSecondInsertCountValue);
            this.Controls.Add(this.lblAvgPerSecondInsertCount);
            this.Controls.Add(this.cbInsertCurrencyImage);
            this.Controls.Add(this.lblRealInsertDataCountValue);
            this.Controls.Add(this.lblTotalCostTimeValue);
            this.Controls.Add(this.lblRealInsertDataCount);
            this.Controls.Add(this.lblTotalCostTime);
            this.Controls.Add(this.lblBatchCountUnit);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.lblDayUnit);
            this.Controls.Add(this.lblCurrencyCountUnit);
            this.Controls.Add(this.lblClientCountUnit);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.txtCurrencyCount);
            this.Controls.Add(this.txtBatchCount);
            this.Controls.Add(this.lblBatchCount);
            this.Controls.Add(this.txtClientCount);
            this.Controls.Add(this.lblDataTotalCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "纸币流通管理系统-数据批量插入测试工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataTotalCount;
        private System.Windows.Forms.TextBox txtClientCount;
        private System.Windows.Forms.Label lblBatchCount;
        private System.Windows.Forms.TextBox txtBatchCount;
        private System.Windows.Forms.TextBox txtCurrencyCount;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label lblClientCountUnit;
        private System.Windows.Forms.Label lblCurrencyCountUnit;
        private System.Windows.Forms.Label lblDayUnit;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label lblBatchCountUnit;
        private System.Windows.Forms.Label lblTotalCostTime;
        private System.Windows.Forms.Label lblRealInsertDataCount;
        private System.Windows.Forms.Label lblTotalCostTimeValue;
        private System.Windows.Forms.Label lblRealInsertDataCountValue;
        private System.Windows.Forms.CheckBox cbInsertCurrencyImage;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Label lblAvgPerSecondInsertCount;
        private System.Windows.Forms.Label lblAvgPerSecondInsertCountValue;
        private System.Windows.Forms.Label lblRealClientCount;
        private System.Windows.Forms.Label lblMaxPerSecondInsertCount;
        private System.Windows.Forms.Label lblMaxPerSecondInsertCountValue;
        private System.Windows.Forms.Button btnStartInsert;
        private System.Windows.Forms.Label lblCurrentSecondInsertCount;
        private System.Windows.Forms.Label lblCurrentSecondInsertCountValue;
        private System.Windows.Forms.Timer timerMemoryClear;
        private System.Windows.Forms.Button btnChart;
    }
}