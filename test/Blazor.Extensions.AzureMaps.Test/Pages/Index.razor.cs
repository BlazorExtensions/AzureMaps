using System.Threading.Tasks;
using Blazor.Extensions.AzureMaps.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace Blazor.Extensions.AzureMaps.Test.Pages
{
    public partial class Index:IComponent
    {
        private Map azureMaps;
        [Inject]public IConfiguration Configuration { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await this.azureMaps.SetupMap(this.Configuration["AzureMaps-Primary-Key"], 25.482951, 21.349695);
            }
        }
    }
}
