using System.Threading.Tasks;
using Blazor.Extensions.AzureMaps.Util;
using Microsoft.AspNetCore.Components;

namespace Blazor.Extensions.AzureMaps.Components
{
    public partial class Map : ComponentBase
    {
        [Inject] public AzureMapsInterop AzureMapsInterop { get; set; }

        protected override void OnAfterRender(bool firstrun)
        {
            if (firstrun)
            {
                AzureMapsInterop.SetupMap("<some key>", 9.748917, -83.753426);
            }
        }

        public ValueTask<bool> SetupMap(string subscriptionKey, double latitude, double longitude) =>
            AzureMapsInterop.SetupMap("<some key>", 9.748917, -83.753426);
    }
}
