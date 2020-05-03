using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eHQ.Produto.Api.Data;
using eHQ.Produto.Api.Model;
using eHQ.Produto.Api.IntegrationEvents.Interfaces;
using eHQ.Produto.Api.IntegrationEvents.Events;

namespace eHQ.Produto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevistasController : ControllerBase
    {
        private readonly ProdutoContext _context;
        private readonly IProdutoIntegrationEventService _produtoIntegrationEventService;
        public RevistasController(ProdutoContext context, IProdutoIntegrationEventService produtoIntegrationEventService)
        {
            _context = context;
            _produtoIntegrationEventService = produtoIntegrationEventService;
        }

        // GET: api/Revistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revista>>> GetRevistas()
        {
            return await _context.Revistas.ToListAsync();
        }

        // GET: api/Revistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Revista>> GetRevista(Guid id)
        {
            var revista = await _context.Revistas.FindAsync(id);

            if (revista == null)
            {
                return NotFound();
            }

            return revista;
        }

        // PUT: api/Revistas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevista(Guid id, Revista revista)
        {
            if (id != revista.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(revista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevistaExists(id))
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

        // POST: api/Revistas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Revista>> PostRevista(Revista revista)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Revistas.Add(revista);
            await _context.SaveChangesAsync();

            var produdoAdicoinadoIntegrationEvent = new RevistaAdicionadaIntegrationEvent(revista.Id, revista.Titulo, revista.Ano);
            await _produtoIntegrationEventService.PublishEventAsync(produdoAdicoinadoIntegrationEvent);

            return CreatedAtAction("GetRevista", new { id = revista.Id }, revista);
        }

        // DELETE: api/Revistas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Revista>> DeleteRevista(Guid id)
        {
            var revista = await _context.Revistas.FindAsync(id);
            if (revista == null)
            {
                return NotFound();
            }

            _context.Revistas.Remove(revista);
            await _context.SaveChangesAsync();

            return revista;
        }

        private bool RevistaExists(Guid id)
        {
            return _context.Revistas.Any(e => e.Id == id);
        }
    }
}
