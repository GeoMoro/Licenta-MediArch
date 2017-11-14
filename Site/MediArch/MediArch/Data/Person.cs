using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MediArch.Data
{
    public class Person
    {
        public Person()
        {
            // EF Core
        }

        /* Folosit ca si UserName (Mod unic de logare)
        */
        [Key]
        public Guid Id { get; set; }

        // Prenume
        [Required(ErrorMessage = "First name is required!")]
        [RegularExpression(@"([A-Z][a-z]+[\s|'-']?)+", ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }

        //Nume de familie
        [Required(ErrorMessage = "Last name is required!")]
        [RegularExpression(@"([A-Z][a-z]+)", ErrorMessage = "Format not allowed.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "CNP is required!")]
        [RegularExpression(@"(([1-6]{1})([0-9]{2})(((0)[1-9]{1})|((1)[0-2]{1}))(((0)[1-9]{1})|([1-2]{1}[0-9]{1})|((3)[0-1]{1}))([0-9]{6}))", ErrorMessage = "Formal not allowed.")]
        public long CNP { get; set; }

        [Required(ErrorMessage = "BirthDate is required!")]
        public DateTime BirthDate { get; set; }
        
        [Required(ErrorMessage = "E-mail is required!")]
        [RegularExpression(@"(([A-Za-z0-9]+)(@)((gmail)|(yahoo)){1}(.)(([A-Za-z]+)))", ErrorMessage = "Format not allowed.")]
        //  [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Format not allowed.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required!")]
        [DataType("Password", ErrorMessage = "Formal not allowed.")]
        public string Password { get; set; }


        /* Date de contact
         */
        [Required(ErrorMessage = "Phone number is required!")]
        [DataType("PhoneNumber", ErrorMessage = "Formal not allowed.")]
        public string PhoneNumber { get; set; }


        /* bool / int
         * 0 = User Normal
         * 1 = Medic
         */
        public int UserType { get; set; }


        /* Lista de consultatii
        */
        public List<Consult> Consults { set; get; }

    }
}
