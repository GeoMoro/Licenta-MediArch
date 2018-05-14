using Data.Persistence;
using MediArch.Data;
using MediArch.Models;
using MediArch.Models.ApplicationUserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MediArch.Services.Interfaces;
using MediArch.Models.ManageViewModels;
using Microsoft.AspNetCore.Http;

namespace MediArch.Services.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _context;

        private readonly DatabaseContext _databaseContext;

        private readonly IHostingEnvironment _env;

        public ApplicationUserService(ApplicationDbContext context, DatabaseContext databaseContext, IHostingEnvironment env)
        {
            _context = context;
            _databaseContext = databaseContext;
            _env = env;
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
                                            //where (role.Name == "Pacient" || role.Name == "Medic")
                                            select appUsr).Where(x=>x.FirstName.ToUpper().Contains(text.ToUpper()) || 
                                                                    x.LastName.ToUpper().Contains(text.ToUpper()) || 
                                                                    x.Email.ToUpper().Contains(text.ToUpper()))
                                            .OrderBy(x => x.Email).ToList();

            if (searchedUsers.Count == 0)
            {
                return new List<ApplicationUser>();
            }

            return searchedUsers;
        }

        public List<ApplicationUser> SearchMedics(string text)
        {
            List<ApplicationUser> rez = (from appUsr in _context.ApplicationUser
                                                   join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                                   join role in _context.Roles on usrRoles.RoleId equals role.Id
                                                   where (role.Name == "Medic")
                                                   select appUsr).Where(x => x.FirstName.ToUpper().Contains(text.ToUpper()) ||
                                                                           x.LastName.ToUpper().Contains(text.ToUpper()) ||
                                                                           x.Email.ToUpper().Contains(text.ToUpper()))
                                           .OrderBy(x => x.Email).ToList();

            if (rez.Count == 0)
            {
                return new List<ApplicationUser>();
            }

            return rez;
        }

        public List<ApplicationUser> SearchPacients(string text)
        {
            List<ApplicationUser> rez = (from appUsr in _context.ApplicationUser
                                         join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                         join role in _context.Roles on usrRoles.RoleId equals role.Id
                                         where (role.Name == "Pacient")
                                         select appUsr).Where(x => x.FirstName.ToUpper().Contains(text.ToUpper()) ||
                                                                 x.LastName.ToUpper().Contains(text.ToUpper()) ||
                                                                 x.Email.ToUpper().Contains(text.ToUpper()))
                                          .OrderBy(x => x.Email).ToList();

            if (rez.Count == 0)
            {
                return new List<ApplicationUser>();
            }

            return rez;
        }

        public ApplicationUser GetUserById(string id)
        {
            ApplicationUser usr = _context.ApplicationUser.SingleOrDefault(m => m.Id == id);

            return usr;
        }
        public ApplicationUser GetUserByUserName(string userName)
        {
            ApplicationUser usr = _context.ApplicationUser.SingleOrDefault(m => m.UserName == userName);

            return usr;
        }

        public string GetFullUserNameById(string id)
        {
            ApplicationUser usr = _context.ApplicationUser.SingleOrDefault(m => m.Id == id);
            return usr.FirstName + " " + usr.LastName;
        }

        public string GetUserIdByUserName(string userName)
        {
            return _context.ApplicationUser.SingleOrDefault(m => m.UserName == userName).Id.ToString();
        }

        public void EditApplicationUser(string id, ApplicationUserEditModel appusrmodel)
        {
            ApplicationUser user = GetUserById(id);
            
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
            return usrrole.ToUpper();
        }
        
        public int GetAgeOfUser(string id)
        {
            ApplicationUser usr = GetUserById(id);

            DateTime today = DateTime.Today;

            int age = today.Year - usr.BirthDate.Year;
            // Go back to the year the person was born in case of a leap year
            if (usr.BirthDate > today.AddYears((-1) * age))
                age-=1;
            return age;
        }

        public string GetFullNameById(string id)
        {
            ApplicationUser usr = GetUserById(id);

            return usr.LastName + " " + usr.FirstName;
        }

        public List<string> GetAllSpecializations()
        {
            List<string> Rez = (from appUsr in _context.ApplicationUser
                                join usrRoles in _context.UserRoles on appUsr.Id equals usrRoles.UserId
                                join role in _context.Roles on usrRoles.RoleId equals role.Id
                                where role.Name == "Medic"
                                select appUsr.Title.ToUpper().Replace("MEDIC ","")).Distinct().OrderBy(x=>x).ToList();
            
            return Rez;
        }

        public List<ApplicationUser> GetAllMedicsForCertainSpecialization(string specialization)
        {
            List<ApplicationUser> Rez = _context.ApplicationUser.Where(x => x.Title.Contains(specialization)).ToList();
            
            return Rez;
        }

        public List<ApplicationUser> GetMedicListByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfThisUserHaveAProfilePicture(Guid id)
        {
            var searchedPath = Path.Combine(_env.WebRootPath, "Users/" + id);
            if (Directory.Exists(searchedPath))
            {
                return true;
            }
            return false;
        }
        

        public string GetProfilePictureLink(string id)
        {

            string path = Directory.GetCurrentDirectory() + "\\wwwroot\\Users\\" + id;

            if (!Directory.Exists(path))
            {
                if (DetermineUserRole(id) == "MEDIC")
                {
                    return "/Users/Default/Medic_Normal.png";
                }
                else
                {
                    return "/Users/Default/User_Normal.png";
                }
            }
            else { 
                string fileName = GetNameOfProfilePictureById(new Guid(id));
                return "/Users/" + id + "/"+fileName;
            }
            //throw new NotImplementedException();
        }

        public void DeleteProfilePictureFilesForGivenId(Guid id)
        {
            var searchedPath = Path.Combine(_env.WebRootPath, "Users/" + id);
            if (Directory.Exists(searchedPath))
            {
                Directory.Delete(searchedPath, true);
            }
        }

        public void DeleteCertainFile(Guid userId, string fileName)
        {
            var searchedPath = Path.Combine(_env.WebRootPath, "Users/" + userId + "/" + fileName);

            if (File.Exists(searchedPath))
            {
                File.Delete(searchedPath);
            }
        }


        public string GetNameOfProfilePictureById(Guid userId)
        {
            string fileList = "";
            string path = Directory.GetCurrentDirectory() + "\\wwwroot\\Users\\" + userId;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var files in Directory.GetFiles(path))
            {
                fileList = Path.GetFileName(files);
            }

            return fileList;
        }

        //Trebuie modificat functia de edit si create pt Medic ai sa poata pune/modifica poza de profil

        public int GetNumberOfPagesForAllUsers()
        {
            int rez = 0;
            int count = _context.ApplicationUser.Count();
            rez = count / 5;

            if (rez * 5 < count)
            {
                rez++;
            }

            return rez;
        }
        public IEnumerable<ApplicationUser> Get5UsersByIndex(int index)
        {
            List<ApplicationUser> rez = new List<ApplicationUser>() { };
            List<ApplicationUser> allUsers = GetAllUsers();
            int start = (index - 1) * 5;
            int finish = start + 5;

            for (int i = start; i < finish; i++)
            {
                if (i < allUsers.Count)
                {
                    rez.Add(allUsers[i]);
                }
            }

            return rez;
        }

        public string getUrlBase()
        {
            return _env.WebRootPath;
        }

        public int GetNumberOfPagesForDoctors()
        {
            int rez = 0;
            int count = GetAllMedics().Count();
            rez = count / 5;

            if (rez * 5 < count)
            {
                rez++;
            }

            return rez;
        }

        public IEnumerable<ApplicationUser> Get5DoctorsByIndex(int index)
        {
            List<ApplicationUser> rez = new List<ApplicationUser>() { };
            List<ApplicationUser> allMedics = GetAllMedics();
            int start = (index - 1) * 5;
            int finish = start + 5;

            for (int i = start; i < finish; i++)
            {
                if (i < allMedics.Count)
                {
                    rez.Add(allMedics[i]);
                }
            }

            return rez;
        }

        public int GetNumberOfPagesForPacients()
        {
            int rez = 0;
            int count = GetAllPacients().Count();
            rez = count / 5;

            if (rez * 5 < count)
            {
                rez++;
            }

            return rez;
        }

        public IEnumerable<ApplicationUser> Get5PacientsByIndex(int index)
        {
            List<ApplicationUser> rez = new List<ApplicationUser>() { };
            List<ApplicationUser> allPacients = GetAllPacients();
            int start = (index - 1) * 5;
            int finish = start + 5;

            for (int i = start; i < finish; i++)
            {
                if (i < allPacients.Count)
                {
                    rez.Add(allPacients[i]);
                }
            }

            return rez;
        }

        public async Task UploadProfilePicture(string id, IEnumerable<IFormFile> UploadedFile)
        {
            var extensions = new List<string>
            {
                ".png",
                ".jpg",
                ".jpeg",
                ".bpg",
                ".svg"
            };
            
            if (UploadedFile != null && UploadedFile.Count() == 1)
            {
                bool ok = false;

                foreach (var file in UploadedFile)
                {
                    string fileName = file.FileName;

                    int count = fileName.Count(x => x == '.');

                    if (count == 1)
                    {
                        foreach (string extention in extensions)
                        {
                            if (fileName.EndsWith(extention))
                            {
                                ok = true;
                            }
                        }
                    }

                }
                if (ok == true)
                {
                   
                    var path = Path.Combine(_env.WebRootPath, "Users/" + id);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //Sterg ce aveam inainte si rescriu
                    
                    Guid UId = new Guid(id);
                    string currentFileName = GetNameOfProfilePictureById(UId);
                    DeleteCertainFile(UId, currentFileName);

                    foreach (var file in UploadedFile)
                    {
                        if (file.Length > 0)
                        {
                            using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }
                }
            }
        }
    }
}
