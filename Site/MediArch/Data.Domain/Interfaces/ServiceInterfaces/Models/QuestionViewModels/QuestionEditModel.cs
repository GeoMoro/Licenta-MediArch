﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Domain.ServiceInterfaces.Models.QuestionViewModels
{
    public class QuestionEditModel
    {
        public QuestionEditModel()
        {
            // EF
        }

        [Required(ErrorMessage = "User Id is required.")]
        public Guid UserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate = DateTime.Now;

        [Required(ErrorMessage = "Topic is required.")]
        [MinLength(1, ErrorMessage = "Topic must have at least 1 character.")]
        [MaxLength(50, ErrorMessage = "Topic cannot exceed 50 characters.")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Answer Text is required.")]
        [MinLength(1, ErrorMessage = "Answer must have at least 1 character.")]
        [MaxLength(2000, ErrorMessage = "Answer cannot exceed 2000 characters.")]
        public string Text { get; set; }

        public QuestionEditModel(Guid userId, string topic, string text)
        {
            UserId = userId;
            Topic = topic;
            Text = text;
        }
    }
}
