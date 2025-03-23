using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);

        bool Delete(int id);

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? IncludeWord = null);

        T GetFirstOrDefault(Expression<Func<T, bool>>? predicate, string? IncludeWord = null);
        

        bool Update (T entity);

    }
}
