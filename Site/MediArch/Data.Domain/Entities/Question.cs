﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Domain.Entities
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "User Id is required.")]
        public Guid UserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Topic is required.")]
        [MinLength(1, ErrorMessage = "Topic must have at least 1 character.")]
        [MaxLength(50, ErrorMessage = "Topic cannot exceed 50 characters.")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Answer Text is required.")]
        [MinLength(1, ErrorMessage = "Answer must have at least 1 character.")]
        [MaxLength(2000, ErrorMessage = "Answer cannot exceed 2000 characters.")]
        public string Text { get; set; }

        public IList<Answer> Answers { get; set; }

        public static Question CreateQuestion(Guid userId, string topic, string text)
        {
            var instance = new Question
            {
                Id = Guid.NewGuid(),
                Answers = new List<Answer>()
            };

            instance.UpdateQuestion(userId, topic, text);

            return instance;
        }

        private void UpdateQuestion(Guid userId, string topic, string text)
        {
            UserId = userId;
            CreatedDate = DateTime.Now;
            Topic = topic;
            Text = text;
        }
    }
}
