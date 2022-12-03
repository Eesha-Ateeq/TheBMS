using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheBMS.Data;
using TheBMS.Models;

namespace TheBMS.Controllers
{
    public class bakerymenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public bakerymenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: bakerymenus
        public async Task<IActionResult> Index()
        {
            return View(await _context.bakerymenu.ToListAsync());
        }
        public async Task<IActionResult> bakerymenulist()
        {
            return View(await _context.bakerymenu.ToListAsync());
        }
        public IActionResult SearchForm()
        {
            return View();
        }
        public async Task<IActionResult> SearchResult(string Title)
        {
            return View("Index", await _context.bakerymenu.Where(a => a.Title.Contains(Title)).ToListAsync());
        }

        // GET: bakerymenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakerymenu = await _context.bakerymenu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bakerymenu == null)
            {
                return NotFound();
            }

            return View(bakerymenu);
        }

        // GET: bakerymenus/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: bakerymenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,URL")] bakerymenu bakerymenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bakerymenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bakerymenu);
        }

        // GET: bakerymenus/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakerymenu = await _context.bakerymenu.FindAsync(id);
            if (bakerymenu == null)
            {
                return NotFound();
            }
            return View(bakerymenu);
        }

        // POST: bakerymenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,URL")] bakerymenu bakerymenu)
        {
            if (id != bakerymenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bakerymenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bakerymenuExists(bakerymenu.Id))
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
            return View(bakerymenu);
        }

        // GET: bakerymenus/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bakerymenu = await _context.bakerymenu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bakerymenu == null)
            {
                return NotFound();
            }

            return View(bakerymenu);
        }

        // POST: bakerymenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bakerymenu = await _context.bakerymenu.FindAsync(id);
            _context.bakerymenu.Remove(bakerymenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bakerymenuExists(int id)
        {
            return _context.bakerymenu.Any(e => e.Id == id);
        }
    }
}
