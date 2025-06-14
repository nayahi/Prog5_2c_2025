using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prog5_2c_2025.Data;
using Prog5_2c_2025.Models;

namespace Prog5_2c_2025.Controllers
{
    public class Estudiante2Controller : Controller
    {
        private readonly AppDbContext _context;

        public Estudiante2Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: Estudiante2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudiante2.ToListAsync());
        }

        // GET: Estudiante2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante2 = await _context.Estudiante2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante2 == null)
            {
                return NotFound();
            }

            return View(estudiante2);
        }

        // GET: Estudiante2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiante2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad")] Estudiante2 estudiante2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante2);
        }

        // GET: Estudiante2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante2 = await _context.Estudiante2.FindAsync(id);
            if (estudiante2 == null)
            {
                return NotFound();
            }
            return View(estudiante2);
        }

        // POST: Estudiante2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad")] Estudiante2 estudiante2)
        {
            if (id != estudiante2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Estudiante2Exists(estudiante2.Id))
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
            return View(estudiante2);
        }

        // GET: Estudiante2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante2 = await _context.Estudiante2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante2 == null)
            {
                return NotFound();
            }

            return View(estudiante2);
        }

        // POST: Estudiante2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante2 = await _context.Estudiante2.FindAsync(id);
            if (estudiante2 != null)
            {
                _context.Estudiante2.Remove(estudiante2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Estudiante2Exists(int id)
        {
            return _context.Estudiante2.Any(e => e.Id == id);
        }
    }
}
