using System.ComponentModel.DataAnnotations.Schema;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeRuleClaus")]
    public class RuleClaus : FullAuditedEntity
    {
        public string Field { get; set; }

        public int UserDefinedRuleId { get; set; }

        public string FieldValue { get; set; }

        public string Operation { get; set; }

        public int RuleClauseId { get; set; }
    }
}