namespace CurrencyStore.DataInit
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
            this.lblOrgCount = new System.Windows.Forms.Label();
            this.txtOrgCount = new System.Windows.Forms.TextBox();
            this.lblRelevanceDeviceCount = new System.Windows.Forms.Label();
            this.txtRelevanceDeviceCount = new System.Windows.Forms.TextBox();
            this.lblDeviceGroup = new System.Windows.Forms.Label();
            this.txtDeviceGroup = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.pbFinish = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblOrgCount
            // 
            this.lblOrgCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrgCount.Location = new System.Drawing.Point(24, 16);
            this.lblOrgCount.Name = "lblOrgCount";
            this.lblOrgCount.Size = new System.Drawing.Size(72, 23);
            this.lblOrgCount.TabIndex = 3;
            this.lblOrgCount.Text = "网点数量：";
            this.lblOrgCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrgCount
            // 
            this.txtOrgCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrgCount.Location = new System.Drawing.Point(104, 16);
            this.txtOrgCount.Name = "txtOrgCount";
            this.txtOrgCount.Size = new System.Drawing.Size(40, 21);
            this.txtOrgCount.TabIndex = 9;
            this.txtOrgCount.Text = "500";
            // 
            // lblRelevanceDeviceCount
            // 
            this.lblRelevanceDeviceCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRelevanceDeviceCount.Location = new System.Drawing.Point(160, 16);
            this.lblRelevanceDeviceCount.Name = "lblRelevanceDeviceCount";
            this.lblRelevanceDeviceCount.Size = new System.Drawing.Size(72, 23);
            this.lblRelevanceDeviceCount.TabIndex = 10;
            this.lblRelevanceDeviceCount.Text = "设备数量：";
            this.lblRelevanceDeviceCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRelevanceDeviceCount
            // 
            this.txtRelevanceDeviceCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelevanceDeviceCount.Location = new System.Drawing.Point(240, 16);
            this.txtRelevanceDeviceCount.Name = "txtRelevanceDeviceCount";
            this.txtRelevanceDeviceCount.Size = new System.Drawing.Size(40, 21);
            this.txtRelevanceDeviceCount.TabIndex = 11;
            this.txtRelevanceDeviceCount.Text = "8";
            // 
            // lblDeviceGroup
            // 
            this.lblDeviceGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeviceGroup.Location = new System.Drawing.Point(296, 16);
            this.lblDeviceGroup.Name = "lblDeviceGroup";
            this.lblDeviceGroup.Size = new System.Drawing.Size(72, 23);
            this.lblDeviceGroup.TabIndex = 12;
            this.lblDeviceGroup.Text = "设备分组：";
            this.lblDeviceGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDeviceGroup
            // 
            this.txtDeviceGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeviceGroup.Location = new System.Drawing.Point(376, 16);
            this.txtDeviceGroup.Name = "txtDeviceGroup";
            this.txtDeviceGroup.Size = new System.Drawing.Size(40, 21);
            this.txtDeviceGroup.TabIndex = 13;
            this.txtDeviceGroup.Text = "4";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(344, 48);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(72, 23);
            this.btnInit.TabIndex = 33;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // pbFinish
            // 
            this.pbFinish.Location = new System.Drawing.Point(24, 48);
            this.pbFinish.Name = "pbFinish";
            this.pbFinish.Size = new System.Drawing.Size(304, 24);
            this.pbFinish.Step = 1;
            this.pbFinish.TabIndex = 34;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 88);
            this.Controls.Add(this.pbFinish);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.txtDeviceGroup);
            this.Controls.Add(this.lblDeviceGroup);
            this.Controls.Add(this.txtRelevanceDeviceCount);
            this.Controls.Add(this.lblRelevanceDeviceCount);
            this.Controls.Add(this.txtOrgCount);
            this.Controls.Add(this.lblOrgCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "纸币流通管理系统-数据模拟工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrgCount;
        private System.Windows.Forms.TextBox txtOrgCount;
        private System.Windows.Forms.Label lblRelevanceDeviceCount;
        private System.Windows.Forms.TextBox txtRelevanceDeviceCount;
        private System.Windows.Forms.Label lblDeviceGroup;
        private System.Windows.Forms.TextBox txtDeviceGroup;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.ProgressBar pbFinish;
    }
}