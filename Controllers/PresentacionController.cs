using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManualidadesEunice.Models;

namespace ManualidadesEunice.Controllers
{
    public class PresentacionController : Controller
    {
        private readonly EuniceContext _context;

        public PresentacionController(EuniceContext context)
        {
            _context = context;
        }

        // GET: Presentacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presentacion.ToListAsync());
        }

        // GET: Presentacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacion
                .FirstOrDefaultAsync(m => m.CodigoPresentacion == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

        // GET: Presentacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presentacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Presentacion presentacion)
        {
            await _context.Presentacion.AddAsync(presentacion);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Presentacion");
        }

        // GET: Presentacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacion.FindAsync(id);
            if (presentacion == null)
            {
                return NotFound();
            }
            return View(presentacion);
        }

        // POST: Presentacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoPresentacion,NombrePresentacion,Estado,FechaRegistro")] Presentacion presentacion)
        {
            if (id != presentacion.CodigoPresentacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    presentacion.FechaRegistro = DateTime.Now;
                    _context.Update(presentacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentacionExists(presentacion.CodigoPresentacion))
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
            return View(presentacion);
        }

        // GET: Presentacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacion
                .FirstOrDefaultAsync(m => m.CodigoPresentacion == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

        // POST: Presentacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presentacion = await _context.Presentacion.FindAsync(id);
            if (presentacion != null)
            {
                _context.Presentacion.Remove(presentacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentacionExists(int id)
        {
            return _context.Presentacion.Any(e => e.CodigoPresentacion == id);
        }
    }
}
