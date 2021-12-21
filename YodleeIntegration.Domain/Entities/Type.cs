using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Type : FullAuditedEntity
    {
        public RunningBalance Amount { get; set; }

        public string BaseType { get; set; }
    }
}