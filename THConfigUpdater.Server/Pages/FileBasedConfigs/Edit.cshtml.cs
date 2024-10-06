using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using THConfigUpdater.Server.Data;
using THConfigUpdater.Server.Models;

namespace THConfigUpdater.Server.Pages.FileBasedConfigs
{
    public class EditModel : PageModel
    {
        private readonly THConfigUpdater.Server.Data.THCUSDbContext _context;

        public EditModel(THConfigUpdater.Server.Data.THCUSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileBasedConfig FileBasedConfig { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filebasedconfig =  await _context.FileBasedConfigs.FirstOrDefaultAsync(m => m.Id == id);
            if (filebasedconfig == null)
            {
                return NotFound();
            }
            FileBasedConfig = filebasedconfig;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FileBasedConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileBasedConfigExists(FileBasedConfig.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FileBasedConfigExists(int id)
        {
            return _context.FileBasedConfigs.Any(e => e.Id == id);
        }
    }
}
