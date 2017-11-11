using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediArch.Models
{
    public class Medicine
    {
        [Key]
        public Guid Id { get; set; }

        /* Numele Medicamentului
         */
        public string Name { get; set; }

                /* Indicatii de administrare
                 * ex: De 3 ori pe zi
                 */
        public string Indications { get; set; }
    }
}