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

        /* Comun
         * cerut de Identity
         */
        [Key]
        public Guid Id { get; set;}

        /* Comun
         * CNP
         */
        [Required(AllowEmptyStrings = false, ErrorMessage = "CNP is required!")]
        [Display(Name = "CNP")]
        [RegularExpression(@"(([1-6]{1})([0-9]{2})(((0)[1-9]{1})|((1)[0-2]{1}))(((0)[1-9]{1})|([1-2]{1}[0-9]{1})|((3)[0-1]{1}))([0-9]{6}))", ErrorMessage = "Format not respected.")]
        [MinLength(13, ErrorMessage = "CNP must have 13 characters")]
        [MaxLength(13, ErrorMessage = "CNP must have 13 characters")]
        public long CNP { get; set; }

        /* Comun
        * Prenume
        */
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required!")]
        [Display(Name = "First Name")]
        [RegularExpression(@"[A-Za-z]{2,}([\s|-]{1}[A-Za-z]{2,}){0,}", ErrorMessage = "Format not respected.")] //ăîșțâĂÎȘȚÂ
        [MinLength(2, ErrorMessage = "Each name mush have at least 2 characters!")]
        public string FirstName { get; set; }

        /* Comun
         * Nume de familie
         */
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required!")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"[A-Za-z]{2,}([\s|-]{1}[A-Za-z]{2,}){0,}", ErrorMessage = "Format not respected.")]
        [MinLength(2, ErrorMessage = "Each name mush have at least 2 characters!")]
        public string LastName { get; set; }


        /* Comun
         * Data Nasterii
         */
        [Required(ErrorMessage = "BirthDate is required!")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        /* Comun
         * Email
         */
        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail is required!")]
        [Display(Name = "Your Email")]
        [RegularExpression(@"(([A-Za-z0-9_|-]{3,})(@)((gmail)|(yahoo)){1}(.)(([A-Za-z]+)))", ErrorMessage = "Format not respected.")]
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
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords not match.")]
        public string ConfirmPassword { get; set; }


        /* Comun
         * Numar de Telefon
         */
        [Required(ErrorMessage = "Phone number is required!")]
        [Display(Name = "Phone Number")]
        [DataType("PhoneNumber", ErrorMessage = "Format not allowed.")]
        [RegularExpression(@"([0-9]){1,}", ErrorMessage = "Format not respected.")]
        [MinLength(10, ErrorMessage = "Length should be 10")]
        [MaxLength(10, ErrorMessage = "Length should be 10")]
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

        /* Medici
         * Titlul din Diploma
         * ex: Medic Dentist / Medic de Familie
         */
         /*
            [Required(ErrorMessage = "Title is required!")]
            [Display(Name = "Title")]
            [RegularExpression(@"[A-Za-z|.]{2,}([\s|-|,]{1,2}[A-Za-z|.]{2,}){0,}", ErrorMessage = "Format not respected.")]
            [MinLength(3, ErrorMessage = "Title must have at least 3 characters")]
        */
        public string Title { get; set; }

        /* Medici
         * Adresa Cabinetului
         */
         /*
            [Required(ErrorMessage = "Your Cabinet Adress is required!")]
            [Display(Name = "Cabinet Adress")]
            [RegularExpression(@"[A-Za-z0-9|.|-]{1,}([\s|-|,]{1,2}[A-Za-z0-9|.|-]{1,}){0,}", ErrorMessage = "Format not respected.")]
            [MinLength(1, ErrorMessage = "Adress must have at least 1 character")]
        */
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
