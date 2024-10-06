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
    public class DetailsModel : PageModel
    {
        private readonly THConfigUpdater.Server.Data.THCUSDbContext _context;

        public DetailsModel(THConfigUpdater.Server.Data.THCUSDbContext context)
        {
            _context = context;
        }

        public FileBasedConfig FileBasedConfig { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filebasedconfig = await _context.FileBasedConfigs.Include(x => x.ConfigFiles).FirstOrDefaultAsync(m => m.Id == id);
            if (filebasedconfig == null)
            {
                return NotFound();
            }
            else
            {
                FileBasedConfig = filebasedconfig;
            }
            return Page();
        }
    }
}
