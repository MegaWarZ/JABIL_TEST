using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JABIL_TEST.Models;
using ClosedXML.Excel;
using System.Data;

namespace JABIL_TEST.Controllers
{
    public class PartNumbersController : Controller
    {
        private readonly MaterialsContext _context;

        public PartNumbersController(MaterialsContext context)
        {
            _context = context;
        }

        // GET: PartNumbers
        public async Task<IActionResult> Index()
        {
            var materialsContext = _context.PartNumbers.Include(p => p.FkcustomerNavigation);
            return View(await materialsContext.ToListAsync());
        }

        // GET: PartNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PartNumbers == null)
            {
                return NotFound();
            }

            var partNumber = await _context.PartNumbers
                .Include(p => p.FkcustomerNavigation)
                .FirstOrDefaultAsync(m => m.PkpartNumber == id);
            if (partNumber == null)
            {
                return NotFound();
            }

            return View(partNumber);
        }

        // GET: PartNumbers/Create
        public IActionResult Create()
        {
            ViewData["Fkcustomer"] = new SelectList(_context.Customers, "Pkcustomers", "Pkcustomers");
            return View();
        }

        // POST: PartNumbers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkpartNumber,PartNumber1,Fkcustomer,LastUpdate,LastUser,Available")] PartNumber partNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fkcustomer"] = new SelectList(_context.Customers, "Pkcustomers", "Pkcustomers", partNumber.Fkcustomer);
            return View(partNumber);
        }

        // GET: PartNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PartNumbers == null)
            {
                return NotFound();
            }

            var partNumber = await _context.PartNumbers.FindAsync(id);
            if (partNumber == null)
            {
                return NotFound();
            }
            ViewData["Fkcustomer"] = new SelectList(_context.Customers, "Pkcustomers", "Pkcustomers", partNumber.Fkcustomer);
            return View(partNumber);
        }

        // POST: PartNumbers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkpartNumber,PartNumber1,Fkcustomer,LastUpdate,LastUser,Available")] PartNumber partNumber)
        {
            if (id != partNumber.PkpartNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartNumberExists(partNumber.PkpartNumber))
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
            ViewData["Fkcustomer"] = new SelectList(_context.Customers, "Pkcustomers", "Pkcustomers", partNumber.Fkcustomer);
            return View(partNumber);
        }

        // GET: PartNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PartNumbers == null)
            {
                return NotFound();
            }

            var partNumber = await _context.PartNumbers
                .Include(p => p.FkcustomerNavigation)
                .FirstOrDefaultAsync(m => m.PkpartNumber == id);
            if (partNumber == null)
            {
                return NotFound();
            }

            return View(partNumber);
        }

        // POST: PartNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PartNumbers == null)
            {
                return Problem("Entity set 'MaterialsContext.PartNumbers'  is null.");
            }
            var partNumber = await _context.PartNumbers.FindAsync(id);
            if (partNumber != null)
            {
                _context.PartNumbers.Remove(partNumber);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartNumberExists(int id)
        {
          return _context.PartNumbers.Any(e => e.PkpartNumber == id);
        }
    }
}
