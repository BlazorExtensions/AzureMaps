using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    /// <summary>
    /// Global properties used in all atlas service requests.
    /// From ServiceOptions
    /// </summary>
    public partial class MapOptions
    {
        [JsonPropertyName("authenticationOptions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AuthenticationOptions? AuthenticationOptions { get; set; }

        [JsonPropertyName("disableTelemetry")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DisableTelemetry { get; set; }

        [JsonPropertyName("domain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Domain { get; set; }

        [JsonPropertyName("enableAccessibility")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? EnableAccessibility { get; set; }

        [JsonPropertyName("refreshExpiredTiles")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? RefreshExpiredTiles { get; set; }

        [JsonPropertyName("subscriptionKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? SubscriptionKey { get; set; }

        [JsonPropertyName("sessionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? SessionId { get; set; }
    }
}