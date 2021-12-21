using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class HoldingsSummary : FullAuditedEntity
    {
        public List<Holding> Holding { get; set; }
        public string ClassificationType { get; set; }
        public string ClassificationValue { get; set; }
        public RunningBalance Value { get; set; }
        public List<HoldingsAccount> Account { get; set; }
    }
}