using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SayMore.Models
{
    public class QuestionModel
    {

        public int Id { get; set; }
        public List<QuestionModel> Questions { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Question")]
        public string Question { get; set; }

        [Required]
        [Display(Name = "Additional info")]
        public string MoreInfo { get; set; }

        public int UserId { get; set; }
        public List<AnswerModel> answers { get; set; }
        public SayMore.Logic.Database.Questions ToData()
        {
            return new SayMore.Logic.Database.Questions()
            {
               Question = Question,
               MoreInfo = MoreInfo
            };
        }
        public static QuestionModel FromData(SayMore.Logic.Database.Questions data)
        {
            return new QuestionModel()
            {
                Question = data.Question,
                MoreInfo = data.MoreInfo,
                Id = data.Id,
                
            };
        }
    }
}