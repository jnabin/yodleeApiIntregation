using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeStatements")]
    public class Statement : FullAuditedEntity
    {
        public long Apr { get; set; }

        public long CashApr { get; set; }

        public string BillingPeriodStart { get; set; }

        public string DueDate { get; set; }

        public RunningBalance InterestAmount { get; set; }

        public string StatementDate { get; set; }

        public RunningBalance CashAdvance { get; set; }

        public string BillingPeriodEnd { get; set; }

        public RunningBalance PrincipalAmount { get; set; }

        public RunningBalance LoanBalance { get; set; }

        public RunningBalance AmountDue { get; set; }

        public long AccountId { get; set; }

        public string LastUpdated { get; set; }

        public bool IsLatest { get; set; }

        public RunningBalance MinimumPayment { get; set; }

        public string LastPaymentDate { get; set; }

        public RunningBalance LastPaymentAmount { get; set; }

        public RunningBalance NewCharges { get; set; }

        public long YodleeStatementId { get; set; }
    }
}