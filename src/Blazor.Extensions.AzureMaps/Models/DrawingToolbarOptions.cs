using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    public class DrawingToolbarOptions
    {
        [JsonPropertyName("buttons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<string>? Buttons { get; set; }
        [JsonPropertyName("containerId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ContainerId { get; set; }
        [JsonPropertyName("numColumns")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? NumColumns { get; set; }
        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Position { get; set; }
        [JsonPropertyName("style")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Style { get; set; }
        [JsonPropertyName("visible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Visible { get; set; }
    }
}