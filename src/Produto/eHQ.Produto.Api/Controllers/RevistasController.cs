using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eHQ.Produto.Api.Data;
using eHQ.Produto.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eHQ.Produto.Api.Controllers
{
    public class RevistasController : Controller
    {
        private readonly ProdutoContext _produtoContext;
        public RevistasController(ProdutoContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        /// <summary>
        /// Retrieves a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Revista), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var revistas = await _produtoContext.Revistas.ToListAsync(cancellationToken);
            return Ok(revistas);
        }

        // GET: Revistas/Details/5
        public async Task<ActionResult> Details(Guid id, CancellationToken cancellationToken)
        {
            var revista = await _produtoContext.Revistas.FindAsync(id, cancellationToken);
            if (revista == null)
                return NotFound();

            return Ok(revista);
        }

        // POST: Revistas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Revista revista, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _produtoContext.Add(revista);
            await _produtoContext.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        // POST: Revistas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Revista revista, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _produtoContext.Update(revista);
            await _produtoContext.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        // POST: Revistas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var revista = await _produtoContext.Revistas.FindAsync(id, cancellationToken);
            if (revista == null)
                return BadRequest();

            _produtoContext.Remove(revista);
            await _produtoContext.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}