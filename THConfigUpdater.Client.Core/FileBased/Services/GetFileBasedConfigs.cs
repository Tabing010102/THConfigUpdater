using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using THConfigUpdater.Client.Core.FileBased.Models;

namespace THConfigUpdater.Client.Core.FileBased
{
    public partial class FileBasedConfigService
    {
        public async Task<List<FileBasedConfig>?> GetFileBasedConfigsAsync(CancellationToken ct = default)
        {
            return await _restClient.GetAsync<List<FileBasedConfig>>("FileBasedConfigs", ct);
        }

        public async Task<List<ConfigFile>?> GetConfigFilesAsync(int fileBasedConfigId, CancellationToken ct = default)
        {
            return await _restClient.GetAsync<List<ConfigFile>>($"FileBasedConfigs/getConfigFiles/{fileBasedConfigId}", ct);
        }

        public async Task<Stream?> GetConfigFileContentAsync(int configFileId, CancellationToken ct = default)
        {
            return await _restClient.DownloadStreamAsync(new RestRequest($"ConfigFiles/getFile/{configFileId}"), ct);
        }
    }
}
