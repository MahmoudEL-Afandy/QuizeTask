using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ViewModel
{
    public class QuestionVM
    {
        public IEnumerable<Question> Questions { get; set; }
        public int ExamId { get; set; }
    }
}
