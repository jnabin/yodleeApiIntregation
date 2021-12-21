using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class TransactionCriteria : FullAuditedEntity
    {
        public string Date { get; set; }

        public int Amount { get; set; }

        public List<Transaction> VerifiedTransaction { get; set; }

        public string Matched { get; set; }

        public string Keyword { get; set; }

        public string DateVariance { get; set; }

        public string BaseType { get; set; }
    }
}