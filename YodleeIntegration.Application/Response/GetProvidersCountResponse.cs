using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetProvidersCountResponse
    {
        [JsonPropertyName("provider")]
        public ProviderCount ProviderCount { get; set; }
    }
}
