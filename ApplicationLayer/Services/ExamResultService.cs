using DomainLayer.Models;
using DomainLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class ExamResultService
    {
        private readonly IRepository<UserExamResult> _userExamResultRepository;

        public ExamResultService(IRepository<UserExamResult> repository)
        {
            _userExamResultRepository = repository;
            
        }


        public void AddResult(UserExamResult userExamResult)
        {
            _userExamResultRepository.Add(userExamResult);
        }

        public UserExamResult GetResult(int examId, string userID)
        {
            var examRes = _userExamResultRepository?.GetFirstOrDefault(x => x.ExamId == examId && x.IdentityUserId == userID);

            return examRes;
        }
    }
}
