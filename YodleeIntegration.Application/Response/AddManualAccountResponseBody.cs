using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class AddManualAccountResponseBody
    {
        [JsonPropertyName("account")]
        public List<AddManualResponseAccount> Account { get; set; }
    }
}
