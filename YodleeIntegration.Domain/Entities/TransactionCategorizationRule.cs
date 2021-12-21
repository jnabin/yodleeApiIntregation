using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class TransactionCategorizationRule : FullAuditedEntity
    {
        public List<RuleClaus> RuleClauses { get; set; }

        public int UserDefinedRuleId { get; set; }

        public int CategoryLevelId { get; set; }

        public int TransactionCategorizationId { get; set; }

        public int MemId { get; set; }

        public int RulePriority { get; set; }
    }
}