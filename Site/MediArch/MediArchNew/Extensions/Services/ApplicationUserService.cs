using Data.Persistence;
using MediArch.Data;
using MediArch.Extensions.Interfaces;
using MediArch.Models;
using MediArch.Models.ApplicationUserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArch.Extensions.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _context;

        private readonly DatabaseContext _databaseContext;

        public ApplicationUserService(ApplicationDbContext context, DatabaseContext databaseContext)
        {
            _context = context;
            _databaseContext = databaseContext;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            List<ApplicationUser> owners = (from appUsr in _context.ApplicationUser
                                            join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                            join role in _context.Roles on usrRoles.RoleId equals role.Id
                                            where role.Name == "Owner"
                                            select appUsr).OrderBy(x => x.Email).ToList();
            List<ApplicationUser> moderators = ( from appUsr in _context.ApplicationUser
                                                 join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                                 join role in _context.Roles on usrRoles.RoleId equals role.Id
                                                 where role.Name == "Moderator"
                                                 select appUsr).OrderBy(x => x.Email).ToList();

            List<ApplicationUser> medics = (from appUsr in _context.ApplicationUser
                                            join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                            join role in _context.Roles on usrRoles.RoleId equals role.Id
                                            where role.Name == "Medic"
                                            select appUsr).OrderBy(x => x.Email).ToList();

            List<ApplicationUser> pacients = (  from appUsr in _context.ApplicationUser
                                                join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                                join role in _context.Roles on usrRoles.RoleId equals role.Id
                                                where role.Name == "Pacient"
                                                select appUsr).OrderBy(x => x.Email).ToList();

            List<ApplicationUser> result = new List<ApplicationUser>();
            
            foreach (ApplicationUser usr in owners)
            {
                result.Add(usr);
            }
            foreach (ApplicationUser usr in moderators)
            {
                result.Add(usr);
            }
            foreach (ApplicationUser usr in medics)
            {
                result.Add(usr);
            }
            foreach (ApplicationUser usr in pacients)
            {
                result.Add(usr);
            }


            return result;
        }
        
        public List<ApplicationUser> GetAllMedics()
        {
            List<ApplicationUser> medics = (from appUsr in _context.ApplicationUser
                                            join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                            join role in _context.Roles on usrRoles.RoleId equals role.Id
                                            where role.Name == "Medic"
                                            select appUsr).OrderBy(x => x.Email).ToList();
            
            List<ApplicationUser> result = new List<ApplicationUser>();

            foreach (ApplicationUser usr in medics)
            {
                result.Add(usr);
            }
            return result;

        }

        public List<ApplicationUser> GetAllPacients()
        {
            List<ApplicationUser> pacients = (from appUsr in _context.ApplicationUser
                                              join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                              join role in _context.Roles on usrRoles.RoleId equals role.Id
                                              where role.Name == "Pacient"
                                              select appUsr).OrderBy(x => x.Email).ToList();

            List<ApplicationUser> result = new List<ApplicationUser>();

            foreach (ApplicationUser usr in pacients)
            {
                result.Add(usr);
            }
            return result;

        }

        public List<ApplicationUser> SearchUsers(string text)
        {
            List<ApplicationUser> searchedUsers = ( from appUsr in _context.ApplicationUser
                                            join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                            join role in _context.Roles on usrRoles.RoleId equals role.Id
                                            where (role.Name == "Pacient" || role.Name == "Medic")
                                            select appUsr).Where(x=>x.FirstName.Contains(text) || 
                                                                    x.LastName.Contains(text) || 
                                                                    x.Email.Contains(text))
                                            .OrderBy(x => x.Email).ToList();

            return searchedUsers;
        }
        
        public ApplicationUser GetUserById(string id)
        {
            ApplicationUser usr = _context.ApplicationUser.SingleOrDefault(m => m.Id == id);

            return usr;

        }

        public void EditApplicationUser(string id, ApplicationUserEditModel appusrmodel)
        {
            ApplicationUser user = GetUserById(id);

            user.CNP = appusrmodel.CNP;
            user.FirstName = appusrmodel.FirstName;
            user.LastName = appusrmodel.LastName;
            user.BirthDate = appusrmodel.BirthDate;
            user.Title = appusrmodel.Title;
            user.CabinetAdress = appusrmodel.CabinetAdress;
            user.Email = appusrmodel.Email;
            user.PhoneNumber = appusrmodel.PhoneNumber;

            user.UserName = appusrmodel.Email;
            user.NormalizedUserName = appusrmodel.Email.ToUpper();
            user.NormalizedEmail = appusrmodel.Email.ToUpper();

            _context.Update(user);

            _context.SaveChanges();
        }

        public void DeleteApplicationUser(ApplicationUser appusr)
        {
            _context.ApplicationUser.Remove(appusr);
            _context.SaveChanges();
        }

        public bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(x => x.Id == id);
        }

        public string DetermineUserRole(string id)
        {
            string usrrole = (from appUsr in _context.ApplicationUser
                           join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                           join role in _context.Roles on usrRoles.RoleId equals role.Id
                           where appUsr.Id == id
                          select role.Name).Single();
            return usrrole;
        }

        public List<ApplicationUser> GetMedicListByLocation(string location)
        {
            throw new NotImplementedException();
        }
    }
}
