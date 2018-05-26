using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Domain.ServiceInterfaces.Models.QuestionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRep.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public IList<Answer> GetAllAnswersForQuestion(Guid id)
        {
            return _repository.GetAllAnswersForQuestion(id).OrderBy(x => x.AnswerDate).ToList();
        }

        public IReadOnlyList<Question> GetAllQuestions()
        {
            return _repository.GetAllQuestions().OrderBy(x => x.CreatedDate).ToList();
        }

        public Question GetQuestionById(Guid id)
        {
            return _repository.GetQuestionById(id);
        }

        public void CreateQuestion(Question question)
        {
            _repository.CreateQuestion(question);
        }

        public void EditQuestion(Question question)
        {
            _repository.EditQuestion(question);
        }

        public void DeleteQuestion(Question question)
        {
            _repository.DeleteQuestion(question);
        }

        public void CreateQuestion(QuestionCreateModel questionCreateModel)
        {
            _repository.CreateQuestion(
                Question.CreateQuestion(
                    questionCreateModel.UserId,
                    questionCreateModel.Text
                )
            );
        }

        public bool CheckIfQuestionExists(Guid id)
        {
            return _repository.GetAllQuestions().Any(question => question.Id == id);
        }

        public int GetNumberOfPagesForQuestions()
        {
            int rez = 0;
            int count = GetAllQuestions().Count();
            rez = count / 5;

            if (rez * 5 < count)
            {
                rez++;
            }

            return rez;
        }

        public IReadOnlyList<Question> Get5QuestionsByIndex(int index)
        {
            List<Question> rez = new List<Question>() { };
            List<Question> allQuestions = GetAllQuestions().ToList();
            int start = (index - 1) * 5;
            int finish = start + 5;
            if (allQuestions.Count > 0)
            {
                for (int i = start; i < finish; i++)
                {
                    if (i < allQuestions.Count)
                    {
                        rez.Add(allQuestions[i]);
                    }
                }
            }

            return rez;
        }
        
    }
}
