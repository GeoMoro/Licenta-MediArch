using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediArch.Models
{
    public class Person
    {
            /* Folosit ca si UserName (Mod unic de logare)
            */
        [Key]
        public Guid Id { get; set; }

        
     //   [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }


     //   [Required(ErrorMessage = "Last name is required!")]
        public string LastName { get; set; }


    //    [Required(ErrorMessage = "CNP is required!")]
        public int CNP { get; set; }


    //    [Required(ErrorMessage = "Birth Date is required!")]
        //[DataType()]
        public DateTime BirthDate { get; set; }


    //    [Required(ErrorMessage = "E-mail is required!")]
        //[RegularExpression()]
        public string Email { get; set; }


    //    [Required(ErrorMessage = "Password is required!")]
        //[DataType()]
        public string Password { get; set; }


     //   [Required(ErrorMessage = "Please confirm your password!")]
        //[DataType()]
        public string ConfirmPassword { get; set; }


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

     //   [Required(ErrorMessage = "Phone number is required!")]
        //[RegularExpression()]
        public List<string> PhoneNumbers { get; set; }
    }
}