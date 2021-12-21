using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class HistoricalAccount : FullAuditedEntity
    {
        public List<HistoricalBalanceAccount> HistoricalBalances { get; set; }

        [JsonPropertyName("id")]
        public int YoldeeHistoricalAccountId { get; set; }
    }
}