using SayMore.Logic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayMore.Logic.Managers
{
    public class QuestionManager
    {
        public static Questions CreateQuestion(Questions question)
        {
            using (var db = new DB())
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return question;
            }
            
        }
        public static List<Questions> GetQuestions()
        {
            using (var db = new DB())
            {
                return db.Questions.ToList();
            }
        }
        public static Questions GetQuestion(int id)
        {
            using(var db = new DB())
            {
                return db.Questions.Find(id);
            }
        }
    }
}
