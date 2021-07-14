/************************************************************************************************************
************************************************************************************************************
    File Name     :   Startup.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Startup file for AppGateway Project
************************************************************************************************************
************************************************************************************************************/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NavTech.BusinessProcess.Interfaces;
using NavTech.BusinessProcess.Services;
using NavTech.DataAccess.Interfaces;
using NavTech.DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using NavTech.AppGateway.DataAccess.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NavTech.AppGateway
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
            //To initialize the sql server db context
            services.AddDbContextPool<ProductDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("SqlConnectionString")));
            //To access all Business and DAL layers using DI
            services.AddSingleton<IConfigure, ConfigureBl>();
            services.AddSingleton<IReadConfigure, ReadConfigureDl>();
            services.AddSingleton<IProductRepository, ProductRepository>();  
            //To get response from http client methods
            services.AddHttpClient();
            var serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            services.AddSingleton(serializer);
            //To get the api response in JSON format
            services.AddMvc().AddNewtonsoftJson(options =>
            options.SerializerSettings.ContractResolver =
               new CamelCasePropertyNamesContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(
                options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            );
            app.UseRouting();
            //Adding custom exception middleware
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
