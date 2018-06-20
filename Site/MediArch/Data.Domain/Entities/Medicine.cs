using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
    public class Medicine
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Prospect { get; set; }
        
    }
}
