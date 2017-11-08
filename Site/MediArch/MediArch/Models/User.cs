using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediArch.Models
{
    public class User
    {
        public Guid Id { get; set; }

        /* Folosit ca si UserName (Mod unic de logare)
         */
        public int CNP { get; set; }

        public DateTime Birth_Date { get; set; }

        public string Password { get; set; }

        /* 0 = User Normal
         * 1 = Medic
         * 2 = Admin
         */
        public int UserType { get; set; }

    }
}