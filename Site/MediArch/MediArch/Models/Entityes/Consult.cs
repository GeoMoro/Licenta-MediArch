using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediArch.Data
{
    public class Consult
    {
        [Key]
        public Guid Id { get; set; }


        public Guid DoctorId { get; set; }


        public Guid PacientId { get; set; }
        

        public string ConsultResult { get; set; }
        
    }
}
