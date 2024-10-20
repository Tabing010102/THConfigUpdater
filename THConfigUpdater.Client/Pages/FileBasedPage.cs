using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THConfigUpdater.Client.Core.FileBased;
using THConfigUpdater.Client.Forms;

namespace THConfigUpdater.Client.Pages
{
    public partial class FileBasedPage : Form
    {
        private FileBasedConfigService _fileBasedConfigService;

        public FileBasedPage(FileBasedConfigService fileBasedConfigService)
        {
            _fileBasedConfigService = fileBasedConfigService;

            InitializeComponent();
        }

        private async void tsRefreshBtn_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var configs = await _fileBasedConfigService.GetFileBasedConfigsAsync();
                configsListView.Items.Clear();
                configsListView.BeginUpdate();
                configs.ForEach(c =>
                {
                    ListViewItem item = new ListViewItem(c.Id.ToString());
                    item.SubItems.Add(c.Name);
                    item.SubItems.Add(c.Description);
                    configsListView.Items.Add(item);
                });
                configsListView.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configsListView_DoubleClick(object sender, EventArgs e)
        {
            if (configsListView.SelectedItems.Count == 1)
            {
                ConfigFilesForm configFilesForm = new ConfigFilesForm(_fileBasedConfigService)
                {
                    FileBasedConfigId = int.Parse(configsListView.SelectedItems[0].Text)
                };
                configFilesForm.ShowDialog(this);
            }
        }
    }
}
