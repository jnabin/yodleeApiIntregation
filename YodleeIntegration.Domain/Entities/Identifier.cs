using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Identifier : FullAuditedEntity
    {
        public string Type { get; set; }

        public string Value { get; set; }
    }
}