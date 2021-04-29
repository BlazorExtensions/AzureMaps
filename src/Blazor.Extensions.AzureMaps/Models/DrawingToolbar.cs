using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps.Models
{
    public class DrawingToolbar
    {
        [JsonPropertyName("options")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DrawingToolbarOptions? Options { get; set; }
    }
}