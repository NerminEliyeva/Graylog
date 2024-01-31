using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using News.Models.Entities;
using News.Models.Request;
using News.Models.Response;
using News.Services;
using News.Services.Interfaces;
using System.Collections.Generic;

namespace News.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INewsService _newsServices;
        public NewsController(INewsService newsServices, ILogger<NewsController> logger)
        {
            _newsServices = newsServices;
            _logger = logger;
        }

        [HttpGet("GetNewsById")]
        public BaseResponsModel<NewsEntity> GetNewsById([FromQuery] int id)
        {
            return _newsServices.GetById(id);
        }

        [HttpGet("GetAll")]
        public BaseResponsModel<List<NewsEntity>> GetAll()
        {
            return _newsServices.GetAll();
        }
        [HttpPost("AddNews")]
        public BaseResponsModel<bool> AddNews([FromBody] NewsDto news)
        {
            return _newsServices.AddNews(news);
        }

        [HttpPost("UpdateNews")]
        public BaseResponsModel<bool> UpdateNews(UpdatedNews news)
        {
            return _newsServices.UpdateNews(news);
        }

        [HttpPost("Delete")]
        public BaseResponsModel<bool> Delete(int id)
        {
            return _newsServices.Delete(id);
        }

    }
}

//"Serilog": {
//    "Using": [ "Serilog.Sinks.Graylog" ],
//    "MinimumLevel": "Debug",
//    "WriteTo": [
//      {
//        "Name": "Graylog",
//        "Args": {
//            "hostnameOrAddress": "localhost",
//          "port": "12201",
//          "transportType": "Udp"
//        }
//    }
//    ]
//  },