using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    public class HtmlMarkerOptions
    {
        [JsonPropertyName("anchor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Anchor { get; set; }

        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Color { get; set; }

        [JsonPropertyName("draggable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Draggable { get; set; }

        [JsonPropertyName("htmlContent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? HtmlContent { get; set; }

        [JsonPropertyName("pixelOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<int>? PixelOffset { get; set; }

        [JsonPropertyName("popup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Popup? Popup { get; set; }

        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<int>? Position { get; set; }

        [JsonPropertyName("secondaryColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? SecondaryColor { get; set; }

        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Text { get; set; }

        [JsonPropertyName("visible")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Visible { get; set; }
    }
}