﻿using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRep
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DatabaseContext _databaseService;

        public QuestionRepository(DatabaseContext databaseService)
        {
            _databaseService = databaseService;
        }

        public IList<Answer> GetAllAnswersForQuestion(Guid id)
        {
            return _databaseService.Answers.Where(answer => answer.QuestionId == id).ToList();
        }

        public IReadOnlyList<Question> GetAllQuestions()
        {
            return _databaseService.Questions.ToList();
        }

        public Question GetQuestionById(Guid id)
        {
            return _databaseService.Questions.SingleOrDefault(answer => answer.Id == id);
        }

        public void CreateQuestion(Question question)
        {
            _databaseService.Questions.Add(question);

            _databaseService.SaveChanges();
        }

        public void EditQuestion(Question question)
        {
            _databaseService.Questions.Update(question);

            _databaseService.SaveChanges();
        }

        public void DeleteQuestion(Question question)
        {
            _databaseService.Questions.Remove(question);

            _databaseService.SaveChanges();

        }
    }
}
