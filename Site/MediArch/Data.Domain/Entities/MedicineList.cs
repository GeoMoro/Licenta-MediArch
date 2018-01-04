using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
    public class MedicineList
    {
        [Key]
        public Guid Id { get; set; }

        // This list of medicines is asociated to This consult
        public Guid ConsultId { get; set; }

        //An list of Medicine Names: Ex: Med1, Med2
        public string Medicines { get; set; }
    }
}
