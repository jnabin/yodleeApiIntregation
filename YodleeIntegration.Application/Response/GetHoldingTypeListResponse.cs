using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Response
{
    public class GetHoldingTypeListResponse
    {
        [JsonPropertyName("holdingType")]
        public List<string> HoldingType { get; set; }
    }
}
