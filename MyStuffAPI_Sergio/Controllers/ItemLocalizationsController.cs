using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStuffAPI_Sergio.Models;
using MyStuffAPI_Sergio.Attributes;

namespace MyStuffAPI_Sergio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ItemLocalizationsController : ControllerBase
    {
        private readonly MyStuffDBContext _context;

        public ItemLocalizationsController(MyStuffDBContext context)
        {
            _context = context;
        }

        // GET: api/ItemLocalizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemLocalization>>> GetItemLocalizations()
        {
            return await _context.ItemLocalizations.ToListAsync();
        }

        // GET: api/ItemLocalizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemLocalization>> GetItemLocalization(int id)
        {
            var itemLocalization = await _context.ItemLocalizations.FindAsync(id);

            if (itemLocalization == null)
            {
                return NotFound();
            }

            return itemLocalization;
        }

        // PUT: api/ItemLocalizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemLocalization(int id, ItemLocalization itemLocalization)
        {
            if (id != itemLocalization.ItemLocalizationId)
            {
                return BadRequest();
            }

            _context.Entry(itemLocalization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemLocalizationExists(id))
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

        // POST: api/ItemLocalizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemLocalization>> PostItemLocalization(ItemLocalization itemLocalization)
        {
            _context.ItemLocalizations.Add(itemLocalization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemLocalization", new { id = itemLocalization.ItemLocalizationId }, itemLocalization);
        }

        // DELETE: api/ItemLocalizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemLocalization(int id)
        {
            var itemLocalization = await _context.ItemLocalizations.FindAsync(id);
            if (itemLocalization == null)
            {
                return NotFound();
            }

            _context.ItemLocalizations.Remove(itemLocalization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemLocalizationExists(int id)
        {
            return _context.ItemLocalizations.Any(e => e.ItemLocalizationId == id);
        }
    }
}
