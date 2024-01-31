using Microsoft.EntityFrameworkCore;
using News.DAL.Abstract.Repostory;
using News.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Concrete.Repostory
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly NewsDbContext _newsDbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext;
            _dbSet = _newsDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public void SaveChanges()
        {
            _newsDbContext.SaveChanges();
        }
        public T GetById(int id)
        {
           return _dbSet.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
           return _dbSet;    
        }
    }
}
