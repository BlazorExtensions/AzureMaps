using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps.Models
{
    public class AuthenticationOptions
    {
        [JsonConverter(typeof(EnumToLowerCaseFirstLetterConverter<AuthenticationType>))]
        [JsonPropertyName("authType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AuthenticationType? AuthType { get; set; }

        [JsonPropertyName("subscriptionKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? SubscriptionKey { get; set; }

        [JsonPropertyName("clientId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? ClientId { get; set; }

        [JsonPropertyName("aadAppId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? AADAppId { get; set; }

        [JsonPropertyName("aadTenant")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? AADTenant { get; set; }

        [JsonPropertyName("aadInstance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? AADInstance { get; set; }
    }

    public enum AuthenticationType
    {
        SubscriptionKey,
        Aad,
        Anonymous
    }
}