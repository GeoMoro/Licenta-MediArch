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
using Data.Domain.Interfaces;

namespace MediArch.Controllers
{
    [Authorize]
    public class MedicinesController : Controller
    {

        private readonly IMedicineRepository _repository;
        
        public MedicinesController( IMedicineRepository iMedicineRepository)
        {
            _repository = iMedicineRepository;
        }

        // GET: Medicines
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public IActionResult Index()
        {
            return View(_repository.GetAllMedicines());
        }

        // GET: Medicines/Details/5
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var medicine = _repository.GetMedicineById(id.Value);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // GET: Medicines/Create
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Create([Bind("Id,Name,Prospect")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                medicine.Id = Guid.NewGuid();
                
                Medicine newMedicine = new Medicine()
                {
                    Id = new Guid(),
                    Name = medicine.Name,
                    Prospect = medicine.Prospect
                };

                _repository.Create(newMedicine);

                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var medicine = _repository.GetMedicineById(id.Value);

            if (medicine == null)
            {
                return NotFound();
            }
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Prospect")] Medicine medicine)
        {
            if (id != medicine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Edit(medicine);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.Id))
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
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var medicine = _repository.GetMedicineById(id.Value);

            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var medicine = _repository.GetMedicineById(id);
            _repository.Delete(medicine);

            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(Guid id)
        {
            return _repository.Exists(id);
        }
    }
}
