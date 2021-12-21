using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YodleeIntegration.Api.Models.Verification
{
    public class InitiaiteMatchingServiceandChallengeDepositParams
    {
        [JsonPropertyName("accountId")]
        public long AccountId { get; set; }

        [JsonPropertyName("providerAccountId")]
        public long ProviderAccountId { get; set; }

        [JsonPropertyName("verificationType")]
        public string VerificationType { get; set; }

        [JsonPropertyName("account")]
        public string Account { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (AccountId != 0)
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId.ToString()));
            }

            if (ProviderAccountId != 0)
            {
                parameters.Add(new KeyValuePair<string, string>("providerAccountId", ProviderAccountId.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(VerificationType))
            {
                parameters.Add(new KeyValuePair<string, string>("verificationType", VerificationType));
            }

            if (Account != null)
            {
                parameters.Add(new KeyValuePair<string, string>("account", Account));
            }

            return parameters;
        }
    }
}