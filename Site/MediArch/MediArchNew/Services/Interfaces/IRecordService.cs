using Data.Domain.Entities;
using MediArch.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArch.Services.Interfaces
{
    public interface IRecordService
    {
        List<UserRecordViewModel> GetAllUsers();
        List<Consult> GetAllConsults();
        List<Question> GetAllQuestions();
        List<Answer> GetAllAnswers();
    }
}
