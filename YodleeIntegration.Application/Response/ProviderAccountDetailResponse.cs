using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class ProviderAccountDetailResponse
    {
        [JsonPropertyName("providerAccount")]
        public List<ProviderAccount> ProviderAccount { get; set; }
    }
}
