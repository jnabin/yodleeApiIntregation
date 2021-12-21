using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;


namespace YodleeIntegration.Domain.Entities
{
    public class VerifyAccountDTO : FullAuditedEntity
    {
        public List<TransactionCriteria> TransactionCriteria { get; set; }
        public List<Account> Account { get; set; }
    }
}