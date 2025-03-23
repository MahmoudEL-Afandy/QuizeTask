using DomainLayer.Models;
using DomainLayer.Repositories;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Implementations
{
    public class UserExamRepository : Repository<Exam>, IUserExamRepository
    {
        private readonly ApplicationDbContext _context;
        public UserExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Exam GetExamIncQ(int id)
        {
           var exam=_context.Exams.Include(x=>x.Questions).FirstOrDefault(x=>x.Id == id);
           return exam;
            
        }

        public IEnumerable<Exam> GetExamWithSearch(string search)
        {
            var query = _context.Exams.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Title.Contains(search) || e.Description.Contains(search));
            }

            return query.ToList();
        }
    }
}
