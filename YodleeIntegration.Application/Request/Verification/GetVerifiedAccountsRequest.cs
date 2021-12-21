using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Request.Verification
{
    public class GetVerifiedAccountsRequest : BaseRequest
    {
        [JsonPropertyName("accountId")]
        public long AccountId { get; set; }

        [JsonPropertyName("providerAccountId")]
        public long ProviderAccountId { get; set; }

        [JsonPropertyName("isSelected")]
        public long isSelected { get; set; }

        [JsonPropertyName("verificationStatus")]
        public long verificationStatus { get; set; }
    }
}