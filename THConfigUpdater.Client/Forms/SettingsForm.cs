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

namespace THConfigUpdater.Client.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            serverAddrTextBox.Text = GlobalConfig.ServerBaseUrl;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.ServerBaseUrl = serverAddrTextBox.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
