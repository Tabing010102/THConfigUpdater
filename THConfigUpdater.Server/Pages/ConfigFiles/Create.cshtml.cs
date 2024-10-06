using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using THConfigUpdater.Server.Data;
using THConfigUpdater.Server.Models;

namespace THConfigUpdater.Server.Pages.ConfigFiles
{
    public class CreateModel : PageModel
    {
        private readonly THConfigUpdater.Server.Data.THCUSDbContext _context;

        public CreateModel(THConfigUpdater.Server.Data.THCUSDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FileBasedConfigId"] = new SelectList(_context.FileBasedConfigs, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ConfigFile ConfigFile { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ConfigFiles.Add(ConfigFile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
