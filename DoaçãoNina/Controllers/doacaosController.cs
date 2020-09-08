using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoacaoNina.Data;
using DoaçãoNina.Models;

namespace DoaçãoNina.Controllers
{
    public class doacaosController : Controller
    {
        private readonly DoacaoNinaContext _context;

        public doacaosController(DoacaoNinaContext context)
        {
            _context = context;
        }

        // GET: doacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.doacao.ToListAsync());
        }

        // GET: doacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacao = await _context.doacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doacao == null)
            {
                return NotFound();
            }

            return View(doacao);
        }

        // GET: doacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: doacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,A")] doacao doacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doacao);
        }

        // GET: doacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacao = await _context.doacao.FindAsync(id);
            if (doacao == null)
            {
                return NotFound();
            }
            return View(doacao);
        }

        // POST: doacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,A")] doacao doacao)
        {
            if (id != doacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!doacaoExists(doacao.Id))
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
            return View(doacao);
        }

        // GET: doacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doacao = await _context.doacao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doacao == null)
            {
                return NotFound();
            }

            return View(doacao);
        }

        // POST: doacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doacao = await _context.doacao.FindAsync(id);
            _context.doacao.Remove(doacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool doacaoExists(int id)
        {
            return _context.doacao.Any(e => e.Id == id);
        }
    }
}
