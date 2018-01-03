using FluentValidation;
using MediArchNew.Data;
using MediArchNew.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArchNew.Models.Validation
{
    public class UserValidation : AbstractValidator<RegisterMedicViewModel>
    {
        private readonly ApplicationDbContext _databaseService;

        public UserValidation(ApplicationDbContext databaseService)
        {
            _databaseService = databaseService;

            RuleFor(x => x.CNP).Must(BeUniqueCNP).WithMessage("This CNP was already used!");
            RuleFor(x => x.Email).Must(BeUniqueEmail).WithMessage("This Mail adress was already used!");
        }

        private bool BeUniqueCNP(long cnp)
        {
            foreach (var x in _databaseService.Users.ToList())
            {
                if (x.CNP.Equals(cnp))
                    return false;
            }
            return true;
        }

        private bool BeUniqueEmail(string email)
        {
            foreach (var x in _databaseService.Users.ToList())
            {
                if (x.Email.Equals(email))
                    return false;
            }
            return true;
        }
    }
}
