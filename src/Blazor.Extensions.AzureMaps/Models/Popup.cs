using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps.Models
{
    public class Popup
    {
        [JsonPropertyName("options")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PopupOptions? Options { get; set; }
    }
}