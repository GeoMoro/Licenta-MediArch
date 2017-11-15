using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediArch.Data;

namespace MediArch.Controllers
{
    public class PacientsController : Controller
    {
        private readonly DataService _context;

        public PacientsController(DataService context)
        {
            _context = context;
        }

        // GET: Pacients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pacient.ToListAsync());
        }

        // GET: Pacients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // GET: Pacients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,CNP,BirthDate,Email,Password,PhoneNumber,UserType")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                pacient.Id = Guid.NewGuid();
                _context.Add(pacient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacient);
        }

        // GET: Pacients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.SingleOrDefaultAsync(m => m.Id == id);
            if (pacient == null)
            {
                return NotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,CNP,BirthDate,Email,Password,PhoneNumber,UserType")] Pacient pacient)
        {
            if (id != pacient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacientExists(pacient.Id))
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
            return View(pacient);
        }

        // GET: Pacients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pacient = await _context.Pacient.SingleOrDefaultAsync(m => m.Id == id);
            _context.Pacient.Remove(pacient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientExists(Guid id)
        {
            return _context.Pacient.Any(e => e.Id == id);
        }
    }
}
