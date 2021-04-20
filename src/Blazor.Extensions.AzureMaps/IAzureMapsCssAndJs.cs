using System.Threading.Tasks;

namespace Blazor.Extensions.AzureMaps
{
    public interface IAzureMapsCssAndJs
    {
        Task SetCssAndJs(string version);
    }
}
