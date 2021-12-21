using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class AddManualResponseAccount : FullAuditedEntity
    {
        public string AccountName { get; set; }

        [JsonPropertyName("id")]
        public int YodleeAddManualResponseAccountId { get; set; }

        public string AccountNumber { get; set; }
    }
}