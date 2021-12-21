using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class FullAccountNumberList : FullAuditedEntity
    {
        public string PaymentAccountNumber { get; set; }

        public string UnmaskedAccountNumber { get; set; }
    }
}