using Data.Domain.Interfaces;
using Data.Domain.Interfaces.ServiceInterfaces;
using MediArch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Domain.Entities;
using MediArch.Models.AccountViewModels;
using MediArch.Models;

namespace MediArch.Services.Services
{
    public class RecordService : IRecordService
    {
        private readonly IApplicationUserService _appUserService;
        private readonly IConsultService _consultService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public RecordService(IApplicationUserService appUserService, IConsultService consultService, IQuestionService questionService, IAnswerService answerService)
        {
            _appUserService = appUserService;
            _questionService = questionService;
            _consultService = consultService;
            _answerService = answerService;
        }
        public List<UserRecordViewModel> GetAllUsers()
        {
            List<ApplicationUser> users = _appUserService.GetAllUsers().OrderBy(x => x.CreatedDate).ToList();
            List<UserRecordViewModel> rez = new List<UserRecordViewModel>();
            foreach(var user in users)
            {
                UserRecordViewModel usr = new UserRecordViewModel(user.Id, user.FirstName, user.LastName, user.BirthDate, user.Title, user.CabinetAdress, user.PhoneNumber, user.ActiveAccount, user.CreatedDate);
                rez.Add(usr);

            }
            return rez;
        }

        public List<Answer> GetAllAnswers()
        {
            return _answerService.GetAllAnswers().OrderBy(x => x.AnswerDate).ToList();
        }

        public List<Consult> GetAllConsults()
        {
            return _consultService.GetAll().OrderBy(x => x.ConsultDate).ToList();
        }

        public List<Question> GetAllQuestions()
        {
            return _questionService.GetAllQuestions().OrderBy(x => x.CreatedDate).ToList();
        }

        
    }
}
