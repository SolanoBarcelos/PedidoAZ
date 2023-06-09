using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PedidoAZ.Data;
using PedidoAZ.Models;

namespace PedidoAZ.Controllers
{
    public class PedidoController : Controller
    {
        private readonly Contexto _context;

        public PedidoController(Contexto context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
              return _context.Pedido != null ? 
                          View(await _context.Pedido.ToListAsync()) :
                          Problem("Entity set 'Contexto.Pedido'  is null.");
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Produto,NomeCliente,Endereco,DataPedido,Recebido")] PedidoModel pedidoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoModel);
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedido.FindAsync(id);
            if (pedidoModel == null)
            {
                return NotFound();
            }
            return View(pedidoModel);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Produto,NomeCliente,Endereco,DataPedido,Recebido")] PedidoModel pedidoModel)
        {
            if (id != pedidoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoModelExists(pedidoModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedidoModel);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedido == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedido
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedido == null)
            {
                return Problem("Entity set 'Contexto.Pedido'  is null.");
            }
            var pedidoModel = await _context.Pedido.FindAsync(id);
            if (pedidoModel != null)
            {
                _context.Pedido.Remove(pedidoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoModelExists(int id)
        {
          return (_context.Pedido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
