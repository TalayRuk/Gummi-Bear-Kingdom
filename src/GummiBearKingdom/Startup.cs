using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
//Add Entity FrameworkCore
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//Add Model
using GummiBearKingdom.Models;

namespace GummiBearKingdom
{
    public class Startup
    {
        //add IConfigurationRoot and Environment
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new WarningConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json"); //add database 
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Add services.AddEntityFramework
            services.AddEntityFramework()
                .AddDbContext<GummiBearDbContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])); 
                        //set up the connection to connect to database
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                //a default page 
                await context.Response.WriteAsync("Welcome to Gummi Bear Kingdom!");             
            });
        }
    }
}

//next add database name to the appsettings.json