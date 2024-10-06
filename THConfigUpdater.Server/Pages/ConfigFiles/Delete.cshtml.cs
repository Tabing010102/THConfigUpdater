using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using THConfigUpdater.Server.Data;
using THConfigUpdater.Server.Models;

namespace THConfigUpdater.Server.Pages.ConfigFiles
{
    public class DeleteModel : PageModel
    {
        private readonly THConfigUpdater.Server.Data.THCUSDbContext _context;

        public DeleteModel(THConfigUpdater.Server.Data.THCUSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ConfigFile ConfigFile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configfile = await _context.ConfigFiles.FirstOrDefaultAsync(m => m.Id == id);

            if (configfile == null)
            {
                return NotFound();
            }
            else
            {
                ConfigFile = configfile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configfile = await _context.ConfigFiles.FindAsync(id);
            if (configfile != null)
            {
                ConfigFile = configfile;
                _context.ConfigFiles.Remove(ConfigFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
