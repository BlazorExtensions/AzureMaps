using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Extensions.AzureMaps.Util
{
    public class AzureMapsInterop
    {
        protected IJSRuntime JSRuntime { get; }

        public AzureMapsInterop(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }
        
        public ValueTask<bool> SetCssAndJs(string version)=> JSRuntime.InvokeAsync<bool>("BlazorExtensionsAzureMaps.setCssAndJs", version);
        public ValueTask<bool> Init(string mapName, string subscriptionKey) => JSRuntime.InvokeAsync<bool>("BlazorExtensionsAzureMaps.init", mapName, subscriptionKey);
        public ValueTask<bool> SetupMap(string subscriptionKey, double latitude, double longitude) => JSRuntime.InvokeAsync<bool>("BlazorExtensionsAzureMaps.setupMap", subscriptionKey, latitude, longitude);
        public ValueTask<bool> SetLocation(string subscriptionKey, string searchAddress) => JSRuntime.InvokeAsync<bool>("BlazorExtensionsAzureMaps.setLocation", subscriptionKey, searchAddress);
        public ValueTask<bool> ShowPopup(double longitude,double latitud, string text)=> JSRuntime.InvokeAsync<bool>("BlazorExtensionsAzureMaps.showPopup", longitude,latitud,text);
    }
}
