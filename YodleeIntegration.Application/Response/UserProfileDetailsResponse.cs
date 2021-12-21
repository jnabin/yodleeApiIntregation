using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class UserProfileDetailsResponse
    {
        [JsonPropertyName("providerAccount")]
        public List<ProviderAccountProfile> ProviderAccount { get; set; }
    }
}
