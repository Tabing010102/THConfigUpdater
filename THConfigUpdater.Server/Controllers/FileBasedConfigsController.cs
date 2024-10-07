using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THConfigUpdater.Server.Data;
using THConfigUpdater.Server.Models;

namespace THConfigUpdater.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileBasedConfigsController : ControllerBase
    {
        private readonly THCUSDbContext _context;

        public FileBasedConfigsController(THCUSDbContext context)
        {
            _context = context;
        }

        // GET: api/FileBasedConfigs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileBasedConfig>>> GetFileBasedConfigs()
        {
            return await _context.FileBasedConfigs.ToListAsync();
        }

        // GET: api/FileBasedConfigs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileBasedConfig>> GetFileBasedConfig(int id)
        {
            var fileBasedConfig = await _context.FileBasedConfigs.FindAsync(id);

            if (fileBasedConfig == null)
            {
                return NotFound();
            }

            return fileBasedConfig;
        }

        [HttpGet("getConfigFiles/{id}")]
        public async Task<ActionResult<IEnumerable<ConfigFile>>> GetConfigFiles(int id)
        {
            var fileBasedConfig = await _context.FileBasedConfigs.SingleOrDefaultAsync(f => f.Id == id);
            if (fileBasedConfig == null)
            {
                return NotFound();
            }
            return await _context.ConfigFiles.Where(c => c.FileBasedConfigId == id).ToListAsync();
        }

        // PUT: api/FileBasedConfigs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileBasedConfig(int id, FileBasedConfig fileBasedConfig)
        {
            if (id != fileBasedConfig.Id)
            {
                return BadRequest();
            }

            _context.Entry(fileBasedConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileBasedConfigExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FileBasedConfigs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FileBasedConfig>> PostFileBasedConfig(FileBasedConfig fileBasedConfig)
        {
            _context.FileBasedConfigs.Add(fileBasedConfig);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFileBasedConfig", new { id = fileBasedConfig.Id }, fileBasedConfig);
        }

        // DELETE: api/FileBasedConfigs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileBasedConfig(int id)
        {
            var fileBasedConfig = await _context.FileBasedConfigs.FindAsync(id);
            if (fileBasedConfig == null)
            {
                return NotFound();
            }

            _context.FileBasedConfigs.Remove(fileBasedConfig);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FileBasedConfigExists(int id)
        {
            return _context.FileBasedConfigs.Any(e => e.Id == id);
        }
    }
}
