using System.ComponentModel.DataAnnotations;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class AddManualAccount : FullAuditedEntity
    {
        public string IncludeInNetWorth { get; set; }

        public Address Address { get; set; }

        [Required(ErrorMessage = "Account Name is empty.")]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Account type is empty.")]
        public string AccountType { get; set; }

        public string DueDate { get; set; }

        public string Memo { get; set; }

        public RunningBalance HomeValue { get; set; }

        public string AccountNumber { get; set; }

        public string Frequency { get; set; }

        public RunningBalance AmountDue { get; set; }

        public RunningBalance Balance { get; set; }

        public string Nickname { get; set; }

        public string ValuationType { get; set; }
    }
}