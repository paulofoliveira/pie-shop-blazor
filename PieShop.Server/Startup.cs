using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PieShop.Application.Services;
using System;

namespace Pieshop.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            var apiUri = new Uri("https://localhost:44340/");

            services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client =>
            {
                client.BaseAddress = apiUri;
            });
            services.AddHttpClient<ICountryDataService, CountryDataService>(client =>
            {
                client.BaseAddress = apiUri;
            });
            services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client =>
            {
                client.BaseAddress = apiUri;
            });
        }

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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
