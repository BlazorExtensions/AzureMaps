using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    public class PolygonOptions
    {
        [JsonPropertyName("fillColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? FillColor { get; set; }
        [JsonPropertyName("fillOpacity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? FillOpacity { get; set; }
    }
}