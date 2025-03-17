using DomainLayer.Repositories;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            
        }
        public bool Add(T entity)
        {
             _dbSet.Add(entity);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var delEntity = _dbSet.Find(id);
            if (delEntity != null)
            {
                _dbSet.Remove(delEntity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? IncludeWord = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                //query = query.Where(predicate);
                query = query.Where(predicate);
            }
            if (IncludeWord != null)
            {
                foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {

                    query = query.Include(item);

                }

            }
            return query.ToList();
        }


        public T GetFirstOrDefault(Expression<Func<T, bool>>? predicate, string? IncludeWord = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (IncludeWord != null)
            {
                foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {

                    query = query.Include(item);

                }

            }
            return query.SingleOrDefault();
        }

        public bool Update(T entity)
        {
             _dbSet.Update(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
