using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace PieShop.Application
{
    public partial class App
    {
        private List<Assembly> lazyLoadedAssemblies = new();

        [Inject]
        public LazyAssemblyLoader LazyAssemblyLoader { get; set; }

        private async Task OnNavigateAsync(NavigationContext args)
        {
            if (args.Path.Contains("employeedetail"))
            {
                var assemblies = await LazyAssemblyLoader.LoadAssembliesAsync(new string[] { "PieShop.ComponentsLibrary.dll" });
                lazyLoadedAssemblies.AddRange(assemblies);
            }
        }
    }
}
