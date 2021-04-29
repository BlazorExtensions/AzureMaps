using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps.Models
{
    /// <summary>
    /// The options for enabling/disabling user interaction with the map.
    /// From UserInteractionOptions
    /// </summary>
    public partial class MapOptions
    {
        [JsonPropertyName("interactive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Interactive { get; set; }

        [JsonPropertyName("scrollZoomInteraction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ScrollZoomInteraction { get; set; }

        [JsonPropertyName("boxZoomInteraction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? BoxZoomInteraction { get; set; }

        [JsonPropertyName("dragRotateInteraction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DragRotateInteraction { get; set; }

        [JsonPropertyName("dragPanInteraction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DragPanInteraction { get; set; }

        [JsonPropertyName("keyboardInteraction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? KeyboardInteraction { get; set; }

        [JsonPropertyName("dblClickZoomInteraction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DoubleClickZoomInteraction { get; set; }

        [JsonPropertyName("touchInteraction")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? TouchInteraction { get; set; }

        [JsonPropertyName("wheelZoomRate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? WheelZoomRate { get; set; }
    }
}