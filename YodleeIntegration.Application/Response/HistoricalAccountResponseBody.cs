using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class HistoricalAccountResponseBody
    {
        [JsonPropertyName("account")]
        public List<HistoricalAccount> Account { get; set; }
    }
}
