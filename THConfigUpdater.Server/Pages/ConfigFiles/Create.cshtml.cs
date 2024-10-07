using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using THConfigUpdater.Server.Configs;
using THConfigUpdater.Server.Data;
using THConfigUpdater.Server.Models;

namespace THConfigUpdater.Server.Pages.ConfigFiles
{
    public class CreateModel : PageModel
    {
        private readonly THConfigUpdater.Server.Data.THCUSDbContext _context;
        private readonly FSConfig _fsConfig;

        public CreateModel(THConfigUpdater.Server.Data.THCUSDbContext context, FSConfig fsConfig)
        {
            _context = context;
            _fsConfig = fsConfig;
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

            _context.ConfigFiles.Add(ConfigFile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
