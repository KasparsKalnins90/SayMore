using SayMore.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayMore.Logic.Managers
{
    public class AnswerManager
    {
        public static Answers CreateAnswer(Answers answer)
        {
            using (var db = new DB())
            {
                db.Answers.Add(answer);
                db.SaveChanges();
            }
            return answer;
        }
        public static List<Answers> GetAnswers(int questionId)
        {
            using (var db = new DB())
            {
                return db.Answers.Where(m => m.QuestionId == questionId).OrderBy(m => m.Id).ToList();
            }
        }
    }
    
}
