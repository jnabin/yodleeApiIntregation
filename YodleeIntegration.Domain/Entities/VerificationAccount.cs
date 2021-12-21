using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeVerificationAccount")]
    public class VerificationAccount : FullAuditedEntity
    {
        public string AccountName { get; set; }

        public string AccountNumber { get; set; }

        public string AccountType { get; set; }

        public BankTransferCode BankTransferCode { get; set; }
    }
}