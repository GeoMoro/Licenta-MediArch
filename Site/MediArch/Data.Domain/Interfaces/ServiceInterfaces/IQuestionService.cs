using Data.Domain.Entities;
using Data.Domain.ServiceInterfaces.Models.QuestionViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfaces
{
    public interface IQuestionService
    {
        IReadOnlyList<Question> GetAllQuestions();
        IList<Answer> GetAllAnswersForQuestion(Guid id);
        Question GetQuestionById(Guid id);
        void CreateQuestion(Question question);
        void EditQuestion(Question question);
        void DeleteQuestion(Question question);
        void CreateQuestion(QuestionCreateModel questionCreateModel);
        bool CheckIfQuestionExists(Guid id);

        int GetNumberOfPagesForQuestions();
        IReadOnlyList<Question> Get5QuestionsByIndex(int index);
        string getUrlBase();
    }
}
