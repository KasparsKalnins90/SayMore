using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SayMore.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }
        public SayMore.Logic.Database.Answers ToData()
        {
            return new SayMore.Logic.Database.Answers()
            {
                Text = Text,
                QuestionId = QuestionId,
                UserId = UserId,
            };
        }
        public static AnswerModel FromData(SayMore.Logic.Database.Answers data)
        {
            return new AnswerModel()
            {
                Text = data.Text,
                QuestionId = data.QuestionId,
                Id = data.Id,
                UserId = data.UserId,

            };
        }

    }
}