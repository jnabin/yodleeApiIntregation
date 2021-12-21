using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Summary : FullAuditedEntity
    {
        public RunningBalance CreditTotal { get; set; }
        public List<SummaryDetails> Details { get; set; }
        public TransactionsLink Links { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public RunningBalance DebitTotal { get; set; }
    }
}