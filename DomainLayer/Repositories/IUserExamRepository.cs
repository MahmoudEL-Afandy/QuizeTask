using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repositories
{
    public interface IUserExamRepository : IRepository<Exam>
    {


        Exam GetExamIncQ(int id);

        IEnumerable<Exam> GetExamWithSearch(string search);
    }
}
