using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class AccountBalance : FullAuditedEntity
    {
        public string AccountName { get; set; }

        public RunningBalance TotalBalance { get; set; }

        public string AccountType { get; set; }

        public RunningBalance CurrentBalance { get; set; }

        public string RefreshStatus { get; set; }

        public string AccountNumber { get; set; }

        public RunningBalance AvailableBalance { get; set; }

        public int AccountId { get; set; }

        public string LastUpdated { get; set; }

        public RunningBalance Balance { get; set; }

        public string ProviderId { get; set; }

        public int ProviderAccountId { get; set; }

        public string Container { get; set; }

        public RunningBalance Cash { get; set; }

        public string ProviderName { get; set; }

        public string FailedReason { get; set; }
    }
}