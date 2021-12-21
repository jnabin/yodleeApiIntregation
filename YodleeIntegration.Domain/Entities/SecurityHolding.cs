using System.Text.Json.Serialization;
using Newtonsoft.Json;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class SecurityHolding : FullAuditedEntity
    {
        public Security Security { get; set; }

        [JsonProperty("id")]
        public string YodleeSecurityHoldingId { get; set; }
    }
}