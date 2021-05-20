using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    public enum DrawingInteractionType
    {
        Click,
        Freehand,
        Hybrid
    }

    public enum DrawingMode
    {
        DrawCircle,
        DrawLine,
        DrawPoint,
        DrawPolygon,
        DrawRectangle,
        EditGeometry,
        Idle
    }

    public class DrawingManagerOptions
    {
        [JsonPropertyName("dragHandleStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public HtmlMarkerOptions? DragHandleStyle { get; set; }

        [JsonPropertyName("freehandInterval")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? FreehandInterval { get; set; }

        [JsonConverter(typeof(EnumToLowerCaseFirstLetterConverter<DrawingInteractionType>))]
        [JsonPropertyName("interactionType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DrawingInteractionType? InteractionType { get; set; }

        [JsonConverter(typeof(EnumToLowerCaseFirstLetterConverter<DrawingMode>))]
        [JsonPropertyName("mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DrawingMode? Mode { get; set; }

        [JsonPropertyName("secondaryDragHandleStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public HtmlMarkerOptions? SecondaryDragHandleStyle { get; set; }

        [JsonPropertyName("shapeDraggingEnabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShapeDraggingEnabled { get; set; }

        [JsonPropertyName("toolbar")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DrawingToolbar? Toolbar { get; set; }
        [JsonPropertyName("latitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Latitude { get; set; }
        [JsonPropertyName("longitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Longitude { get; set; }
        [JsonPropertyName("radius")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Radius { get; set; }
    }
}
