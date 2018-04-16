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

        //An list of Medicine Names: Ex: Med1(indicatiiMed1), Med2
        public string Medicines { get; set; }

        public string ConsultResult { get; set; }
        
    }
}
