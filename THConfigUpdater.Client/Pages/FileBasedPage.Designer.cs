namespace THConfigUpdater.Client.Pages
{
    partial class FileBasedPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileBasedPage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsRefreshBtn = new System.Windows.Forms.ToolStripButton();
            this.tsUpdateConfigBtn = new System.Windows.Forms.ToolStripButton();
            this.configsListView = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRefreshBtn,
            this.tsUpdateConfigBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsRefreshBtn
            // 
            this.tsRefreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("tsRefreshBtn.Image")));
            this.tsRefreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefreshBtn.Name = "tsRefreshBtn";
            this.tsRefreshBtn.Size = new System.Drawing.Size(52, 22);
            this.tsRefreshBtn.Text = "刷新";
            this.tsRefreshBtn.Click += new System.EventHandler(this.tsRefreshBtn_ClickAsync);
            // 
            // tsUpdateConfigBtn
            // 
            this.tsUpdateConfigBtn.Image = ((System.Drawing.Image)(resources.GetObject("tsUpdateConfigBtn.Image")));
            this.tsUpdateConfigBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUpdateConfigBtn.Name = "tsUpdateConfigBtn";
            this.tsUpdateConfigBtn.Size = new System.Drawing.Size(76, 22);
            this.tsUpdateConfigBtn.Text = "更新配置";
            // 
            // configsListView
            // 
            this.configsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chName,
            this.chDescp});
            this.configsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configsListView.FullRowSelect = true;
            this.configsListView.HideSelection = false;
            this.configsListView.Location = new System.Drawing.Point(0, 25);
            this.configsListView.Name = "configsListView";
            this.configsListView.Size = new System.Drawing.Size(800, 425);
            this.configsListView.TabIndex = 1;
            this.configsListView.UseCompatibleStateImageBehavior = false;
            this.configsListView.View = System.Windows.Forms.View.Details;
            this.configsListView.DoubleClick += new System.EventHandler(this.configsListView_DoubleClick);
            // 
            // chId
            // 
            this.chId.Text = "Id";
            // 
            // chName
            // 
            this.chName.Text = "名称";
            this.chName.Width = 180;
            // 
            // chDescp
            // 
            this.chDescp.Text = "描述";
            this.chDescp.Width = 360;
            // 
            // FileBasedPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.configsListView);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileBasedPage";
            this.Text = "FileBasedPage";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsRefreshBtn;
        private System.Windows.Forms.ToolStripButton tsUpdateConfigBtn;
        private System.Windows.Forms.ListView configsListView;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chDescp;
    }
}