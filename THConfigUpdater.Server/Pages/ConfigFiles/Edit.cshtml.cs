using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using THConfigUpdater.Server.Configs;
using THConfigUpdater.Server.Data;
using THConfigUpdater.Server.Models;

namespace THConfigUpdater.Server.Pages.ConfigFiles
{
    public class EditModel : PageModel
    {
        private readonly THConfigUpdater.Server.Data.THCUSDbContext _context;
        private readonly FSConfig _fsConfig;

        public EditModel(THConfigUpdater.Server.Data.THCUSDbContext context, FSConfig fsConfig)
        {
            _context = context;
            _fsConfig = fsConfig;
        }

        [BindProperty]
        public ConfigFile ConfigFile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configfile =  await _context.ConfigFiles.FirstOrDefaultAsync(m => m.Id == id);
            if (configfile == null)
            {
                return NotFound();
            }
            ConfigFile = configfile;
            ViewData["FileBasedConfigId"] = new SelectList(_context.FileBasedConfigs, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["FileBasedConfigId"] = new SelectList(_context.FileBasedConfigs, "Id", "Id");
                return Page();
            }

            if (ConfigFile.ServerPath == null && ConfigFile.ServerUrl == null)
            {
                ModelState.AddModelError(string.Empty, "ServerPath and ServerUrl cannot be null.");
            }
            if (ConfigFile.ServerUrl == null)
            {
                try
                {
                    string filePath;
                    if (Path.IsPathRooted(ConfigFile.ServerPath))
                    {
                        filePath = ConfigFile.ServerPath;
                    }
                    else
                    {
                        filePath = Path.Combine(_fsConfig.ConfigFilesBasePath, ConfigFile.ServerPath!);
                    }
                    using var sha256 = SHA256.Create();
                    using var fs = System.IO.File.OpenRead(filePath);
                    var fileSha256 = await sha256.ComputeHashAsync(fs);
                    ConfigFile.Sha256 = Convert.ToHexString(fileSha256);
                    ConfigFile.Length = (int)new FileInfo(filePath).Length;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error during reading file: {ex.Message}");
                    ViewData["FileBasedConfigId"] = new SelectList(_context.FileBasedConfigs, "Id", "Id");
                    return Page();
                }
            }

            _context.Attach(ConfigFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigFileExists(ConfigFile.Id))
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

        private bool ConfigFileExists(int id)
        {
            return _context.ConfigFiles.Any(e => e.Id == id);
        }
    }
}
