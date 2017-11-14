using System;
using System.Collections.Generic;

namespace MediArch.Data
{
    public class Pacient : Person
    {
        /* Lista de doctori la care a avut consult pacientul
         */
        public List<Guid> DoctorsVisitedList { set; get; }
    }
}
