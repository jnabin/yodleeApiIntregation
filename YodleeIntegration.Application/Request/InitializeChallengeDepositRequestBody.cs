using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class InitializeChallengeDepositRequestBody
    {
        [JsonPropertyName("accountId")]
        public long AccountId { get; set; }

        [JsonPropertyName("providerAccountId")]
        public long ProviderAccountId { get; set; }

        [JsonPropertyName("verificationType")]
        public string VerificationType { get; set; }

        [JsonPropertyName("account")]
        public VerificationAccount Account { get; set; }
    }
}
