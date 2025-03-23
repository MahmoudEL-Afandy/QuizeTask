using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList.Extensions;

namespace ApplicationLayer.ViewModel
{
    public class QuestionVM
    {
        public ICollection<Question> Questions { get; set; }
        public int ExamId { get; set; }
    }
}
