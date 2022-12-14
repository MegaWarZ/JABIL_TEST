using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JABIL_TEST.Models;

namespace JABIL_TEST.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly MaterialsContext _context;

        public BuildingsController(MaterialsContext context)
        {
            _context = context;
        }

        // GET: Buildings
        public async Task<IActionResult> Index()
        {
              return View(await _context.Buildings.ToListAsync());
        }

        // GET: Buildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Buildings == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.Pkbuilding == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // GET: Buildings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pkbuilding,Building1,LastUpdate,LastUser,Available")] Building building)
        {
            if (ModelState.IsValid)
            {
                _context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(building);
        }

        // GET: Buildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Buildings == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return View(building);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pkbuilding,Building1,LastUpdate,LastUser,Available")] Building building)
        {
            if (id != building.Pkbuilding)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(building);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingExists(building.Pkbuilding))
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
            return View(building);
        }

        // GET: Buildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Buildings == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .FirstOrDefaultAsync(m => m.Pkbuilding == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Buildings == null)
            {
                return Problem("Entity set 'MaterialsContext.Buildings'  is null.");
            }
            var building = await _context.Buildings.FindAsync(id);
            if (building != null)
            {
                _context.Buildings.Remove(building);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingExists(int id)
        {
          return _context.Buildings.Any(e => e.Pkbuilding == id);
        }
    }
}
