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
        
        public Guid MedicId { get; set; }
        
        public Guid PacientId { get; set; }
        
        public DateTime ConsultDate { get; set; }
        
        public string Medicines { get; set; }

        public string ConsultResult { get; set; }
        
    }
}
