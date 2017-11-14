using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediArch.Models
{
    public class Pacient : Person
    {
                /* Lista de doctori la care a avut consult pacientul
                 */
        public List<Guid> DoctorsVisitedList { set; get; }
    }
}