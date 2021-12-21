using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Total : FullAuditedEntity
    {
        public long Count { get; set; }
    }
}