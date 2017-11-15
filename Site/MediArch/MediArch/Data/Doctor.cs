using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediArch.Data
{
    public class Doctor : Person
    {
        /* Medicii vor avea
         * ex: Medic Dentist / Medic de Familie
         */
        public string Title { get; set; }

        /* Pentru a vedea de cate persoane a fost vizitat
         * Voi folosi si lista de consultatii (din Person) pentru a vedea cate
         */
        [NotMapped]
        public List<Guid> PatientList { get; set; }

        //[RegularExpression()]
        public string CabinetAdress { get; set; }

        public Doctor(string title, string cabinetAdress)
        {
            this.Title = title;
            this.PatientList = null;
            this.CabinetAdress = cabinetAdress;
        }

    }
}
