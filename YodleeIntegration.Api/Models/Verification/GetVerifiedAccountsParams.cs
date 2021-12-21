using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YodleeIntegration.Api.Models.Verification
{
    public class GetVerifiedAccountsParams
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("providerAccountId")]
        public string ProviderAccountId { get; set; }

        [JsonPropertyName("isSelected")]
        public string IsSelected { get; set; }

        [JsonPropertyName("verificationStatus")]
        public string VerificationStatus { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GetQueryParamsList()
        {
            var parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(AccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("accountId", AccountId));
            }

            if (!string.IsNullOrWhiteSpace(ProviderAccountId))
            {
                parameters.Add(new KeyValuePair<string, string>("providerAccountId", ProviderAccountId));
            }

            if (!string.IsNullOrWhiteSpace(IsSelected))
            {
                parameters.Add(new KeyValuePair<string, string>("verificationType", IsSelected));
            }
            if (!string.IsNullOrWhiteSpace(VerificationStatus))
            {
                parameters.Add(new KeyValuePair<string, string>("verificationType", VerificationStatus));
            }
            return parameters;
        }
    }
}