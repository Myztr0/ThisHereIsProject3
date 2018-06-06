using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThisHereIsProject3.Data;
using ThisHereIsProject3.Models;

namespace ThisHereIsProject3.Controllers
{
    public class GEModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GEModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GEModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GEModel.ToListAsync());
        }

        // GET: GEModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gEModel = await _context.GEModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gEModel == null)
            {
                return NotFound();
            }

            return View(gEModel);
        }

        // GET: GEModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GEModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name")] GEModel gEModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gEModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gEModel);
        }

        // GET: GEModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gEModel = await _context.GEModel.SingleOrDefaultAsync(m => m.ID == id);
            if (gEModel == null)
            {
                return NotFound();
            }
            return View(gEModel);
        }

        // POST: GEModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name")] GEModel gEModel)
        {
            if (id != gEModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gEModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GEModelExists(gEModel.ID))
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
            return View(gEModel);
        }

        // GET: GEModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gEModel = await _context.GEModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gEModel == null)
            {
                return NotFound();
            }

            return View(gEModel);
        }

        // POST: GEModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gEModel = await _context.GEModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.GEModel.Remove(gEModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GEModelExists(int id)
        {
            return _context.GEModel.Any(e => e.ID == id);
        }
    }
}
