using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class VerifyChallengeDepositRequestBody
    {
        [JsonPropertyName("accountId")]
        public long AccountId { get; set; }

        [JsonPropertyName("providerAccountId")]
        public long ProviderAccountId { get; set; }

        [JsonPropertyName("verificationType")]
        public string VerificationType { get; set; }

        [JsonPropertyName("account")]
        public VerificationAccount Account { get; set; }

        [JsonPropertyName("transaction")]
        public IEnumerable<VerificationTransaction> Transaction { get; set; }
    }
}
