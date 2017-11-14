using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediArch.Models
{
    public class Consult
    {
        [Key]
        public Guid Id { get; set; }


        public Guid DoctorId { get; set; }


        public Guid PacientId { get; set; }


        //public string Diagnostic { get; set; }


        public string ConsultResult { get; set; }
        

        public List<Medicine> MedicineList { get; set; }
    }
}