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

        public ExamServices(IRepository<Exam> repository)
        {
            _examRepository = repository;
            
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
    }
}
