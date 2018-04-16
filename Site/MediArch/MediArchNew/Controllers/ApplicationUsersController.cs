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
        private readonly ApplicationDbContext _context;

        private readonly DatabaseContext _databaseContext;

        public ApplicationUsersController(ApplicationDbContext context, DatabaseContext databaseContext)
        {
            _context = context;
            _databaseContext = databaseContext;
        }

        // GET: ApplicationUsers
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.OrderBy(x => x.Email).ToListAsync());
        }

        // GET: ApplicationUsers
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public async Task<IActionResult> GetPacientList()
        {
            List<ApplicationUser> list = await (from appUsr in _context.ApplicationUser
                                                join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                                join role in _context.Roles on usrRoles.RoleId equals role.Id
                                                where role.Name == "Pacient"
                                                select appUsr).OrderBy(x => x.Email).ToListAsync();
            return View(list);
        }

        // GET: ApplicationUsers
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public async Task<IActionResult> GetMedicList()
        {
            List<ApplicationUser> list = await (from appUsr in _context.ApplicationUser
                                                join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                                join role in _context.Roles on usrRoles.RoleId equals role.Id
                                                where role.Name == "Medic"
                                                select appUsr).OrderBy(x => x.Email).ToListAsync();
            return View(list);
        }
        
        // GET: ApplicationUsers/Details/5
        [Authorize(Roles = "Owner, Moderator, Medic, Pacient")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("CNP,FirstName,LastName,BirthDate,Title,CabinetAdress,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
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
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            ApplicationUserEditModel applicationUserEditModel = new ApplicationUserEditModel();

            applicationUserEditModel.CNP = applicationUser.CNP;
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
        public async Task<IActionResult> Edit(string id, [Bind("CNP,FirstName,LastName,BirthDate,Title,CabinetAdress,Email,PhoneNumber")] ApplicationUserEditModel applicationUserEditModel)
        {
            /*if (id != applicationUser.Id)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
                   
                        user.CNP = applicationUserEditModel.CNP;
                        user.FirstName = applicationUserEditModel.FirstName;
                        user.LastName = applicationUserEditModel.LastName;
                        user.BirthDate = applicationUserEditModel.BirthDate;
                        user.Title = applicationUserEditModel.Title;
                        user.CabinetAdress = applicationUserEditModel.CabinetAdress;
                        user.Email = applicationUserEditModel.Email;
                        user.PhoneNumber = applicationUserEditModel.PhoneNumber;

                        user.UserName = applicationUserEditModel.Email;
                        user.NormalizedUserName = applicationUserEditModel.Email.ToUpper();
                        user.NormalizedEmail = applicationUserEditModel.Email.ToUpper();

                        _context.Update(user);

                        await _context.SaveChangesAsync();
                    
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
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .SingleOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUser.Remove(applicationUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
