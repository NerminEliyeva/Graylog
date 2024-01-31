using News.DAL.Abstract.Repostory;
using News.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Concrete.Repostory
{
    public class NewsRepository : BaseRepository<Models.Entities.NewsEntity> , INewsRepository
    {
        public NewsRepository(NewsDbContext newsDbContext) : base(newsDbContext)
        {

        }
  
    }
}
