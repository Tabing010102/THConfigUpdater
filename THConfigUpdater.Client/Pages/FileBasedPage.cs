﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THConfigUpdater.Client.Core.FileBased;
using THConfigUpdater.Client.Core.FileBased.Models;
using THConfigUpdater.Client.Forms;

namespace THConfigUpdater.Client.Pages
{
    public partial class FileBasedPage : Form
    {
        private FileBasedConfigService _fileBasedConfigService;

        private bool _isRefreshing = false;
        private List<FileBasedConfig> _fileBasedConfigs = new List<FileBasedConfig>();

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
                    rItem.SubItems.Add("正在更新...");
                    configsListView.Items.Add(rItem);
                    _fileBasedConfigs.Clear();
                    _fileBasedConfigs = await _fileBasedConfigService.GetFileBasedConfigsAsync();
                    configsListView.Items.Clear();
                    configsListView.BeginUpdate();
                    _fileBasedConfigs.ForEach(c =>
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
                    configsListView.Items[0].SubItems[1].Text = "更新失败";
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
            if (configsListView.SelectedItems.Count == 1 && configsListView.SelectedItems[0].Text != string.Empty)
            {
                ConfigFilesForm configFilesForm = new ConfigFilesForm(_fileBasedConfigService)
                {
                    FileBasedConfig = _fileBasedConfigs.Single(x => x.Id == int.Parse(configsListView.SelectedItems[0].Text))
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
            if (configsListView.SelectedItems.Count == 1 && configsListView.SelectedItems[0].Text != string.Empty)
            {
                ConfigFilesForm configFilesForm = new ConfigFilesForm(_fileBasedConfigService)
                {
                    FileBasedConfig = _fileBasedConfigs.Single(x => x.Id == int.Parse(configsListView.SelectedItems[0].Text))
                };
                configFilesForm.ShowDialog(this);
            }
        }
    }
}
