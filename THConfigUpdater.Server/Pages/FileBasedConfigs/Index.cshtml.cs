using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using THConfigUpdater.Server.Data;
using THConfigUpdater.Server.Models;

namespace THConfigUpdater.Server.Pages.FileBasedConfigs
{
    public class IndexModel : PageModel
    {
        private readonly THConfigUpdater.Server.Data.THCUSDbContext _context;

        public IndexModel(THConfigUpdater.Server.Data.THCUSDbContext context)
        {
            _context = context;
        }

        public IList<FileBasedConfig> FileBasedConfig { get;set; } = default!;

        public async Task OnGetAsync()
        {
            FileBasedConfig = await _context.FileBasedConfigs.Include(x => x.ConfigFiles).ToListAsync();
        }
    }
}
