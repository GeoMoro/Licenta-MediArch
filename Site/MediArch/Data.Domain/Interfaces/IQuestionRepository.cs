using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        IReadOnlyList<Question> GetAllQuestions();
        IList<Answer> GetAllAnswersForQuestion(Guid id);
        Question GetQuestionById(Guid id);
        void CreateQuestion(Question question);
        void EditQuestion(Question question);
        void DeleteQuestion(Question question);
    }
}
