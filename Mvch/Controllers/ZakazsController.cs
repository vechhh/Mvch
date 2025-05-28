using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvch.Data;
using Mvch.Models;

namespace Mvch.Controllers
{
    public class ZakazsController : Controller
    {
        private readonly MvchContext _context;

        public ZakazsController(MvchContext context)
        {
            _context = context;
        }

        // GET: Zakazs
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Zakaz == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var movies = from m in _context.Zakaz
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Genre!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await movies.ToListAsync());
        }


        // GET: Zakazs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakaz = await _context.Zakaz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zakaz == null)
            {
                return NotFound();
            }

            return View(zakaz);
        }

        // GET: Zakazs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zakazs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Price,Genre,Rating")] Zakaz zakaz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zakaz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zakaz);
        }

        // GET: Zakazs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakaz = await _context.Zakaz.FindAsync(id);
            if (zakaz == null)
            {
                return NotFound();
            }
            return View(zakaz);
        }

        // POST: Zakazs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Price,Genre,Rating")] Zakaz zakaz)
        {
            if (id != zakaz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zakaz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZakazExists(zakaz.Id))
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
            return View(zakaz);
        }

        // GET: Zakazs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakaz = await _context.Zakaz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zakaz == null)
            {
                return NotFound();
            }

            return View(zakaz);
        }

        // POST: Zakazs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zakaz = await _context.Zakaz.FindAsync(id);
            if (zakaz != null)
            {
                _context.Zakaz.Remove(zakaz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZakazExists(int id)
        {
            return _context.Zakaz.Any(e => e.Id == id);
        }
    }
}
