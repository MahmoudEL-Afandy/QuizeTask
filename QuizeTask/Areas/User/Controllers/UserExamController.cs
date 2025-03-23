using ApplicationLayer.Services;
using ApplicationLayer.ViewModel;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList.Extensions;

namespace QuizeTask.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserExamController : Controller
    {
        private readonly ExamServices _examServices;
        private readonly ExamResultService _examResultService;

        public UserExamController(ExamServices examServices,ExamResultService examResultService)
        {
            _examServices = examServices;
            _examResultService = examResultService;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 12;
            
            var exams =  _examServices.GetAllExam().ToPagedList(pageNumber,pageSize);

           
            return View(exams);
        }
        [Authorize]
        [HttpGet]
        public IActionResult TakeExam(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var examRes = _examResultService.GetResult(id, userId);

            if (examRes == null)
            {

                var exam = _examServices.GetExam(id);
                

                var examQuePagiVM = new ExamQuePaginationVM
                {
                    Exam = exam,
                    Questions = exam.Questions.ToList(),
                    CurrentPage = 1,
                    TotalPages = (int)Math.Ceiling(exam.Questions.Count / 5.0)
                };




                return View(examQuePagiVM);
            }
            return View("ExamResult", examRes);


        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult SubmitExam(int id, Dictionary<int, string> answers)
        {
            var exam = _examServices.GetExam(id);
            if (exam == null)
            {
                return NotFound();
            }

            int correctAnswers = 0;
            foreach (var question in exam.Questions)
            {
                if (answers.ContainsKey(question.Id) && answers[question.Id] == question.CorrectAnswer)
                {
                    correctAnswers++;
                }
            }

            decimal score = (decimal)correctAnswers / exam.Questions.Count * 100;
            bool passStatus = score >= 60;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;


            UserExamResult examResult = new UserExamResult();
            examResult.IdentityUserId = userId;
            examResult.ExamId = exam.Id;
            examResult.PassStatus = passStatus;
            examResult.Score = score;
            examResult.TotalCorrectAnswers= correctAnswers;
            examResult.TotalQuestions = exam.Questions.Count;
            _examResultService.AddResult(examResult);

            

            return View("ExamResult",examResult);
        }
    }
}
