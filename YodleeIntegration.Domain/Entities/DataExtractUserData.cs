using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class DataExtractUserData : FullAuditedEntity
    {
        public List<Holding> Holding { get; set; }
        public int TotalTransactionsCount { get; set; }
        public DataExtractUser User { get; set; }
        public List<DataExtractAccount> Account { get; set; }
        public List<Transaction> Transaction { get; set; }
        public List<DataExtractProviderAccount> ProviderAccount { get; set; }
    }
}