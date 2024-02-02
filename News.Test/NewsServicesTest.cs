using Moq;
using News.DAL.Abstract.Repostory;
using News.DAL.Concrete.Repostory;
using News.Models.Request;
using News.Services;
using News.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace News.Test
{
    public class NewsServicesTest
    {
        private readonly INewsService _newsService;
        private readonly Mock<INewsRepository> _mockNewsRepository;
        public NewsServicesTest()
        {
            _mockNewsRepository = new Mock<INewsRepository>();
            _newsService = new NewsService(_mockNewsRepository.Object);
        }

        [Fact]
        public void TestAddNews()
        {
            var news = new NewsDto()
            {
                NewsContent = "Csdfs",
                NewsHeader = "sdf"
            };
            _mockNewsRepository.Setup(x => x.SaveChanges());
            var result = _newsService.AddNews(news);
            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(5, 120)]
        [InlineData(4, 24)]
        [InlineData(0, 1)]
        public void TestNewsFact(int inputx, int outputx)
        {
            var result = _newsService.FactMethod(inputx);
            Assert.Equal(outputx, result.Obj);
        }

        [Fact]
        public void TestNewsFactMinus()
        {
            var result = _newsService.FactMethod(-5);
            Assert.False(result.IsSuccess);
        }
    }
}
