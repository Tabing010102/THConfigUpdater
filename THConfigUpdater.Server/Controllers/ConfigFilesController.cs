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
    public class ConfigFilesController : ControllerBase
    {
        private readonly THCUSDbContext _context;

        public ConfigFilesController(THCUSDbContext context)
        {
            _context = context;
        }

        // GET: api/ConfigFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigFile>>> GetConfigFiles()
        {
            return await _context.ConfigFiles.ToListAsync();
        }

        // GET: api/ConfigFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigFile>> GetConfigFile(int id)
        {
            var configFile = await _context.ConfigFiles.FindAsync(id);

            if (configFile == null)
            {
                return NotFound();
            }

            return configFile;
        }

        // PUT: api/ConfigFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigFile(int id, ConfigFile configFile)
        {
            if (id != configFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(configFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigFileExists(id))
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

        // POST: api/ConfigFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfigFile>> PostConfigFile(ConfigFile configFile)
        {
            _context.ConfigFiles.Add(configFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigFile", new { id = configFile.Id }, configFile);
        }

        // DELETE: api/ConfigFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfigFile(int id)
        {
            var configFile = await _context.ConfigFiles.FindAsync(id);
            if (configFile == null)
            {
                return NotFound();
            }

            _context.ConfigFiles.Remove(configFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfigFileExists(int id)
        {
            return _context.ConfigFiles.Any(e => e.Id == id);
        }
    }
}
