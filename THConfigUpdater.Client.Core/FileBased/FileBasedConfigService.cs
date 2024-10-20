using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace THConfigUpdater.Client.Core.FileBased
{
    public partial class FileBasedConfigService
    {
        private readonly RestClient _restClient;

        public FileBasedConfigService(string serverBaseUrl)
        {
            _restClient = new RestClient(new RestClientOptions(serverBaseUrl + "/api/")
            {
                Timeout = TimeSpan.FromSeconds(5)
            });
        }
    }
}
