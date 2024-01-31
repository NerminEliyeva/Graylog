using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Abstract.Repostory
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);

        T GetById(int id);

        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}
