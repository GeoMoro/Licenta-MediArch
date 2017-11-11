using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediArch.Models;

namespace MediArch.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }

        // Prenume
        public string FirstName { get; set; }

        //Nume de familie
        public string LastName { get; set; }
        
        public long CNP { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public String BirthDateDay { get; set; }
        
        public String BirthDateMonth { get; set; }
        
        public String BirthDateYear { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public List<string> PhoneNumbers { get; set; }
        
        public int UserType { get; set; }
        
        public List<Consult> Consults { set; get; }

    }
}