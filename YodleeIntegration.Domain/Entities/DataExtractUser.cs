using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class DataExtractUser : FullAuditedEntity
    {
        public string LoginName { get; set; }
    }
}