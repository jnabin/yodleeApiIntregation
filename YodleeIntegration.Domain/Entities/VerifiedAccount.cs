using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeVerifiedAccount")]
    public class VerifiedAccount : FullAuditedEntity
    {
        public string AccountName { get; set; }

        public string VerificationStatus { get; set; }

        public string AccountType { get; set; }

        public RunningBalance CurrentBalance { get; set; }

        public string DisplayedName { get; set; }

        public List<Holder> Holder { get; set; }

        public string AccountNumber { get; set; }

        public string Classification { get; set; }

        public RunningBalance AvailableBalance { get; set; }

        public FullAccountNumberList FullAccountNumberList { get; set; }

        public int AccountId { get; set; }
        public RunningBalance Balance { get; set; }

        public string ProviderId { get; set; }

        public int ProviderAccountId { get; set; }
        public string CONTAINER { get; set; }
        public bool IsSelected { get; set; }
        public RunningBalance Cash { get; set; }
        public List<BankTransferCode> BankTransferCode { get; set; }
        public string ProviderName { get; set; }
        public string FailedReason { get; set; }
    }
}