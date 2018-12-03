using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebApp.EF;
using MyWebApp.Middleware;
using MyWebApp.Models;
using MyWebApp.Repositories;
using System;
using System.Threading.Tasks;

namespace MyWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionString"];            
            // Mapper.Initialize(cfg => { cfg.CreateMap<PostDTO, Post>(); });
            // services.AddSingleton<IBlogRepository, XmlBlogRepository>();

            

            services.AddDbContext<PostsContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IBlogRepository, MsSqlRepository>();

            services.AddIdentity<AdminUser, IdentityRole>(Options=> { })
               .AddEntityFrameworkStores<PostsContext>()
               .AddDefaultTokenProviders();




            services.AddMvc();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
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
        var _user = await UserManager.FindByEmailAsync(Configuration["Email"]);

        // check if the user exists
        if (_user == null)
        {
            //Here you could create the super admin who will maintain the web app
            var poweruser = new AdminUser
            {
                UserName = Configuration["Admin"],
                Email = Configuration["Email"],
            };
            string adminPassword = Configuration["Password"];

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
