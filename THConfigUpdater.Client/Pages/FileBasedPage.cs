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

        private bool _isRefreshing = false;

        public FileBasedPage(FileBasedConfigService fileBasedConfigService)
        {
            _fileBasedConfigService = fileBasedConfigService;

            InitializeComponent();
        }

        private async Task RefreshFileBasedConfigs()
        {
            if (!_isRefreshing)
            {
                try
                {
                    configsListView.Items.Clear();
                    var rItem = new ListViewItem(string.Empty);
                    rItem.SubItems.Add("正在刷新...");
                    configsListView.Items.Add(rItem);
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
                finally
                {
                    _isRefreshing = false;
                }
            }
        }

        private async void tsRefreshBtn_ClickAsync(object sender, EventArgs e)
        {
            await RefreshFileBasedConfigs();
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

        private async void FileBasedPage_Load(object sender, EventArgs e)
        {
            await RefreshFileBasedConfigs();
        }

        private void tsUpdateConfigBtn_Click(object sender, EventArgs e)
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
