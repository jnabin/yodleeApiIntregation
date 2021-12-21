using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Event : FullAuditedEntity
    {
        public Data data { get; set; }
        public string info { get; set; }
    }
}