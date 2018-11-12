using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            services.AddScoped<IBlogRepository, MsSqlRepository>();

            services.AddIdentity<AdminUser, IdentityRole>()
               .AddEntityFrameworkStores<PostsContext>()
               .AddDefaultTokenProviders();




            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
                       
            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);
            app.UseAuthentication();
            app.UseMvc(ConfigureRoutes);

            CreateRoles(provider).Wait();
            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType="text/plain";
            //    await context.Response.WriteAsync("Not Fount :( ");
            //});
        }



        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}");
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
    {
        //initializing custom roles 
        var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var UserManager = serviceProvider.GetRequiredService<UserManager<AdminUser>>();
        string[] roleNames = { "Admin", "Store-Manager", "Member" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await RoleManager.RoleExistsAsync(roleName);
            // ensure that the role does not exist
            if (!roleExist)
            {
                //create the roles and seed them to the database: 
                roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // find the user with the admin email 
        var _user = await UserManager.FindByEmailAsync("admin@email.com");

        // check if the user exists
        if (_user == null)
        {
            //Here you could create the super admin who will maintain the web app
            var poweruser = new AdminUser
            {
                UserName = "Admin",
                Email = "admin@email.com",
            };
            string adminPassword = "P@$$w0rd";

            var createPowerUser = await UserManager.CreateAsync(poweruser, adminPassword);
            if (createPowerUser.Succeeded)
            {
                //here we tie the new user to the role
                await UserManager.AddToRoleAsync(poweruser, "Admin");

            }
        }
    }
    }
 
}
