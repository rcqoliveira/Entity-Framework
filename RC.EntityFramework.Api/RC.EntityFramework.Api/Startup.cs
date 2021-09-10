using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RC.EntityFramework.Api.Core;
using RC.EntityFramework.Api.Core.AutoMapper.Configuration;
using RC.EntityFramework.Api.Core.Interface;
using RC.EntityFramework.Api.Infrastructure.Data.EntityFramework.Context;
using RC.EntityFramework.Api.Infrastructure.Repository;
using RC.EntityFramework.Api.Infrastructure.Service;

namespace RC.EntityFramework.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfiguration.Initialize();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RC.Dapper.Api", Version = "v1" });
            });

            services.AddScoped<DBContextApplication>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddSingleton(Configuration.GetSection("ConfigurationApplication").Get<ConfigurationApplication>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "RC.Dapper.Api"));
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}