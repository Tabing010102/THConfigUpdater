namespace THConfigUpdater.Client.Core.FileBased.Models
{
    public class FileBasedConfig
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CustomOperations { get; set; } = string.Empty;

        public FileBasedConfig(int id, string name, string description, string customOperations)
        {
            Id = id;
            Name = name;
            Description = description;
            CustomOperations = customOperations;
        }
    }
}
