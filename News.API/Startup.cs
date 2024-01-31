using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using News.DAL.Abstract.Repostory;
using News.DAL.Concrete.EntityFramework;
using News.DAL.Concrete.Repostory;
using News.Services;
using News.Services.Interfaces;

namespace News.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<NewsDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "News.API", Version = "v1" });
            });

            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<INewsRepository, NewsRepository>();

            services.AddLogging();

            //var loggerConfig = new LoggerConfiguration()
            //    .WriteTo.Graylog(new GraylogSinkOptions
            //    {
            //        HostnameOrAddress = "localhost",
            //        Port = 12201
            //    });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "News.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
