using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    /// <summary>
    /// The options for setting the bounds of the map control's camera.
    /// From CameraBoundsOptions
    /// </summary>
    public partial class MapOptions
    {
        [JsonPropertyName("bounds")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[]? Bounds { get; set; }

        [JsonPropertyName("offset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[]? Offset { get; set; }

        [JsonPropertyName("padding")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Padding? Padding { get; set; }
    }

    public class Padding
    {
        [JsonPropertyName("bottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Bottom { get; set; }

        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Left { get; set; }

        [JsonPropertyName("right")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Right { get; set; }

        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double Top { get; set; }

        public static implicit operator double(Padding p) => p.Top;
        public static explicit operator Padding(double p) => new Padding { Bottom = p, Left = p, Right = p, Top = p };
    }
}