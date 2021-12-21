using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetSecurityDetailsResponse
    {
        [JsonPropertyName("holding")]
        public List<SecurityHolding> Holding { get; set; }
    }
}
