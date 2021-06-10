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
    public class MultimediumsController : ControllerBase
    {
        private readonly MyStuffDBContext _context;

        public MultimediumsController(MyStuffDBContext context)
        {
            _context = context;
        }

        // GET: api/Multimediums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Multimedium>>> GetMultimedia()
        {
            return await _context.Multimedia.ToListAsync();
        }

        // GET: api/Multimediums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Multimedium>> GetMultimedium(int id)
        {
            var multimedium = await _context.Multimedia.FindAsync(id);

            if (multimedium == null)
            {
                return NotFound();
            }

            return multimedium;
        }

        // PUT: api/Multimediums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultimedium(int id, Multimedium multimedium)
        {
            if (id != multimedium.MultimediaId)
            {
                return BadRequest();
            }

            _context.Entry(multimedium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultimediumExists(id))
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

        // POST: api/Multimediums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Multimedium>> PostMultimedium(Multimedium multimedium)
        {
            _context.Multimedia.Add(multimedium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMultimedium", new { id = multimedium.MultimediaId }, multimedium);
        }

        // DELETE: api/Multimediums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMultimedium(int id)
        {
            var multimedium = await _context.Multimedia.FindAsync(id);
            if (multimedium == null)
            {
                return NotFound();
            }

            _context.Multimedia.Remove(multimedium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MultimediumExists(int id)
        {
            return _context.Multimedia.Any(e => e.MultimediaId == id);
        }
    }
}
