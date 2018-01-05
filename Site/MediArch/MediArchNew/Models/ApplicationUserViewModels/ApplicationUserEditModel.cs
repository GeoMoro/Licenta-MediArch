﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArchNew.Models.ApplicationUserViewModels
{
    public class ApplicationUserEditModel
    {
        public long CNP { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Title { get; set; }

        public string CabinetAdress { get; set; }
    }
}
