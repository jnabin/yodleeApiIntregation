using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetLatestBalancesResponseBody
    {
        [JsonPropertyName("accountBalance")]
        public List<AccountBalance> AccountBalance { get; set; }
    }
}
