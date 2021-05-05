using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    public class Popup
    {
        [JsonPropertyName("options")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PopupOptions? Options { get; set; }
    }
}