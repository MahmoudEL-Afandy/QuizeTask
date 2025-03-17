using DomainLayer.Models;
using DomainLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class QuestionServices
    {
        private readonly IRepository<Question> _questionsRepository;

        public QuestionServices(IRepository<Question> repository)
        {
            _questionsRepository = repository;
            
        }


        public IEnumerable<Question> GetAllQuestions(int examId)
        {
            return _questionsRepository.GetAll(x=>x.ExamId == examId);
        }

        public void AddQuestion(Question question)
        {
            _questionsRepository.Add(question);
        }

        public Question GetQuestion(int id )
        {
            return _questionsRepository.GetFirstOrDefault(x=>x.Id == id);
        }
        public void UpdateQuestion(Question question)
        {
            _questionsRepository.Update(question);
        }

        public void DeleteQuestion(int id)
        {
            _questionsRepository.Delete(id);
        }
    }
}
