using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfaces.ServiceInterfaces.Models.MedicineViewModels
{
    public class MedicineCreateModel
    {
        public string Name { get; set; }

        public string Prospect { get; set; }

        public IEnumerable<IFormFile> File { get; set; }
    }
}
