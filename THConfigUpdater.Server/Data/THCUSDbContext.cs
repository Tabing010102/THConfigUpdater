using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using THConfigUpdater.Server.Models;

namespace THConfigUpdater.Server.Data
{
    public class THCUSDbContext : DbContext
    {
        public THCUSDbContext (DbContextOptions<THCUSDbContext> options)
            : base(options)
        {
        }

        public DbSet<THConfigUpdater.Server.Models.FileBasedConfig> FileBasedConfigs { get; set; } = default!;
        public DbSet<THConfigUpdater.Server.Models.ConfigFile> ConfigFiles { get; set; } = default!;
    }
}
