using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestAppCorelearning.Models;

namespace TestAppCorelearning
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration; 
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbcontext>(option => option.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Error");                
            }

            app.UseDefaultFiles();
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseStaticFiles();

           // app.UseFileServer();

            //app.Use(async (context,next) =>
            //{
            //    logger.LogInformation("LOgger for middle ware");
                
            //    await context.Response.WriteAsync(_config["MyKey"]);
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //   // logger.LogInformation("LOgger for middle ware Last");
            //    await context.Response.WriteAsync("Second Middle ware");
            //});
        }
    }
}
