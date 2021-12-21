using Newtonsoft.Json;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class HoldingsAccount : FullAuditedEntity
    {
        [JsonProperty("id")]
        public long YodleeDerivedHoldingsAccountId { get; set; }
        public RunningBalance Value { get; set; }
    }
}