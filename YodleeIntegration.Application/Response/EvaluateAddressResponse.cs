using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class EvaluateAddressResponse
    {
        [JsonPropertyName("address")]
        public IEnumerable<Address> Address { get; set; }

        [JsonPropertyName("isValidAddress")]
        public bool IsValidAddress { get; set; }
    }
}
