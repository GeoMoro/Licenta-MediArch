using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.AspNetCore.Authorization;
using MediArchNew.Models.ConsultViewModels;

namespace MediArchNew.Controllers
{
    [Authorize]
    public class ConsultsController : Controller
    {
        private readonly DatabaseContext _context;

        public ConsultsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Consults
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consults.ToListAsync());
        }

        // GET: Consults/Details/5
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consult = await _context.Consults
                .SingleOrDefaultAsync(m => m.Id == id);
            if (consult == null)
            {
                return NotFound();
            }

            return View(consult);
        }

        // GET: Consults/Create
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Consults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> Create([Bind("Id,MedicId,PacientId,Medicines,ConsultResult")] Consult consult)
        {
            if (ModelState.IsValid)
            {
                consult.Id = Guid.NewGuid();
                _context.Add(consult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consult);
        }


        // GET: Consults/Create
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult CreateNewConsult(Guid? medicId, Guid? pacientId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public async Task<IActionResult> CreateNewConsult(Guid? medicId, Guid? pacientId, string medicines, string consultResult)
        {
            Consult consult = new Consult();

            consult.Id = Guid.NewGuid();
            consult.MedicId = medicId.Value;
            consult.PacientId = pacientId.Value;
            consult.Medicines = medicines;
            consult.ConsultResult = consultResult;
            
            _context.Add(consult);
            await _context.SaveChangesAsync();

            //return RedirectToAction(nameof(Index));

            //return View(consult);
            return RedirectToAction("Index", "Home");
        }

        // GET: Consults/Edit/5
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consult = await _context.Consults.SingleOrDefaultAsync(m => m.Id == id);
            if (consult == null)
            {
                return NotFound();
            }

            /*
            CreateNewConsultModel consultModel = new CreateNewConsultModel();
            consultModel.ConsultResult = consult.ConsultResult;
            consultModel.Medicines = consult.Medicines;
            */

            return View(consult);
        }

        // POST: Consults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        // This edit would be for admins
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MedicId,PacientId,Medicines,ConsultResult")] Consult consult)
        {
            if (id != consult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultExists(consult.Id))
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
            return View(consult);
        }

        // GET: Consults/Delete/5
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consult = await _context.Consults
                .SingleOrDefaultAsync(m => m.Id == id);
            if (consult == null)
            {
                return NotFound();
            }

            return View(consult);
        }

        // POST: Consults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var consult = await _context.Consults.SingleOrDefaultAsync(m => m.Id == id);
            _context.Consults.Remove(consult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultExists(Guid id)
        {
            return _context.Consults.Any(e => e.Id == id);
        }
    }
}
