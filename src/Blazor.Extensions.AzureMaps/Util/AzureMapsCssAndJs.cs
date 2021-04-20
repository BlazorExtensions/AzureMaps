using System.Threading.Tasks;

namespace Blazor.Extensions.AzureMaps.Util
{
    public class AzureMapsCssAndJs : IAzureMapsCssAndJs
    {
        private readonly AzureMapsInterop _azureMapsInterop;

        public AzureMapsCssAndJs(AzureMapsInterop azureMapsInterop)
        {
            _azureMapsInterop = azureMapsInterop;
        }

        public async Task SetCssAndJs(string version)
        {
            await _azureMapsInterop.SetCssAndJs(version);
        }
    }
}