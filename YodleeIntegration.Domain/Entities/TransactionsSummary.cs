using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class TransactionsSummary : FullAuditedEntity
    {
        public string CategoryType { get; set; }
        public List<Summary> CategorySummary { get; set; }
        public RunningBalance CreditTotal { get; set; }
        public TransactionsLink Links { get; set; }
        public RunningBalance DebitTotal { get; set; }
    }
}