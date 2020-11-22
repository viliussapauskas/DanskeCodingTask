using DCT.Application.Services;
using DCT.Application.Services.Interfaces;
using DCT.Application.Services.TaxesCalculationService;
using DCT.Application.Validation;
using DCT.Persistence;
using DCT.Persistence.Repositories;
using DCT.Persistence.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace DCT.Web
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
            services.AddHttpContextAccessor();

            services.AddDbContext<DCT_DbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DanskeCodingTaskDB")));

            services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
            services.AddScoped<IMunicipalityService, MunicipalityService>();
            services.AddScoped<ITaxesService, TaxesService>();

            services.AddSingleton<ITaxesCalculationService, TaxesCalculationService>();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetCalculatedTaxesValidator>());

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller}/{action}/{id}"
                    );
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = Path.Join(env.ContentRootPath, "client-app");
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            app.UseRouting();
        }
    }
}
