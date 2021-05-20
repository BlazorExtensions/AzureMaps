using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    public partial class MapOptions
    {
        [JsonPropertyName("autoResize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AutoResize { get; set; }
        [JsonPropertyName("language")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Language { get; set; }
        [JsonPropertyName("preserveDrawingBuffer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? PreserveDrawingBuffer { get; set; }
        [JsonPropertyName("renderWorldCopies")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? RenderWorldCopies { get; set; }
        [JsonPropertyName("showBuildingModels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowBuildingModels { get; set; }
        [JsonPropertyName("showFeedbackLink")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowFeedbackLink { get; set; }
        [JsonPropertyName("showLogo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowLogo { get; set; }
        [JsonPropertyName("showTileBoundaries")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowTileBoundaries { get; set; }
        [JsonPropertyName("style")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Style { get; set; }
        [JsonPropertyName("userRegion")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? UserRegion { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("view")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ViewEnum? View { get; set; }
    }

    public enum ViewEnum
    {
        AE,
        AR,
        BH,
        IN,
        IQ,
        JO,
        KW,
        LB,
        MA,
        OM,
        PK,
        PS,
        QA,
        SA,
        SY,
        YE,
        Auto,
        Unified
    }
}