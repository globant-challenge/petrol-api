using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Petrol.DataAccess;

namespace Petrol.WebApi
{
    public class Startup
    {
        private readonly string _origin = "_origin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            _ = services.AddDbContext<PetrolDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("sqlDB")));

            services.AddTransient<IQuestionRepository, QuestionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use((context, next) =>
            {
                context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                context.Response.Headers["Access-Control-Allow-Methods"] = "POST, GET, OPTIONS, PUT, DELETE";
                context.Response.Headers["Access-Control-Allow-Headers"] = "Origin, X-Requested-With, Content-Type, Accept,Authorization";

                return next.Invoke();
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
