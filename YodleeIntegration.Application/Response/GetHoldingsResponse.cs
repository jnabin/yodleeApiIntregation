using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetHoldingsResponse
    {
        [JsonPropertyName("holding")]
        public List<Holding> Holding { get; set; }
    }
}
