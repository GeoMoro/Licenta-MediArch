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
using MediArchNew.Data;
using MediArchNew.Models;
using Data.Domain.Interfaces;

namespace MediArchNew.Controllers
{
    [Authorize]
    public class ConsultsController : Controller
    {
        //private readonly DatabaseContext _context;

        private readonly IConsultRepository _repository;

        private readonly ApplicationDbContext _applicationDbContext;

        public ConsultsController(/*DatabaseContext context,*/ IConsultRepository iConsultRepository, ApplicationDbContext applicationDbContext)
        {
            //_context = context;

            _repository = iConsultRepository;

            _applicationDbContext = applicationDbContext;
        }

        // GET: Consults
        [Authorize(Roles = "Owner, Moderator")]
        public /*async Task<*/IActionResult/*>*/ Index()
        {
            //return View(await _context.Consults.ToListAsync());
            return View(_repository.GetAll());
        }

        [Authorize(Roles = "Medic")]
        public /*async Task<*/IActionResult/*>*/ MyConsults(string id)
        {
            /*return View(await (from consult in _context.Consults
                               where consult.MedicId.ToString() == id
                               select consult).ToListAsync()
                       );*/
            Guid medicId = new Guid(id);
            return View(_repository.GetAllConsultsForGivenMedicId(medicId));
        }

        [Authorize(Roles = "Pacient")]
        public /*async Task<*/IActionResult/*>*/ MyResults(string id)
        {
            /*return View(await (from consult in _context.Consults
                               where consult.PacientId.ToString() == id
                               select consult).ToListAsync()
                       );*/
            Guid pacientId = new Guid(id);
            return View(_repository.GetAllConsultsForGivenPacientId(pacientId));

        }

        // GET: Consults/Details/5
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public /*async Task<*/IActionResult/*>*/ Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var consult = await _context.Consults.SingleOrDefaultAsync(m => m.Id == id);

            var consult = _repository.GetConsultById(id.Value);
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
        public /*async Task<*/IActionResult/*>*/ Create([Bind("Id,MedicId,PacientId,Medicines,ConsultResult")] Consult consult)
        {
            if (ModelState.IsValid)
            {
                consult.Id = Guid.NewGuid();
            ///    consult.ConsultDate = DateTime.Now;
                /*_context.Add(consult);
                await _context.SaveChangesAsync();*/
                _repository.Create(consult);
                return RedirectToAction(nameof(Index));
            }
            return View(consult);
        }


        // GET: Consults/Create
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public IActionResult CreateNewConsult(Guid? medicId, Guid? pacientId)
        {
            TempData["MId"] = medicId.Value.ToString();
            TempData["PId"] = pacientId.Value.ToString();
            /* var user = (from appuser in _applicationDbContext.ApplicationUser
                              where appuser.Id == pacientId.ToString()
                              select appuser.Email).FirstOrDefaultAsync();
             TempData["Usr"] = user;*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public /*async Task<*/IActionResult/*>*/ CreateNewConsult(Guid? medicId, Guid? pacientId, [Bind("MedicId,PacientId,Medicines,ConsultResult")] CreateNewConsultModel createNewConsultModel)
        {
            //TempData["MId"] = medicId.ToString();
            //TempData["PId"] = pacientId.ToString();

            Consult consult = new Consult()
            {
                Id = Guid.NewGuid(),
                MedicId = createNewConsultModel.MedicId,
                PacientId = createNewConsultModel.PacientId,
             ///    ConsultDate = DateTime.Now,
                Medicines = createNewConsultModel.Medicines,
                ConsultResult = createNewConsultModel.ConsultResult
            };

            /*_context.Add(consult);
            await _context.SaveChangesAsync();*/

            _repository.Create(consult);

            //return RedirectToAction(nameof(Index));

            //return View(consult);
            return RedirectToAction("Index", "Home");
        }

        // GET: Consults/Edit/5
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public /*async Task<*/IActionResult/*>*/ Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var consult = await _context.Consults.SingleOrDefaultAsync(m => m.Id == id);

            var consult = _repository.GetConsultById(id.Value);

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
        public /*async Task<*/IActionResult/*>*/ Edit(Guid id, [Bind("Id,MedicId,PacientId,Medicines,ConsultResult")] Consult consult)
        {
            if (id != consult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /* _context.Update(consult);
                     await _context.SaveChangesAsync();*/
                    _repository.Edit(consult);
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
        public /*async Task<*/IActionResult/*>*/ Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var consult = await _context.Consults.SingleOrDefaultAsync(m => m.Id == id);*/

            var consult = _repository.GetConsultById(id.Value);

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
        public /*async Task<*/IActionResult/*>*/ DeleteConfirmed(Guid id)
        {
            /*var consult = await _context.Consults.SingleOrDefaultAsync(m => m.Id == id);
            _context.Consults.Remove(consult);
            await _context.SaveChangesAsync();*/

            var consult = _repository.GetConsultById(id);
            _repository.Delete(consult);

            return RedirectToAction(nameof(Index));
        }

        private bool ConsultExists(Guid id)
        {
            //return _context.Consults.Any(e => e.Id == id);

            return _repository.Exists(id);
        }
    }
}
