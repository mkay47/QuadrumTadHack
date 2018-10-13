using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocketSystemAPI.Controllers;
using DocketSystemAPI.Orchestrations;
using DocketSystemAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace DocketSystemAPI
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
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.FullName);
                c.SwaggerDoc("v1", new Info { Title = "Docket System API v1", Version = "v1" });
            });

            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSingleton(Configuration);
            services.AddScoped<AdminController>();

            //mkay
            DocketSystemServiceInjection(services);
            DocketSystemOrchestrationInjection(services);

            //var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MessagesDB;Integrated Security=True;Connect Timeout=30;";
            var connection = @"Data Source=.;Initial Catalog=DocketSystem;Integrated Security=True;Connect Timeout=30;";
            services.AddDbContext<DocketDBContext>(options => options.UseSqlServer(connection));
        }

        public void DocketSystemServiceInjection(IServiceCollection services)
        {
            services.AddSingleton<IAdminService, AdminService>();
        }

        public void DocketSystemOrchestrationInjection(IServiceCollection services)
        {
            services.AddSingleton<IAdminOrchestration, AdminOrchestration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Docket System API v1");
            });
            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();
        }
    }
}