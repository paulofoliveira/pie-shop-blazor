using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PieShop.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShop.ComponentsLibrary.Map
{
    public partial class Map
    {
        readonly string elementId = $"map-{Guid.NewGuid():D}";

        [Parameter]
        public double Zoom { get; set; }

        [Parameter]
        public List<Marker> Markers { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync("deliveryMap.showOrUpdate", elementId, Markers);
        }
    }
}
