using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THConfigUpdater.Client.Configs;
using THConfigUpdater.Client.Core.FileBased;
using THConfigUpdater.Client.Forms;
using THConfigUpdater.Client.Pages;

namespace THConfigUpdater.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = $"TuiHub 配置更新程序 - {GlobalConfig.ServerBaseUrl}";
            ShowFileBasedPage();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
            this.Text = $"TuiHub 配置更新程序 - {GlobalConfig.ServerBaseUrl}";
            ShowFileBasedPage();
        }

        private void 基于文件的配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileBasedPage();
        }

        private void ShowFileBasedPage()
        {
            var fileBasedConfigService = new FileBasedConfigService(GlobalConfig.ServerBaseUrl);
            var fileBasedPage = new FileBasedPage(fileBasedConfigService);
            mainPanel.Controls.Clear();
            fileBasedPage.TopLevel = false;
            fileBasedPage.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(fileBasedPage);
            fileBasedPage.Show();
        }
    }
}
