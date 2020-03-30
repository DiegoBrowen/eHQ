using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eHQ.Estoque.Api.Infra;
using eHQ.Estoque.Api.Models;

namespace eHQ.Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueRevistasController : ControllerBase
    {
        private readonly EstoqueContext _context;

        public EstoqueRevistasController(EstoqueContext context)
        {
            _context = context;
        }

        // GET: api/EstoqueRevistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstoqueRevista>>> GetEstoqueRevistas()
        {
            return await _context.EstoqueRevistas.ToListAsync();
        }

        // GET: api/EstoqueRevistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstoqueRevista>> GetEstoqueRevista(Guid id)
        {
            var estoqueRevista = await _context.EstoqueRevistas.FindAsync(id);

            if (estoqueRevista == null)
            {
                return NotFound();
            }

            return estoqueRevista;
        }

        // PUT: api/EstoqueRevistas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoqueRevista(Guid id, EstoqueRevista estoqueRevista)
        {
            if (id != estoqueRevista.Id)
            {
                return BadRequest();
            }

            _context.Entry(estoqueRevista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueRevistaExists(id))
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

        // POST: api/EstoqueRevistas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EstoqueRevista>> PostEstoqueRevista(EstoqueRevista estoqueRevista)
        {
            _context.EstoqueRevistas.Add(estoqueRevista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstoqueRevista", new { id = estoqueRevista.Id }, estoqueRevista);
        }

        // DELETE: api/EstoqueRevistas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstoqueRevista>> DeleteEstoqueRevista(Guid id)
        {
            var estoqueRevista = await _context.EstoqueRevistas.FindAsync(id);
            if (estoqueRevista == null)
            {
                return NotFound();
            }

            _context.EstoqueRevistas.Remove(estoqueRevista);
            await _context.SaveChangesAsync();

            return estoqueRevista;
        }

        private bool EstoqueRevistaExists(Guid id)
        {
            return _context.EstoqueRevistas.Any(e => e.Id == id);
        }
    }
}
