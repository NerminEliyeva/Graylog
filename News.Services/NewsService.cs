using News.DAL.Abstract.Repostory;
using News.Models.Entities;
using News.Models.Request;
using News.Models.Response;
using News.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public BaseResponsModel<bool> AddNews(NewsDto newNews)
        {
            BaseResponsModel<bool> model = new BaseResponsModel<bool>();
            try
            {
                model.IsSuccess = false;
                model.Obj = false;
                if (string.IsNullOrWhiteSpace(newNews?.NewsHeader) || string.IsNullOrEmpty(newNews?.NewsHeader))
                {
                    model.Message = "Header null ola bilmez";
                    return model;
                }
                if (string.IsNullOrWhiteSpace(newNews?.NewsContent) || string.IsNullOrEmpty(newNews?.NewsContent))
                {
                    model.Message = "Content null ola bilmez";
                    return model;
                }
                _newsRepository.Add(new()
                {
                    Header = newNews.NewsHeader,
                    Content = newNews.NewsContent,
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    CreatedUser = "admin"
                });

                _newsRepository.SaveChanges();

                model.Obj = true;
                model.IsSuccess = true;
                model.Message = "Elave olundu";
                return model;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Obj = false;
                model.Message = "Xeta bas verdi" + ex.ToString();
                return model;
            }

        }

        public BaseResponsModel<bool> UpdateNews(UpdatedNews news)
        {
            BaseResponsModel<bool> model = new BaseResponsModel<bool>();
            try
            {
                model.IsSuccess = false;
                model.Obj = false;
                if (news == null || news.NewsId <= 0)
                {
                    model.Message = "Boş dəyər göndərilə bilməz";
                    return model;
                }

                var oldNews = _newsRepository.GetById(news.NewsId);
                if (oldNews == null)
                {
                    model.Message = "Axtardığınız məlumat tapılmadı";
                    return model;
                }
                if (!string.IsNullOrEmpty(news.NewsHeader) && !string.IsNullOrWhiteSpace(news.NewsHeader))
                {
                    oldNews.Header = news.NewsHeader;
                }

                if (!string.IsNullOrEmpty(news.NewsContent) && !string.IsNullOrWhiteSpace(news.NewsContent))
                {
                    oldNews.Content = news.NewsContent;
                }

                oldNews.ModifiedDate = DateTime.Now;
                oldNews.ModifiedUser = "admin";
                _newsRepository.SaveChanges();

                model.IsSuccess = true;
                model.Obj = true;
                model.Message = "Əməliyyat uğurlu oldu";
                return model;
            }
            catch (Exception)
            {
                model.IsSuccess = false;
                model.Obj = false;
                model.Message = "Xəta baş verdi";
                return model;
            }

        }

        public BaseResponsModel<NewsEntity> GetById(int id)
        {
            BaseResponsModel<NewsEntity> model = new BaseResponsModel<NewsEntity>();
            try
            {
                var result = _newsRepository.GetById(id);
                if (result == null)
                {
                    model.IsSuccess = false;
                    model.Message = "Məlumat tapılmadı";
                }
                else
                {
                    model.IsSuccess = true;
                    model.Obj = result;
                }
                return model;
            }
            catch (Exception)
            {
                model.IsSuccess = false;
                model.Message = "Xəta baş verdi";
                return model;
            }
        }

        public BaseResponsModel<List<NewsEntity>> GetAll()
        {
            BaseResponsModel<List<NewsEntity>> model = new BaseResponsModel<List<NewsEntity>>();
            var result = _newsRepository.GetAll().Where(x => x.Status == 1).ToList();
            if (result.Count <= 0)
            {
                model.Obj = null;
                model.IsSuccess = false;
                model.Message = "Axtarisin neticesi yoxdur";
                return model;
            }
            model.Obj = result;
            model.IsSuccess = true;
            model.Message = "Emeliyyat ugurla basa catdi";
            return model;
        }

        public BaseResponsModel<bool> Delete(int id)
        {
            BaseResponsModel<bool> model = new BaseResponsModel<bool>();
            try
            {
                var deletedObj = _newsRepository.GetById(id);
                if (deletedObj is null)
                {
                    model.IsSuccess = false;
                    model.Obj = false;
                    model.Message = "Melumat tapilmadi";
                    return model;
                }
                if (deletedObj.Status == 0)
                {
                    model.IsSuccess = false;
                    model.Obj = false;
                    model.Message = "Melumat tapilmadi";
                    return model;
                }

                deletedObj.Status = 0;
                _newsRepository.SaveChanges();

                model.IsSuccess = true;
                model.Obj = true;
                model.Message = "Silindi";
                return model;

            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Obj = false;
                model.Message = "Xeta bas verdi" + ex.ToString();
                return model;
            }
        }

        //public BaseResponsModel<int> FactMethod(int x)
        //{
        //    BaseResponsModel<int> model = new BaseResponsModel<int>();
        //    int fact = 1;
        //    if (x < 0)
        //    {
        //        model.IsSuccess = false;
        //        model.Message = "xeta";
        //        return model;
        //    }
        //    if (x == 0)
        //    {
        //        fact = 1;
        //        model.Obj = fact;
        //        model.Message = "ugurludur";
        //        model.IsSuccess = true;
        //        return model;
        //    }
        //    for (int i = 1; i <= x; i++)
        //    {
        //        fact *= i;
        //    }
        //    model.Obj = fact;
        //    model.Message = "ugurludur";
        //    model.IsSuccess = true;
        //    return model;
        //}
    }
}
