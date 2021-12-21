using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YodleeIntegration.Application.Request
{
    public class VerificationTransaction
    {
        [JsonPropertyName("amount")]
        public Money Amount { get; set; }

        [JsonPropertyName("baseType")]
        public string BaseType { get; set; }
    }
}
