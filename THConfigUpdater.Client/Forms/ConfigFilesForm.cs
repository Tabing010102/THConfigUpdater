﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THConfigUpdater.Client.Core.FileBased;
using THConfigUpdater.Client.Core.FileBased.Models;
using THConfigUpdater.Client.Helpers;

namespace THConfigUpdater.Client.Forms
{
    public partial class ConfigFilesForm : Form
    {
        private FileBasedConfigService _fileBasedConfigService;

        private List<ConfigFile> _configFiles;

        public FileBasedConfig FileBasedConfig { get; set; }

        public ConfigFilesForm(FileBasedConfigService fileBasedConfigService)
        {
            _fileBasedConfigService = fileBasedConfigService;

            InitializeComponent();
        }

        private async void ConfigFilesForm_Load(object sender, EventArgs e)
        {
            if (FileBasedConfig != null && FileBasedConfig.Id >= 0)
            {
                try
                {
                    this.Text += $" - {FileBasedConfig.Name}";
                    _configFiles = await _fileBasedConfigService.GetConfigFilesAsync(FileBasedConfig.Id);
                    configFilesListView.Items.Clear();
                    configFilesListView.BeginUpdate();
                    _configFiles.ForEach(c =>
                    {
                        ListViewItem item = new ListViewItem(string.Empty);
                        item.SubItems.Add(c.Id.ToString());
                        item.SubItems.Add(c.ClientPath);
                        item.SubItems.Add(SizeBytesToHRStringHelper.SizeBytesToHRString(c.Length));
                        item.SubItems.Add(c.Sha256);
                        item.SubItems.Add(c.Description);
                        configFilesListView.Items.Add(item);
                    });
                    configFilesListView.EndUpdate();

                    bool needUpdate = false;
                    foreach (ListViewItem item in configFilesListView.Items)
                    {
                        var clientPath = item.SubItems[2].Text;
                        var sha256Server = item.SubItems[4].Text;
                        if (!File.Exists(clientPath))
                        {
                            item.Text = "缺失";
                            item.BackColor = Color.LightCoral;
                            needUpdate = true;
                        }
                        else
                        {
                            var sha256 = new SHA256Managed();
                            using (var stream = File.OpenRead(clientPath))
                            {
                                var hash = sha256.ComputeHash(stream);
                                var hashString = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
                                if (hashString.ToUpper() != sha256Server.ToUpper())
                                {
                                    item.Text = "不匹配";
                                    item.BackColor = Color.LightYellow;
                                    needUpdate = true;
                                }
                                else
                                {
                                    item.Text = "无需更新";
                                    item.BackColor = Color.LightGreen;
                                }
                            }
                        }
                    }

                    if (needUpdate)
                    {
                        operationBtn.Text = "更新";
                        operationBtn.Enabled = true;
                    }
                    else
                    {
                        operationBtn.Text = "无需更新";
                        operationBtn.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    operationBtn.Text = "错误";
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void operationBtn_ClickAsync(object sender, EventArgs e)
        {
            if (operationBtn.Text == "更新")
            {
                try
                {
                    operationBtn.Text = "更新中...";
                    operationBtn.Enabled = false;
                    CustomOperationsHelper customOperationsHelper = new CustomOperationsHelper(FileBasedConfig.CustomOperations);
                    // before
                    customOperationsHelper.PerformBeforeOperations();
                    // update files
                    foreach (ListViewItem item in configFilesListView.Items)
                    {
                        var configFileId = int.Parse(item.SubItems[1].Text);
                        var clientPath = item.SubItems[2].Text;
                        var serverStream = await _fileBasedConfigService.GetConfigFileContentAsync(configFileId);
                        // ensure directory exists
                        var directory = Path.GetDirectoryName(clientPath);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }
                        using (var fileStream = File.OpenWrite(clientPath))
                        {
                            await serverStream.CopyToAsync(fileStream);
                        }
                        item.Text = "更新完成";
                        item.BackColor = Color.LightGreen;
                    }
                    // after
                    customOperationsHelper.PerformAfterOperations();
                    operationBtn.Text = "更新成功";
                    cancelBtn.Text = "关闭";
                    MessageBox.Show("更新成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
