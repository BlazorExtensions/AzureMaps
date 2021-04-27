using System.Threading.Tasks;
using Blazor.Extensions.AzureMaps;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace Blazor.Extensions.AzureMaps.Test.Pages
{
    public partial class Index : IComponent
    {
        private MapComponent azureMaps;

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return Task.CompletedTask;
        }
    }
}
