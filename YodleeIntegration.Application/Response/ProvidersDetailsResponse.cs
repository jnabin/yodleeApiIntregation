using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class ProvidersDetailsResponse
    {
        [JsonPropertyName("provider")]
        public List<Provider> Provider { get; set; }
    }
}
