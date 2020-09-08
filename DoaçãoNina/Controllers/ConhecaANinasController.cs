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
    public class ConhecaANinasController : Controller
    {
        private readonly DoacaoNinaContext _context;

        public ConhecaANinasController(DoacaoNinaContext context)
        {
            _context = context;
        }

        // GET: ConhecaANinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConhecaANina.ToListAsync());
        }

        // GET: ConhecaANinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conhecaANina = await _context.ConhecaANina
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conhecaANina == null)
            {
                return NotFound();
            }

            return View(conhecaANina);
        }

        // GET: ConhecaANinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConhecaANinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome")] ConhecaANina conhecaANina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conhecaANina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conhecaANina);
        }

        // GET: ConhecaANinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conhecaANina = await _context.ConhecaANina.FindAsync(id);
            if (conhecaANina == null)
            {
                return NotFound();
            }
            return View(conhecaANina);
        }

        // POST: ConhecaANinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome")] ConhecaANina conhecaANina)
        {
            if (id != conhecaANina.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conhecaANina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConhecaANinaExists(conhecaANina.ID))
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
            return View(conhecaANina);
        }

        // GET: ConhecaANinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conhecaANina = await _context.ConhecaANina
                .FirstOrDefaultAsync(m => m.ID == id);
            if (conhecaANina == null)
            {
                return NotFound();
            }

            return View(conhecaANina);
        }

        // POST: ConhecaANinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conhecaANina = await _context.ConhecaANina.FindAsync(id);
            _context.ConhecaANina.Remove(conhecaANina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConhecaANinaExists(int id)
        {
            return _context.ConhecaANina.Any(e => e.ID == id);
        }
    }
}
