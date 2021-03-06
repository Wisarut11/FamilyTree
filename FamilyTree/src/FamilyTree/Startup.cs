﻿using System;
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
using FamilyTree.Models;

namespace FamilyTree
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = "Data Source=185.7.62.242\\SQLEXPRESS;Database=FamilyTree; Integrated Security = False; User ID = Grupp4; Password = Safari;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True;";
                
                services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ftContext>(options =>
                {
                    options.UseSqlServer(connString);
                    
                }
                );


            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ftContext>()
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
                /*app.UseMvc(routes =>
                {
                    /*routes.MapRoute(
                        name: "reg",
                        template: "Konto/Skapa",
                        defaults: new { controller = "Account", Action = "Registration" }
                        );
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id}");
                });*/
                app.UseMvcWithDefaultRoute();

            }
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
