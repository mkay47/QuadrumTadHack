using DocAPI.Admin_Models.Auth;
using DocketSystemAPI.Common.Services;
using DocketSystemAPI.Controllers;
using DocketSystemAPI.Orchestrations;
using DocketSystemAPI.ServiceFactory;
using DocketSystemAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            var apiOptions = Configuration.GetSection("VOIPAuthentication").Get<APIOptions>();
            services.AddSingleton(apiOptions);

            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.FullName);
                c.SwaggerDoc("v1", new Info { Title = "Docket System API v1", Version = "v1" });
            });

            services.AddCors();

            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddScoped<AdminController>();
            //mkay
            DocketSystemServiceInjection(services);
            DocketSystemOrchestrationInjection(services);
            RegisterDependencyInjectionServiceFactory(services);

            //var connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MessagesDB;Integrated Security=True;Connect Timeout=30;";
            var connection = @"Data Source=.;Initial Catalog=DocketSystem;Integrated Security=True;Connect Timeout=30;";
            services.AddDbContext<DocketDBContext>(options => options.UseSqlServer(connection));
        }

        private void RegisterDependencyInjectionServiceFactory(IServiceCollection services)
        {
            services.AddSingleton<IDockerSystemServiceFactory, DocketSystemServiceFactory>();
            services.BuildServiceProvider();
            services.AddTransient(c => c.GetService<IDockerSystemServiceFactory>()
            .GetClient<IVOIPServiceRestClient>());
        }

        public void DocketSystemServiceInjection(IServiceCollection services)
        {
            services.AddSingleton<ISMSService, SMSService>();
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
            //app.UseCors("AllowSpecificOrigin");
            app.UseStaticFiles();
            //app.UseSoapEndpoint(path: "/PingService.svc", binding: new BasicHttpBinding());

            app.UseMvc();
        }
    }
}