using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Data.Domain.Entities;

namespace MediArchNew.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public long CNP { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        //public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Title { get; set; }

        public string CabinetAdress { get; set; }

    }
}
