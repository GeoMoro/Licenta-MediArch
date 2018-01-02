using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
    public class UserAccount
    {
        public UserAccount() // MVC can call that
        {
        }

        // Comun
        [Key]
        public Guid Id { get; set;}

        /* Comun
         * CNP
         */
        //[Key]
        [Display(Name = "CNP")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CNP is required!")]
        [RegularExpression(@"(([1-6]{1})([0-9]{2})(((0)[1-9]{1})|((1)[0-2]{1}))(((0)[1-9]{1})|([1-2]{1}[0-9]{1})|((3)[0-1]{1}))([0-9]{6}))", ErrorMessage = "Formal not allowed.")]
        public long CNP { get; set; }

        /* Comun
        * Prenume
        */
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required!")]
        [RegularExpression(@"([A-Z][a-z]+[\s|'-']{0,}){2,}", ErrorMessage = "Characters not allowed.")]
        public string FirstName { get; set; }

        /* Comun
         * Nume de familie
         */
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required!")]
        [RegularExpression(@"([A-Z][a-z]{2,})", ErrorMessage = "Format not allowed.")]
        public string LastName { get; set; }

        
        /* Comun
         * Data Nasterii
         */
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "BirthDate is required!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        /* Comun
         * Email
         */
        [Display(Name = "Your Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail is required!")]
        [RegularExpression(@"(([A-Za-z0-9]+)(@)((gmail)|(yahoo)){1}(.)(([A-Za-z]+)))", ErrorMessage = "Format not allowed.")]
        //  [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Format not allowed.")]
        public string Email { get; set; }

        /* Comun
         * Parola
         */
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Password { get; set; }

        /* Comun
         * Confirmarea Parolei
         */
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not match.")]
        public string ConfirmPassword { get; set; }


        /* Comun
         * Numar de Telefon
         */
        [Required(ErrorMessage = "Phone number is required!")]
        [Display(Name = "Phone Number")]
        [DataType("PhoneNumber", ErrorMessage = "Formal not allowed.")]
        public string PhoneNumber { get; set; }


        /* Comun
         * Tipul Userului
         * 2 = User Normal
         * 1 = Medic
         * 0 = Owner
         */
        public int UserType { get; set; }


        /* Comun
         * Lista de consultatii
         */
        public List<Consult> Consults { set; get; }

        /* Doctori
         * Titlul din Diploma
         * ex: Medic Dentist / Medic de Familie
         */
        //[Required(ErrorMessage = "Title is required!")]
        //[Display(Name = "Title")]
        //[RegularExpression(@"([A-Za-z ,]){3,}", ErrorMessage = "Characters not allowed.")]
        public string Title { get; set; }

        /* Doctori
         * Adresa Cabinetului
         */
        //[Required(ErrorMessage = "Your Cabinet Ad is required!")]
        //[Display(Name = "Cabinet Adress")]
        //[RegularExpression(@"([A-Za-z ,]){3,}", ErrorMessage = "Characters not allowed.")]
        public string CabinetAdress { get; set; }


        public static UserAccount CreatePacientAccount(long cnp, string firstName, string lastName, DateTime birthDate, 
            string password, string email, string phoneNumber)
        {
            var instance = new UserAccount
            {
                Id = Guid.NewGuid(),
                Consults = new List<Consult>(),
                UserType = 2
            };
            instance.UpdatePacient(cnp, firstName, lastName, birthDate, password, email, phoneNumber);

            return instance;
        }
        
        private void UpdatePacient(long cnp, string firstName, string lastName, DateTime birthDate, string password, string email, string phoneNumber)
        {
            CNP = cnp;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public static UserAccount CreateMedicAccount(long cnp, string firstName, string lastName, DateTime birthDate,
            string password, string email, string phoneNumber, string title, string cabinetAdress)
        {
            var instance = new UserAccount
            {
                Id = Guid.NewGuid(),
                Consults = new List<Consult>(),
                UserType = 1
            };
            instance.UpdateMedic(cnp, firstName, lastName, birthDate, password, email, phoneNumber, title, cabinetAdress);

            return instance;
        }

        private void UpdateMedic(long cnp, string firstName, string lastName, DateTime birthDate, string password, string email, string phoneNumber, string title, string cabinetAdress)
        {
            CNP = cnp;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Title = title;
            CabinetAdress = cabinetAdress;
        }
    }
}
