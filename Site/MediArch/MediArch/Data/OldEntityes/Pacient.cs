using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediArch.Data
{
    public class Pacient : Person
    {
        /* Lista de doctori la care a avut consult pacientul
         */
        [NotMapped]
        public List<Guid> DoctorsVisitedList { set; get; }
    }
}
