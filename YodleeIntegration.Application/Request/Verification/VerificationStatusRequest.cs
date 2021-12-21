using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Request.Verification
{
    public class VerificationStatusRequest : BaseRequest
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("providerAccountId")]
        public string ProviderAccountId { get; set; }

        [JsonPropertyName("verificationType")]
        public string VerificationType { get; set; }
    }
}