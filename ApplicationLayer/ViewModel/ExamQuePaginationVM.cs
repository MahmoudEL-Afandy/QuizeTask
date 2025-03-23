using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ApplicationLayer.ViewModel
{
    public class ExamQuePaginationVM
    {
        public Exam Exam { get; set; }
        public List<Question> Questions { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

    }
}
