﻿using MediArch.Models;
using MediArch.Models.ApplicationUserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArch.Extensions.Interfaces
{
    public interface IApplicationUserService
    {
        List<ApplicationUser> GetAllUsers();
        List<ApplicationUser> GetAllMedics();
        List<ApplicationUser> GetAllPacients();
        ApplicationUser GetUserById(string id);
        void EditApplicationUser(string id, ApplicationUserEditModel appusrmodel);
        void DeleteApplicationUser(ApplicationUser appusr);
        bool ApplicationUserExists(string id);

        List<ApplicationUser> SearchUsers(string text);
        string DetermineUserRole(string id);
        List<ApplicationUser> GetMedicListByLocation(string location);
        int GetAgeOfUser(string id);
        string GetFullNameById(string id);
        
    }
}
