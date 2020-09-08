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
    public class UltDoasController : Controller
    {
        private readonly DoacaoNinaContext _context;

        public UltDoasController(DoacaoNinaContext context)
        {
            _context = context;
        }

        // GET: UltDoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.UltDoa.ToListAsync());
        }

        // GET: UltDoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ultDoa = await _context.UltDoa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ultDoa == null)
            {
                return NotFound();
            }

            return View(ultDoa);
        }

        // GET: UltDoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UltDoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Data,Nome,Valor")] UltDoa ultDoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ultDoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ultDoa);
        }

        // GET: UltDoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ultDoa = await _context.UltDoa.FindAsync(id);
            if (ultDoa == null)
            {
                return NotFound();
            }
            return View(ultDoa);
        }

        // POST: UltDoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Data,Nome,Valor")] UltDoa ultDoa)
        {
            if (id != ultDoa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ultDoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UltDoaExists(ultDoa.ID))
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
            return View(ultDoa);
        }

        // GET: UltDoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ultDoa = await _context.UltDoa
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ultDoa == null)
            {
                return NotFound();
            }

            return View(ultDoa);
        }

        // POST: UltDoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ultDoa = await _context.UltDoa.FindAsync(id);
            _context.UltDoa.Remove(ultDoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UltDoaExists(int id)
        {
            return _context.UltDoa.Any(e => e.ID == id);
        }
    }
}
