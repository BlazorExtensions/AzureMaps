using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps.Models
{
    public class PopupOptions
    {
        [JsonPropertyName("closeButton")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? CloseButton { get; set; }
        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Content { get; set; }
        [JsonPropertyName("draggable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Draggable { get; set; }
        [JsonPropertyName("fillColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? FillColor { get; set; }
        [JsonPropertyName("pixelOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<int>? PixelOffset { get; set; }
        [JsonPropertyName("position")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<int>? Position { get; set; }
        [JsonPropertyName("showPointer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowPointer { get; set; }
    }
}