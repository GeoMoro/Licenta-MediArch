using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArch.Models.ConsultViewModels
{
    public class CreateNewConsultModel
    {
        public Guid MedicId { get; set; }

        public Guid PacientId { get; set; }

        public string Medicines { get; set; }

        public string ConsultResult { get; set; }
    }
}
