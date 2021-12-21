using System.ComponentModel.DataAnnotations.Schema;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeIntermediary")]
    public class Intermediary : FullAuditedEntity
    {
        public string IntermediaryValue { get; set; }
    }
}