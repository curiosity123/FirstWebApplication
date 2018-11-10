using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWebApp.EF;
using MyWebApp.Middleware;
using MyWebApp.Models;
using MyWebApp.Repositories;

namespace MyWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Data Source=mssql4.webio.pl,2401\lukasz86radom_WebPageDb;Initial Catalog=lukasz86radom_WebPageDb;Integrated Security=False;User ID=lukasz86radom_lukasz86radom;Password=luk2739R.;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true;";
            // Mapper.Initialize(cfg => { cfg.CreateMap<PostDTO, Post>(); });
            // services.AddSingleton<IBlogRepository, XmlBlogRepository>();
            services.AddDbContext<PostsContext>(options => options.UseSqlServer(connection));
            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.UseNodeModules(env.ContentRootPath);
            app.UseMvc(ConfigureRoutes);

            
            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType="text/plain";
            //    await context.Response.WriteAsync("Not Fount :( ");
            //});
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default","{controller=Home}/{action=Index}");
        }
    }
}
