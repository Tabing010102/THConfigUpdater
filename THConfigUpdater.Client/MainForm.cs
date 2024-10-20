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
            var fileBasedConfigService = new FileBasedConfigService(GlobalConfig.ServerBaseUrl);
            var fileBasedPage = new FileBasedPage(fileBasedConfigService);
            mainPanel.Controls.Clear();
            fileBasedPage.TopLevel = false;
            fileBasedPage.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(fileBasedPage);
            fileBasedPage.Show();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }
    }
}
