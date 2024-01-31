using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Concrete.EntityFramework
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> dbContextOptions) : base(dbContextOptions) 
        {

        }
        public DbSet<Models.Entities.NewsEntity> News { get; set; }   

    }
}
