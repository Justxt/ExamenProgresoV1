using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenProgreso.Data;
using ExamenProgreso1.Models;

namespace ExamenProgreso.Controllers
{
    public class JMorasController : Controller
    {
        private readonly ExamenProgresoContext _context;

        public JMorasController(ExamenProgresoContext context)
        {
            _context = context;
        }

        // GET: JMoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.JMora.ToListAsync());
        }

        // GET: JMoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jMora = await _context.JMora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jMora == null)
            {
                return NotFound();
            }

            return View(jMora);
        }

        // GET: JMoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JMoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,NumeroTelefono,Sueldo,EsMayorDeEdad,FechaNacimiento")] JMora jMora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jMora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jMora);
        }

        // GET: JMoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jMora = await _context.JMora.FindAsync(id);
            if (jMora == null)
            {
                return NotFound();
            }
            return View(jMora);
        }

        // POST: JMoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,NumeroTelefono,Sueldo,EsMayorDeEdad,FechaNacimiento")] JMora jMora)
        {
            if (id != jMora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jMora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JMoraExists(jMora.Id))
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
            return View(jMora);
        }

        // GET: JMoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jMora = await _context.JMora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jMora == null)
            {
                return NotFound();
            }

            return View(jMora);
        }

        // POST: JMoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jMora = await _context.JMora.FindAsync(id);
            if (jMora != null)
            {
                _context.JMora.Remove(jMora);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JMoraExists(int id)
        {
            return _context.JMora.Any(e => e.Id == id);
        }
    }
}
