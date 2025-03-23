using ApplicationLayer.Services;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuizeTask.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    public class ExamController : Controller
    {
        private readonly ExamServices _examServices;

        public ExamController(ExamServices examServices)
        {
            _examServices = examServices;
            
        }
        public IActionResult Index()
        {
           return View();
        }
        public IActionResult GetData()
        {
            var exams = _examServices.GetAllExam();
            return Json(new { data = exams });

        }

        public IActionResult CreateExam ()
        {
            return View("CreateExam");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExam(Exam exam)
        {
            if (ModelState.IsValid)
            {
                _examServices.AddExam(exam);
                TempData["create"] = "Data Has Created Successfully";
                return RedirectToAction("Index");
            }
            return View(exam);
        }

        public IActionResult EditExam (int id)
        {
            var exam = _examServices.GetExam(id);

            if (exam == null) return NotFound();
            return View(exam);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExam(Exam exam)
        {
            if (ModelState.IsValid)
            {
                _examServices.UpDateExam(exam);
                TempData["update"] = "Data Has updated Successfully";
                return RedirectToAction("Index");
            }
            return View(exam);
        }


        public IActionResult DeleteExam(int id)
        {
            _examServices.RemoveExam(id);
            return Json(new { success = true, message = "Item Has Been Deleted Successfully " });
        }
    }
}
