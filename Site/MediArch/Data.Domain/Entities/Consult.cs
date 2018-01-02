using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
    public class Consult
    {
        [Key]
        public Guid Id { get; set; }


        public long DoctorCNP { get; set; }


        public long PacientCNP { get; set; }
        

        public string ConsultResult { get; set; }


        public List<Medicine> MedicineList { get; set; }
    }
}
