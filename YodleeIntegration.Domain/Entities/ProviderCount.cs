using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class ProviderCount : FullAuditedEntity
    {
        public Total Total { get; set; }
    }
}