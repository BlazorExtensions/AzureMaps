using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    public class ShapeProperties
    {
        [JsonPropertyName("subType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? SubType { get; set; }
        [JsonPropertyName("radius")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? Radius { get; set; }
    }
}