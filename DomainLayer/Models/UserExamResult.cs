using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DomainLayer.Models
{
    public class UserExamResult
    {
        public int Id { get; set; }


        public decimal Score { get; set; }

        public bool PassStatus { get; set; }

        public int TotalCorrectAnswers {  get; set; }
        public int TotalQuestions { get; set; }

        public int ExamId { get ; set; }
        public Exam Exam { get; set; }

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }



        


    }
}
