using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    public class DrawingToolbar
    {
        [JsonPropertyName("options")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DrawingToolbarOptions? Options { get; set; }
    }
}