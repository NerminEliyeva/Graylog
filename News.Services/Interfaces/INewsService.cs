using News.Models.Entities;
using News.Models.Request;
using News.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Services.Interfaces
{
    public interface INewsService
    {
        BaseResponsModel<bool> AddNews(NewsDto newNews);
        BaseResponsModel<bool> UpdateNews(UpdatedNews news);
        BaseResponsModel<NewsEntity> GetById(int id);
        BaseResponsModel<List<NewsEntity>> GetAll();
        BaseResponsModel<bool> Delete(int id);
        BaseResponsModel<int> FactMethod(int x);
    }
}
