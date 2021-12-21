using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Name : FullAuditedEntity
    {
        public string Middle { get; set; }

        public string Last { get; set; }

        public string FullName { get; set; }

        public string First { get; set; }
    }
}