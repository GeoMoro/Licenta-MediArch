using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediArch.Data;
using MediArch.Models;
using Microsoft.AspNetCore.Authorization;
using MediArch.Models.ApplicationUserViewModels;
using Data.Persistence;

namespace MediArch.Controllers
{
    [Authorize]
    public class ApplicationUsersController : Controller
    {
        //Transfered to AccountController => Now this is UNUSED
/*
        private readonly IApplicationUserService _service;

        public ApplicationUsersController(IApplicationUserService service)
        {
            _service = service;
        }


        // GET: ApplicationUsers
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Index()
        {
            return View(_service.GetAllUsers());
        }

        // GET: ApplicationUsers
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public IActionResult GetPacientList()
        {
            return View(_service.GetAllPacients());
        }

        // GET: ApplicationUsers
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public IActionResult GetMedicList()
        {
            return View(_service.GetAllMedics());
        }

        // GET: ApplicationUsers
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public IActionResult GetMedicListForEachSpecialization()
        {
            return View();
        }

        // GET: ApplicationUsers/Details/5
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = _service.GetUserById(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }
        /*
        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,BirthDate,Title,CabinetAdress,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }
        */
        // GET: ApplicationUsers/Edit/5
/*        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser applicationUser = _service.GetUserById(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            ApplicationUserEditModel applicationUserEditModel = new ApplicationUserEditModel();
            
            applicationUserEditModel.FirstName = applicationUser.FirstName;
            applicationUserEditModel.LastName = applicationUser.LastName;
            applicationUserEditModel.BirthDate = applicationUser.BirthDate;
            applicationUserEditModel.Title = applicationUser.Title;
            applicationUserEditModel.CabinetAdress = applicationUser.CabinetAdress;
            applicationUserEditModel.Email = applicationUser.Email;
            applicationUserEditModel.PhoneNumber = applicationUser.PhoneNumber;

            return View(applicationUserEditModel);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator")]
        //Va trebui folosit un model pt Edit si pt create
        public IActionResult Edit(string id, [Bind("FirstName,LastName,BirthDate,Title,CabinetAdress,Email,PhoneNumber")] ApplicationUserEditModel applicationUserEditModel)
        {
            /*if (id != applicationUser.Id)
            {
                return NotFound();
            }*/
/*
            if (ModelState.IsValid)
            {
                try
                {
                    _service.EditApplicationUser(id, applicationUserEditModel);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(id))
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
            return View(applicationUserEditModel);
        }

        // GET: ApplicationUsers/Delete/5
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = _service.GetUserById(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Moderator")]
        public IActionResult DeleteConfirmed(string id)
        {
            var applicationUser = _service.GetUserById(id);
            _service.DeleteApplicationUser(applicationUser);
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return ApplicationUserExists(id);
        }*/
    }
}
