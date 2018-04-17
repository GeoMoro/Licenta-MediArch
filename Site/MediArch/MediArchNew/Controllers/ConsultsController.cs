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
using MediArch.Models.ConsultViewModels;
using MediArch.Data;
using MediArch.Models;
using Data.Domain.Interfaces;

namespace MediArch.Controllers
{
    [Authorize]
    public class ConsultsController : Controller
    {

        private readonly IConsultRepository _repository;

        private readonly ApplicationDbContext _applicationDbContext;

        public ConsultsController(IConsultRepository iConsultRepository, ApplicationDbContext applicationDbContext)
        {

            _repository = iConsultRepository;

            _applicationDbContext = applicationDbContext;
        }

        // GET: Consults
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Consults
        [Authorize(Roles = "Medic")]
        public IActionResult MyConsults(string id)
        {
            Guid medicId = new Guid(id);
            return View(_repository.GetAllConsultsForGivenMedicId(medicId));
        }

        // GET: Consults
        [Authorize(Roles = "Pacient")]
        public IActionResult MyResults(string id)
        {
            Guid pacientId = new Guid(id);
            return View(_repository.GetAllConsultsForGivenPacientId(pacientId));
        }

        // GET: Consults/Details/5
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
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
                consult.ConsultDate = DateTime.Now;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public IActionResult CreateNewConsult(Guid? medicId, Guid? pacientId, [Bind("MedicId,PacientId,Medicines,ConsultResult")] CreateNewConsultModel createNewConsultModel)
        {

            Consult consult = new Consult()
            {
                Id = Guid.NewGuid(),
                MedicId = createNewConsultModel.MedicId,
                PacientId = createNewConsultModel.PacientId,
                ConsultDate = DateTime.Now,
                Medicines = createNewConsultModel.Medicines,
                ConsultResult = createNewConsultModel.ConsultResult
            };
            

            _repository.Create(consult);
            
            return RedirectToAction("Index", "Home");
        }

        // GET: Consults/Edit/5
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var consult = _repository.GetConsultById(id.Value);

            if (consult == null)
            {
                return NotFound();
            }
            
            return View(consult);
        }

        // POST: Consults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        // This edit would be for admins
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator, Medic")]
        public IActionResult Edit(Guid id, [Bind("Id,MedicId,PacientId,Medicines,ConsultResult")] Consult consult)
        {
            if (id != consult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
        public IActionResult DeleteConfirmed(Guid id)
        {

            var consult = _repository.GetConsultById(id);
            _repository.Delete(consult);

            return RedirectToAction(nameof(Index));
        }

        private bool ConsultExists(Guid id)
        {
            return _repository.Exists(id);
        }
    }
}
