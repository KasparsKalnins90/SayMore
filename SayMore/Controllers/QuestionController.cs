using SayMore.Logic.Managers;
using SayMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SayMore.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            List<QuestionModel> questions = QuestionManager.GetQuestions().Select(q => QuestionModel.FromData(q)).ToList();
            return View(questions);
        }
            

        
        [HttpGet]
        public ActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateQuestion(QuestionModel model)
        {
            QuestionManager.CreateQuestion(model.ToData());
            model = new QuestionModel();
            return RedirectToAction("CreateQuestion", "Question", new { id = model.Id });
        }
        [HttpGet] 
        public ActionResult ShowQuestion(int id)
        {
            QuestionModel question = new QuestionModel();
          
                question = QuestionModel.FromData(QuestionManager.GetQuestion(id));


            return View(question);
        }
        [HttpPost] // post nozīmē datu iesūtīšana
        public ActionResult ShowQuestion(QuestionModel model)
        {
            if (ModelState.IsValid) // iebūvēta funkcija, kas pārbauda vai dati atbilst definētajiem 
            {
   
                    QuestionManager.CreateQuestion(model.ToData());

            }
            return RedirectToAction("ShowQuestion", "Question", new { id = model.Id });
        }   
    }
}