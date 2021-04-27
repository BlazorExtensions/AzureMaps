// using System.Threading.Tasks;
// using Microsoft.JSInterop;

// namespace Blazor.Extensions.AzureMaps.Util
// {
//     public class AzureMapsInterop
//     {
//         private const string AzureMapsScriptName = "./_content/Blazor.Extensions.AzureMaps/BE.AzureMaps.js";
//         private const string ImportModuleJSMethod = "import";
//         private const string InitMethod = "init";
//         private const string SetupMapMethod = "setupMap";
//         private const string SetLocationmethod = "setLocation";
//         private const string ShowPopUpMethod = "showPopup";
//         private const string SetCssAndJssMethod = "setCssAndJs";
//         private readonly IJSRuntime _runtime;
//         private IJSObjectReference _azureMapsModule = default!;

//         public AzureMapsInterop(IJSRuntime jsRuntime)
//         {
//             _runtime = jsRuntime;
//         }

//         public async ValueTask<bool> SetCssAndJs(string version)
//         {
//             await this.EnsureModuleLoaded();
//             return await this._azureMapsModule.InvokeAsync<bool>(SetCssAndJssMethod, version);
//         }

//         public async ValueTask<bool> Init(string mapName, string subscriptionKey)
//         {
//             await this.EnsureModuleLoaded();
//             return await this._azureMapsModule.InvokeAsync<bool>(InitMethod, mapName, subscriptionKey);
//         }

//         public async ValueTask<bool> SetupMap(string subscriptionKey, double latitude, double longitude)
//         {
//             await this.EnsureModuleLoaded();
//             return await this._azureMapsModule.InvokeAsync<bool>(SetupMapMethod, subscriptionKey, latitude, longitude);
//         }

//         public async ValueTask<bool> SetLocation(string subscriptionKey, string searchAddress)
//         {
//             await this.EnsureModuleLoaded();
//             return await this._azureMapsModule.InvokeAsync<bool>(SetLocationmethod, subscriptionKey, searchAddress);
//         }
//         public async ValueTask<bool> ShowPopup(double longitude, double latitud, string text)
//         {
//             await this.EnsureModuleLoaded();
//             return await this._azureMapsModule.InvokeAsync<bool>(ShowPopUpMethod, longitude, latitud, text);
//         }

//         private async ValueTask EnsureModuleLoaded()
//         {
//             this._azureMapsModule = await _runtime.InvokeAsync<IJSObjectReference>(
//                     ImportModuleJSMethod, AzureMapsScriptName);
//         }
//     }
// }
