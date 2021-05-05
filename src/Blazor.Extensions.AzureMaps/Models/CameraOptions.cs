using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    /// <summary>
    /// The options for setting the map control's camera.
    /// From CameraOptions
    /// </summary>
    public partial class MapOptions
    {
        [JsonPropertyName("zoom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Zoom { get; set; }

        [JsonPropertyName("center")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[]? Center { get; set; }

        [JsonPropertyName("centerOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[]? CenterOffset { get; set; }

        [JsonPropertyName("bearing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Bearing { get; set; }

        [JsonPropertyName("pitch")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Pitch { get; set; }

        [JsonPropertyName("minZoom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MinZoom { get; set; }

        [JsonPropertyName("maxZoom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MaxZoom { get; set; }

        [JsonPropertyName("maxBounds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[]? MaxBounds { get; set; }
    }
}