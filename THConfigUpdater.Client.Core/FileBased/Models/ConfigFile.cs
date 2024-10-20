namespace THConfigUpdater.Client.Core.FileBased.Models
{
    public class ConfigFile
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Length { get; set; }
        public string Sha256 { get; set; } = string.Empty;
        public string ClientPath { get; set; } = string.Empty;
        public string? ServerPath { get; set; }
        public string? ServerUrl { get; set; }

        public ConfigFile(int id, string fileName, string description, int length, string sha256, string clientPath, string? serverPath, string? serverUrl)
        {
            Id = id;
            FileName = fileName;
            Description = description;
            Length = length;
            Sha256 = sha256;
            ClientPath = clientPath;
            ServerPath = serverPath;
            ServerUrl = serverUrl;
        }
    }
}
