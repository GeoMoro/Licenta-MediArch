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

        /* Numele Medicamentului
         */
        public string Name { get; set; }

        public string Prospect { get; set; }

        /* Indicatii de administrare
         * ex: De 3 ori pe zi
         * Va trebui afisat din controller
         */
        //public string Indications { get; set; }
    }
}
