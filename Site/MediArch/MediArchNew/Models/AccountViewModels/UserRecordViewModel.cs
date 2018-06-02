using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArch.Models.AccountViewModels
{
    public class UserRecordViewModel
    {
        public UserRecordViewModel()
        {
            // EF
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Title { get; set; }

        public string CabinetAdress { get; set; }

        public bool ActiveAccount { get; set; }

        public DateTime CreatedDate { get; set; }

        public UserRecordViewModel(string id, string firstName, string lastName, DateTime birthDate, string title, string cabinetAdress, 
            string phoneNumber, bool activeAccount, DateTime createdDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Title = title;
            CabinetAdress = cabinetAdress;
            ActiveAccount = activeAccount;
            CreatedDate = createdDate;
        }
    }
}
