using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace THConfigUpdater.Server.Models
{
    public class ConfigFile
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Length { get; set; }
        public string Sha256 { get; set; } = string.Empty;
        public string ClientPath { get; set; } = string.Empty;
        public string? ServerPath { get; set; }
        public string? ServerUrl { get; set; }
        // one-to-many relation
        public int FileBasedConfigId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public FileBasedConfig FileBasedConfig { get; set; } = null!;
    }
}
