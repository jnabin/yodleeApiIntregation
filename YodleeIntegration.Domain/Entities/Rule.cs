using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Rule : FullAuditedEntity
    {
        [Required(ErrorMessage = "Category Id is empty.")]
        public int CategoryId { get; set; }

        public int Priority { get; set; }

        public string Source { get; set; }

        [Required(ErrorMessage = "Rule Clause is empty.")]
        public List<RuleClause> RuleClause { get; set; }
    }
}