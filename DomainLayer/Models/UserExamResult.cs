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


        public int Score { get; set; }

        public string PassStatus { get; set; }

        public int ExamId { get ; set; }
        public Exam Exam { get; set; }

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }



        


    }
}
