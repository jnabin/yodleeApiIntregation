using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Bank : FullAuditedEntity
    {
        public List<string> FullAccountNumberFields { get; set; }

        public int NumberOfTransactionDays { get; set; }
    }
}