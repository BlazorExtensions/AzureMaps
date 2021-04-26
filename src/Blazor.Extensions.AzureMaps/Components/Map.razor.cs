using System.Threading.Tasks;
using Blazor.Extensions.AzureMaps.Util;
using Microsoft.AspNetCore.Components;

namespace Blazor.Extensions.AzureMaps.Components
{
    public partial class Map : ComponentBase
    {
        [Inject] public AzureMapsInterop AzureMapsInterop { get; set; }

        public ValueTask<bool> SetupMap(string subscriptionKey, double latitude, double longitude) =>
            AzureMapsInterop.SetupMap(subscriptionKey, latitude, longitude);
    }
}
