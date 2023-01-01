using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeyirAkademi_v1._1.Models;

namespace SeyirAkademi_v1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocsApiController : ControllerBase
    {
        DocContext _context = new DocContext();
        //private readonly DocContext _context;

        //public DocsApiController(DocContext context)
        //{
        //    _context = context;
        //}

        // GET: api/DocsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doc>>> GetDocs()
        {
            var y = await _context.Docs.Where(x => x.DocTypeId == 1).ToListAsync();
            if (y is null)
            {
                return NoContent();
            }
            return y;
        }

        // GET: api/DocsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Doc>>> GetDoc(int id)
        {
            var y = await _context.Docs.Where(x => x.DocTypeId == id).ToListAsync();
            if (y is null)
            {
                return NoContent();
            }
            return y;
        }

        // PUT: api/DocsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoc(int id, Doc doc)
        {
            if (id != doc.Id)
            {
                return BadRequest();
            }

            _context.Entry(doc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocExists(id))
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

        // POST: api/DocsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doc>> PostDoc(Doc doc)
        {
            _context.Docs.Add(doc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoc", new { id = doc.Id }, doc);
        }

        // DELETE: api/DocsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoc(int id)
        {
            var doc = await _context.Docs.FindAsync(id);
            if (doc == null)
            {
                return NotFound();
            }

            _context.Docs.Remove(doc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocExists(int id)
        {
            return _context.Docs.Any(e => e.Id == id);
        }
    }
}
