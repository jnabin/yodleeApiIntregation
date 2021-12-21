using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class UpdateAccountDetails : FullAuditedEntity
    {
        public string Container { get; set; }

        public string IncludeInNetWorth { get; set; }

        public Address Address { get; set; }

        public string AccountName { get; set; }

        public string DueDate { get; set; }

        public string Memo { get; set; }

        public RunningBalance HomeValue { get; set; }

        public string AccountNumber { get; set; }

        public string Frequency { get; set; }

        public string AccountStatus { get; set; }

        public RunningBalance AmountDue { get; set; }

        public RunningBalance Balance { get; set; }

        public string Is_E_billEnrolled { get; set; }

        public string Nickname { get; set; }
    }
}