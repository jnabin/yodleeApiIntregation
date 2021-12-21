using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class PhoneNumber : FullAuditedEntity
    {
        public string Type { get; set; }

        public string Value { get; set; }
    }
}
