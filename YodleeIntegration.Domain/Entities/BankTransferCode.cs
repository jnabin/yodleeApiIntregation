using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class BankTransferCode : FullAuditedEntity
    {
        [JsonPropertyName("id")]

        public string YodleeBankTransferCodeId { get; set; }

        public string Type { get; set; }
    }
}
