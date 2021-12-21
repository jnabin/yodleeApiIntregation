using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Contact : FullAuditedEntity
    {
        public string Phone { get; set; }

        public string Email { get; set; }
    }
}