using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Choice1 { get; set; }
        [Required]
        public string Choice2 { get; set; }
        [Required]
        public string Choice3 { get; set; }
        [Required]
        public string Choice4 { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

    }
}
