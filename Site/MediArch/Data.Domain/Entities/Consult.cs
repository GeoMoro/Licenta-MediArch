using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Consult
    {
        [Key]
        public Guid Id { get; set; }
        
        //Doctor_Id
        public Guid MedicId { get; set; }

        //Patient_Id
        public Guid PacientId { get; set; }
        
        //Created_Date
        public DateTime ConsultDate { get; set; }
        
        //Prescription
        public string Medicines { get; set; }

        //Result
        public string ConsultResult { get; set; }
        
    }
}
