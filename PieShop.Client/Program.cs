using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Application;
using PieShop.Application.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PieShop.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var apiUri = new Uri("https://localhost:44340/");

            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = apiUri);
            builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => client.BaseAddress = apiUri);
            builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client => client.BaseAddress = apiUri);

            await builder.Build().RunAsync();
        }
    }
}
