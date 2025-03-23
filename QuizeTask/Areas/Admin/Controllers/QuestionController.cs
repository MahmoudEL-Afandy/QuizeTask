using ApplicationLayer.Services;
using ApplicationLayer.ViewModel;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuizeTask.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly QuestionServices _questionServices;

        public QuestionController(QuestionServices questionServices)
        {
            _questionServices = questionServices;
        }
        public IActionResult Index(int id)
        {
            QuestionVM questionVM = new QuestionVM();
            var questions = _questionServices.GetAllQuestions(id);

            questionVM.Questions = questions.ToList();
            questionVM.ExamId = id;
            return View(questionVM);
        }

        
        [HttpGet]
        public IActionResult AddQuestion(int examId)
        {
            var question = new Question { ExamId = examId };
            return View(question);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                
                _questionServices.AddQuestion(question);
                TempData["create"] = "Data Has Created Successfully";

                return RedirectToAction("Index", new {id = question.ExamId});
            }
            return View(question);
        }

        [HttpGet]
        public IActionResult EditQuestion(int id)
        {
            return View( _questionServices.GetQuestion(id));
            
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EditQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                _questionServices.UpdateQuestion(question);
                TempData["update"] = "Data Has updated Successfully";
                return RedirectToAction("Index", new { id = question.ExamId });
            }
            return View(question);
        }
        
        public IActionResult DeleteQuestion(int id)
        {
            _questionServices.DeleteQuestion(id);
            TempData["delete"] = "Data has deleted successfully";
            return RedirectToAction("Index", "Exam");
        }
    }
}
