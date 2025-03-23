using ApplicationLayer.ViewModel;
using DomainLayer.Models;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class ExamServices 
    {
        private readonly IRepository<Exam> _examRepository;
        private readonly IUserExamRepository _userExamRepository;

        public ExamServices(IRepository<Exam> repository, IUserExamRepository userExamRepository)
        {
            _examRepository = repository;
            _userExamRepository = userExamRepository;
        }

        public IEnumerable<Exam> GetAllExam()
        {
            return _examRepository.GetAll();
        }

        public Exam GetExam(int id)
        {
            return _examRepository.GetFirstOrDefault(x=> x.Id == id, IncludeWord:"Questions");
        }

        public void AddExam(Exam exam)
        {
            _examRepository.Add(exam);
        }
        public void RemoveExam(int id)
        {
            _examRepository.Delete(id);
        }
        public void UpDateExam(Exam exam)
        {
            _examRepository.Update(exam);
        }


        public QuestionVM GetQuestions(int examId)
        {
            //var exam = _examRepository.GetFirstOrDefault(x => x.Id == examId, IncludeWord: "Questions");
            //QuestionVM questionVM = new QuestionVM();
            //questionVM.ExamId = examId;
            //foreach (var item in exam.Questions )
            //{
            //    questionVM.Questions.Add(item);
            //}
            //return questionVM;
            var exam = _userExamRepository.GetExamIncQ(examId);
            QuestionVM questionVM = new QuestionVM();
            questionVM.ExamId = examId;
            questionVM.Questions = exam.Questions;
            //foreach (var item in exam.Questions)
            //{
            //    questionVM.Questions.Add(item);
            //}
            return questionVM;

        }


        public IEnumerable<Exam> GetExamsWithSearch (string search)
        {
            return _userExamRepository.GetExamWithSearch(search);
        }
    }
}
