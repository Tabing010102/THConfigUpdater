namespace THConfigUpdater.Client.Forms
{
    partial class ConfigFilesForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.configFilesListView = new System.Windows.Forms.ListView();
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClientPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSha256 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.operationBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.configFilesListView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.operationBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancelBtn, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 330);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // configFilesListView
            // 
            this.configFilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chStatus,
            this.chId,
            this.chClientPath,
            this.chLength,
            this.chSha256,
            this.chDescp});
            this.tableLayoutPanel1.SetColumnSpan(this.configFilesListView, 3);
            this.configFilesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configFilesListView.FullRowSelect = true;
            this.configFilesListView.HideSelection = false;
            this.configFilesListView.Location = new System.Drawing.Point(15, 15);
            this.configFilesListView.Margin = new System.Windows.Forms.Padding(15);
            this.configFilesListView.Name = "configFilesListView";
            this.configFilesListView.Size = new System.Drawing.Size(670, 234);
            this.configFilesListView.TabIndex = 0;
            this.configFilesListView.UseCompatibleStateImageBehavior = false;
            this.configFilesListView.View = System.Windows.Forms.View.Details;
            // 
            // chStatus
            // 
            this.chStatus.Text = "状态";
            // 
            // chId
            // 
            this.chId.Text = "Id";
            this.chId.Width = 40;
            // 
            // chClientPath
            // 
            this.chClientPath.Text = "路径";
            this.chClientPath.Width = 150;
            // 
            // chLength
            // 
            this.chLength.Text = "文件大小";
            this.chLength.Width = 80;
            // 
            // chSha256
            // 
            this.chSha256.Text = "SHA256校验和";
            this.chSha256.Width = 120;
            // 
            // chDescp
            // 
            this.chDescp.Text = "描述";
            this.chDescp.Width = 150;
            // 
            // operationBtn
            // 
            this.operationBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.operationBtn.Enabled = false;
            this.operationBtn.Location = new System.Drawing.Point(237, 285);
            this.operationBtn.Name = "operationBtn";
            this.operationBtn.Size = new System.Drawing.Size(75, 23);
            this.operationBtn.TabIndex = 1;
            this.operationBtn.Text = "请稍候...";
            this.operationBtn.UseVisualStyleBackColor = true;
            this.operationBtn.Click += new System.EventHandler(this.operationBtn_ClickAsync);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cancelBtn.Location = new System.Drawing.Point(388, 285);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ConfigFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 330);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigFilesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigFilesForm";
            this.Load += new System.EventHandler(this.ConfigFilesForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView configFilesListView;
        private System.Windows.Forms.Button operationBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chDescp;
        private System.Windows.Forms.ColumnHeader chClientPath;
        private System.Windows.Forms.ColumnHeader chLength;
        private System.Windows.Forms.ColumnHeader chSha256;
        private System.Windows.Forms.ColumnHeader chStatus;
    }
}