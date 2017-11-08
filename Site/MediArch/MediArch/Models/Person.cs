using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediArch.Models
{
    public class Person
    {
        public Guid Id { get; set; }

                /* Folosit ca si UserName (Mod unic de logare)
                 */
        public int CNP { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

                /* Lista de consultatii
                 */
        public List<Consult> Consults { set; get; }

                /* bool / int
                 * 0 = User Normal
                 * 1 = Medic
                 */
        public int UserType { get; set; }

                /* Date de contact
                 */
        public string Eail { get; set; }

        public List<string> PhoneNumbers { get; set; }

        public string CabinetAdress { get; set; }
        
    }
}