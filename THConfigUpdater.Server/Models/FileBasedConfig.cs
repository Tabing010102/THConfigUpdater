using System.ComponentModel.DataAnnotations;

namespace THConfigUpdater.Server.Models
{
    public class FileBasedConfig
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ConfigFile> ConfigFiles { get; } = [];
    }
}
