using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;

namespace FamilyTree
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FamilyTree;Integrated Security=True;Pooling=False";

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(connString));


            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddConsole(LogLevel.Error);
            {
                app.UseIISPlatformHandler();

                app.UseStatusCodePagesWithReExecute("/StatusCodes/StatusCode{0}");

                if (env.IsDevelopment())
                    app.UseDeveloperExceptionPage();
                else
                    app.UseExceptionHandler("/Home/Error");

                app.UseStaticFiles();
                app.UseIdentity();
                //app.UseMvcWithDefaultRoute();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                      name: "default",
                      template: "{controller=Home}/{action=index}/{id?}");
                });
            }
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
