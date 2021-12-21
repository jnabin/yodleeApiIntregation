using System.ComponentModel.DataAnnotations.Schema;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class RuleClause : FullAuditedEntity
    {
        public string Field { get; set; }

        public string Operation { get; set; }
        [NotMapped]
        public object Value { get; set; }
    }
}