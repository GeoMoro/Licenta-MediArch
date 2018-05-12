using MediArch.Models;
using MediArch.Models.ApplicationUserViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediArch.Services.Interfaces
{
    public interface IApplicationUserService
    {
        List<ApplicationUser> GetAllUsers();
        List<ApplicationUser> GetAllMedics();
        List<ApplicationUser> GetAllPacients();
        ApplicationUser GetUserById(string id);
        string GetUserIdByUserName(string userName);
        string GetFullUserNameById(string id);
        void EditApplicationUser(string id, ApplicationUserEditModel appusrmodel);
        void DeleteApplicationUser(ApplicationUser appusr);
        bool ApplicationUserExists(string id);

        List<ApplicationUser> SearchUsers(string text);
        List<ApplicationUser> SearchMedics(string text);
        List<ApplicationUser> SearchPacients(string text);
        string DetermineUserRole(string id);
        List<ApplicationUser> GetMedicListByLocation(string location);
        int GetAgeOfUser(string id);
        string GetFullNameById(string id);
        List<string> GetAllSpecializations();
        List<ApplicationUser> GetAllMedicsForCertainSpecialization(string specialization);
        void UploadProfilePicture();
        string GetNameOfProfilePictureById(Guid id);
        Stream GetProfilePictureById(Guid id);
        void DeleteProfilePictureForGivenId(Guid id);
        int GetNumberOfPagesForAllUsers();
        IEnumerable<ApplicationUser> Get5UsersByIndex(int index);
        int GetNumberOfPagesForDoctors();
        IEnumerable<ApplicationUser> Get5DoctorsByIndex(int index);
        int GetNumberOfPagesForPacients();
        IEnumerable<ApplicationUser> Get5PacientsByIndex(int index);
        string getUrlBase();
    }
}
