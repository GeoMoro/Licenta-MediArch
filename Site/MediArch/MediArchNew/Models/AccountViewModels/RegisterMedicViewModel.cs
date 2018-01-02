using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MediArchNew.Models.AccountViewModels
{
    public class RegisterMedicViewModel
    {

        public RegisterMedicViewModel() // MVC can call that
        {
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CNP is required!")]
        [Display(Name = "CNP")]
        [RegularExpression(@"(([1-6]{1})([0-9]{2})(((0)[1-9]{1})|((1)[0-2]{1}))(((0)[1-9]{1})|([1-2]{1}[0-9]{1})|((3)[0-1]{1}))([0-9]{6}))", ErrorMessage = "Format not allowed.")]
        public long CNP { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required!")]
        [Display(Name = "First Name")]
        [RegularExpression(@"([A-Za-z]{2,}[\s|'-']{0,})+", ErrorMessage = "Characters not allowed.")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required!")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"([A-Za-z]{2,})", ErrorMessage = "Format not allowed.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "BirthDate is required!")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail is required!")]
        [Display(Name = "Your Email")]
        [RegularExpression(@"(([A-Za-z0-9]+)(@)((gmail)|(yahoo)){1}(.)(([A-Za-z]+)))", ErrorMessage = "Format not allowed.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required!")]
        [Display(Name = "Phone Number")]
        [DataType("PhoneNumber", ErrorMessage = "Format not allowed.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        [Display(Name = "Title")]
        [RegularExpression(@"([A-Za-z ,]){3,}", ErrorMessage = "Characters not allowed.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Your Cabinet Ad is required!")]
        [Display(Name = "Cabinet Adress")]
        [RegularExpression(@"([A-Za-z ,]){3,}", ErrorMessage = "Characters not allowed.")]
        public string CabinetAdress { get; set; }
    }
}
